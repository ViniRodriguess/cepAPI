using System;
using System.ComponentModel.DataAnnotations;

namespace CEPWebAPI.Models
{
    public class Cep
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(9)]
        public string CepCode { get; set; }

        [Required]
        [StringLength(500)]
        public string Logradouro { get; set; }

        [StringLength(500)]
        public string Complemento { get; set; }

        [Required]
        [StringLength(500)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(500)]
        public string Localidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Uf { get; set; }

        public long? Unidade { get; set; }

        public int? Ibge { get; set; }

        [StringLength(500)]
        public string Gia { get; set; }
    }
}
