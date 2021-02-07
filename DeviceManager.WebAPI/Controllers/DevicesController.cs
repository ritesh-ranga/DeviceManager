using DeviceManager.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DevicesController : Controller
    {
        private readonly DeviceContext _context;

        public DevicesController(DeviceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDeviceItems()
        {
            return await _context.DeviceItems.ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.DeviceItems.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/Devices/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutDevice(int id, Device device)
        {
            bool result = false;

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return result;
        }

        // POST: api/Devices
        [HttpPost]
        public async Task<ActionResult<bool>> PostDevice(Device device)
        {
            bool result = false;

            int maxID = _context.DeviceItems.Max(x => x.id);
            device.id = maxID + 1;

            try
            {
                _context.DeviceItems.Add(device);
                await _context.SaveChangesAsync();

                result = true;
            }
            catch (Exception)
            {
            }

            return result;
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteDevice(int id)
        {
            bool result = false;

            var device = await _context.DeviceItems.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            try
            {
                _context.DeviceItems.Remove(device);
                await _context.SaveChangesAsync();

                result = true;
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
