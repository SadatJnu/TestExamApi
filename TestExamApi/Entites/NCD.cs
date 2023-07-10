namespace TestExamApi.Entites
{
    public class NCD : BaseModel
    {
        public string? Name { get; set; }
        public List<NCD_Details> NCD_Details { get; set; } = new();
    }
}
