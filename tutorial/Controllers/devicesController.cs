using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tutorial.Database;
using tutorial.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class devicesController : ControllerBase
    {
        private readonly DataDBcontext _dbContext;
        public devicesController(DataDBcontext DbContext)
        {
            _dbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<devices>>> getDevices()
        {
            var devices = await _dbContext.devices.ToListAsync();

            if (devices.Count == 0)
            {
                return NotFound();
            }
            return Ok(devices);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<devices>>> getDevices(int id)
        {
            var devices = await _dbContext.devices.FindAsync(id);

            if (devices == null)
            {
                return NotFound();
            }
            return Ok(devices);
        }

        [HttpPut]
        public async Task<ActionResult<devices>> putDevices(int id, devices newdevices)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            devices.id = newdevices.id;
            //devices.title = newdevices.title;
            await _dbContext.SaveChangesAsync();

            return Ok(devices);
        }

        [HttpPost]
        public async Task<ActionResult<devices>> postDevices(devices devices)
        {
            try
            {
                _dbContext.devices.Add(devices);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            { return BadRequest(); }

            return Ok(devices);
        }

        [HttpDelete]
        public async Task<ActionResult<devices>> deleteDevices(int id)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            _dbContext.devices.Remove(devices);
            await _dbContext.SaveChangesAsync();

            return Ok(devices);
        }

        [HttpGet("manufacturer/{id}")]
        public async Task<ActionResult<List<devices>>> getDevicesByManuFactureID(int id)
        {
            var devices = await _dbContext.devices.Where(e=>e.manufacturer_id==id).ToListAsync();
            if(devices.Count == 0)
            {
                return NotFound();
            }
            return Ok(devices);
        }
    }
}
