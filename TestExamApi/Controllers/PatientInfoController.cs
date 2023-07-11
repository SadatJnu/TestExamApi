using deseaseId.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq;
using TestExamApi.AppData;
using TestExamApi.Data;
using TestExamApi.Entites;

namespace TestExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInfoController : BaseController<PatientInfo>
    {
        private readonly IRepository<PatientInfo> _repository;
        private readonly ApplicationDbContext _dbContext;
        public PatientInfoController(IRepository<PatientInfo> repository, ApplicationDbContext dbContext) : base(repository)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<PatientInfo>>> GetAllAsync()
        {
            try
            {
                return await _dbContext.PatientInfos.Include(x => x.NCDs).Include(x => x.Allergies).ToListAsync();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error retrieving data from the database");
            }

        }

        public override async Task<ActionResult<PatientInfo>> GetAsync([FromRoute] int id)
        {
            try
            {

                var result = await _dbContext.PatientInfos.Include(sd => sd.NCDs).Include(x => x.Allergies).Where(e => e.ID == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"{id} not found");
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        public override async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var result = await _dbContext.PatientInfos.Include(sd => sd.NCDs).Include(x => x.Allergies).Where(e => e.ID == id).FirstOrDefaultAsync();
                _dbContext.PatientInfos.Remove(result);
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