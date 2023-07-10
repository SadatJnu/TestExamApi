using Microsoft.AspNetCore.Mvc;
using TestExamApi.Data;
using TestExamApi.Entites;

namespace TestExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : BaseController<Allergies>
    {
        public AllergiesController(IRepository<Allergies> repository) : base(repository)
        {
            
        }
    }
}
