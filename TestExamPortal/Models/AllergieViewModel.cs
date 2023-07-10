namespace TestExamPortal.Models
{
    public class AllergieViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<AllergiesDetailViewModel> Allergies_Details { get; set; } = new();
    }
}
