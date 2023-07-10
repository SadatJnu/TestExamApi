using TestExamApi.Enums;

namespace TestExamApi.Entites
{
    public class PatientInfo : BaseModel
    {
        public string? Name { get; set; }
        public int DeseaseId {get;set;}
        public Epilepsy EpilepsyId { get; set; }
        public List<NCD>? NCDs { get; set; }
        public List<Allergies>? Allergies { get; set; }

    }
}
