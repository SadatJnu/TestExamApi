namespace TestExamApi.Entites
{
    public class Allergies : BaseModel
    {
        public string? Name { get; set; }
        public List<Allergies_Details> Allergies_Details { get; set; } = new();
    }
}
