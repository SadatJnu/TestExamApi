using Microsoft.AspNetCore.Mvc;
using TestExamApi.Data;
using TestExamApi.Entites;

namespace TestExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : BaseController<NCD>
    {
        public NCDController(IRepository<NCD> repository) : base(repository)
        {
            
        }
    }
}
