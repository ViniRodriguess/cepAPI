using CEPWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace cepAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Cep> Ceps { get; set; }
    }
}
