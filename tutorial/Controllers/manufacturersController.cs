using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tutorial.Database;
using tutorial.Model;
using Microsoft.EntityFrameworkCore;


namespace tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class manufacturersController : ControllerBase
    {
        private readonly DataDBcontext _dbContext;
        public manufacturersController(DataDBcontext DbContext)
        {
            _dbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<manufauturers>>> getManufacturers()
        {
            var manufacturers = await _dbContext.manufauturers.ToListAsync();

            if (manufacturers.Count == 0) 
            {
                return NotFound();
            }
            return Ok(manufacturers);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<manufauturers>>> getManufacturers(int id)
        {
            var manufacturers = await _dbContext.manufauturers.FindAsync(id);

            if (manufacturers == null)
            {
                return NotFound();
            }
            return Ok(manufacturers);
        }

        [HttpPost]
        public async Task<ActionResult<manufauturers>> postManufacturers(manufauturers manufauturers)
        {
            try 
            {
                _dbContext.manufauturers.Add(manufauturers);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            { return BadRequest(); }

            return Ok(manufauturers);
        }

        [HttpPut]
        public async Task<ActionResult<manufauturers>> putManufacturers(int id, manufauturers newmanufauturers)
        {
            var manufacturer = await _dbContext.manufauturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            manufacturer.id = newmanufauturers.id;
            manufacturer.title = newmanufauturers.title;
            await _dbContext.SaveChangesAsync();

            return Ok(manufacturer);
        }

        [HttpDelete]
        public async Task<ActionResult<manufauturers>> deleteManufacturers(int id)
        {
            var manufacturer = await _dbContext.manufauturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _dbContext.manufauturers.Remove(manufacturer);
            await _dbContext.SaveChangesAsync();

            return Ok(manufacturer);
        }
    }
}
