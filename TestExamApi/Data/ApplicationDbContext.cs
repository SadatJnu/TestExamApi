using Microsoft.EntityFrameworkCore;
using TestExamApi.Entites;

namespace TestExamApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Allergies_Details> Allergies_Details { get; set; }
        public DbSet<NCD> NCDs { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformations{ get; set; }
        public DbSet<PatientInfo> PatientInfos{ get; set; }
    }
}
