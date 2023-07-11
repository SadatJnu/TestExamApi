﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestExamApi.Data;
using TestExamApi.Entites;

namespace TestExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : BaseController<Allergies>
    {
        private readonly IRepository<Allergies> _repository;
        private readonly ApplicationDbContext _dbContext;
        
        public AllergiesController(IRepository<Allergies> repository, ApplicationDbContext dbContext) : base(repository)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public override async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var result = await _dbContext.Allergies.Where(e => e.ID == id).FirstOrDefaultAsync();
                _dbContext.Allergies.Remove(result);
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
