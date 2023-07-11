using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestExamApi.Data;
using TestExamApi.Entites;

namespace TestExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : BaseController<NCD>
    {        
        private readonly IRepository<NCD> _repository;
        private readonly ApplicationDbContext _dbContext;

        public NCDController(IRepository<NCD> repository, ApplicationDbContext dbContext) : base(repository)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public override async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var result = await _dbContext.NCDs.Where(e => e.ID == id).FirstOrDefaultAsync();
                _dbContext.NCDs.Remove(result);
                _dbContext.SaveChangesAsync();
                if (result != null)
                {
                    return Ok();
                }
                else
                {
                    return NotFound($"{id} not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


    }
}
