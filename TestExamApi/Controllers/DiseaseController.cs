using Microsoft.AspNetCore.Mvc;
using TestExamApi.Data;
using TestExamApi.Entites;

namespace TestExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : BaseController<DiseaseInformation>
    {
        public DiseaseController(IRepository<DiseaseInformation> repository) : base(repository)
        {
            
        }
    }
}
