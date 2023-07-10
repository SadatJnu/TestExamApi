using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestExamApi.Data;
using TestExamApi.Entites;

namespace TestExamApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TEntity> : ControllerBase where TEntity : BaseModel
{
    private readonly IRepository<TEntity> repository;

    public BaseController(IRepository<TEntity> repository)
    {
        this.repository = repository;
    }

    //Get: api/controller
    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync()
    {
        try
        {
            return Ok(await repository.GetAll());
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError,
              "Error retrieving data from the database");
        }

    }

    //Get: api/controller/id
    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity>> GetAsync([FromRoute] int id)
    {
        try
        {

            var result = await repository.GetOne(id);
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

    //Delete: api/controller/id
    [HttpDelete("{id}")]
    public virtual async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            var entity = await repository.GetOne(id);
            if (entity == null)
            {
                return BadRequest();
            }
            else
            {
                await repository.Delete(id);
                return NoContent();
            }
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleteing record from the database");
        }


    }

    //Post: api/controller
    [HttpPost]
    public virtual async Task<ActionResult<TEntity>> CreateAsync([FromBody] TEntity entity)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await repository.Insert(entity);
                //return CreatedAtAction(nameof(GetAsync), new { id = entity.Id }, entity);
                return Ok(entity);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new  record");
        }
    }

    //Put: api/cotroller/id
    [HttpPut("{id}")]
    public virtual async Task<ActionResult<TEntity>> UpdateAsync([FromRoute] int id, [FromBody] TEntity entity)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != entity.ID)
            {
                return BadRequest();
            }
            var result = await repository.GetOne(entity.ID);
            if (result == null)
            {
                return NotFound("Record not found");
            }
            else
            {
                await repository.Update(entity);

            }
        }
        catch (DbUpdateConcurrencyException)
        {

        }
        catch (DbUpdateException)
        {

            return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error updating the record");
        }
        return NoContent();

    }
}
