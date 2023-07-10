using TestExamPortal.Enums;

namespace TestExamPortal.Models
{
    public class PatientInfoViewModels
    {
        public int Id { get; set; }
        public int? SL { get; set; } = 1;
        public string? Name { get; set; }
        public int DeseaseId { get; set; }
        public string? DeseaseName { get; set; }
        public Epilepsy EpilepsyId { get; set; }
        public string? EpilepsyName { get; set; }
        public List<NCDViewModel>? NCDs { get; set; }
        public List<AllergieViewModel>? Allergies { get; set; }

    }
}
