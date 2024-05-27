using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using cepAPI.Data;
using CEPWebAPI.Models;

namespace cepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly DataContext _context;

        public CepController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetCep(string cep)
        {
            if (cep.Length != 8 || !int.TryParse(cep, out _))
            {
                return BadRequest("CEP inválido. Deve ter 8 dígitos numéricos.");
            }

            string viaCEPUrl = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    string result = client.DownloadString(viaCEPUrl);
                    JObject jsonRetorno = JObject.Parse(result);

                    if (jsonRetorno["erro"] != null)
                    {
                        return NotFound("CEP não encontrado.");
                    }

                    var cepEntity = new Cep
                    {
                        Id = Guid.NewGuid(),
                        CepCode = (string)jsonRetorno["cep"],
                        Logradouro = (string)jsonRetorno["logradouro"],
                        Complemento = (string)jsonRetorno["complemento"],
                        Bairro = (string)jsonRetorno["bairro"],
                        Localidade = (string)jsonRetorno["localidade"],
                        Uf = (string)jsonRetorno["uf"],
                        Unidade = !string.IsNullOrEmpty((string)jsonRetorno["unidade"]) ? Convert.ToInt64((string)jsonRetorno["unidade"]) : (long?)null,
                        Ibge = jsonRetorno["ibge"] != null ? jsonRetorno["ibge"].ToObject<int?>() : null,
                        Gia = (string)jsonRetorno["gia"]
                    };

                    _context.Ceps.Add(cepEntity);
                    await _context.SaveChangesAsync();

                    return Ok(cepEntity);
                }
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro ao salvar no banco de dados: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (WebException)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, "Erro ao consultar o serviço de CEP. Tente novamente mais tarde.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro: {ex.Message}");
            }
        }
    }
}
