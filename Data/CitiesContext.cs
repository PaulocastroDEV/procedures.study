using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudyingProcedures.Models;

namespace StudyingProcedures.Data
{
    public class CitiesContext:DbContext
    {

        public CitiesContext(DbContextOptions<CitiesContext> options)
        : base(options)
        { }

        public DbSet<Cities> cities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IHC10EU\\SQLEXPRESS;Database=citiesDatabase;Integrated Security=true;TrustServerCertificate=True");
        }
    }
}
