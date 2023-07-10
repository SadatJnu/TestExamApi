namespace TestExamPortal.Models
{
    public class NCDViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<NCDDetailViewModel> NCD_Details { get; set; } = new();
    }
}
