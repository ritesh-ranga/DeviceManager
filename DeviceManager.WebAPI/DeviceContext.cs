using DeviceManager.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.WebAPI
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options)
           : base(options)
        {
        }

        public DbSet<Device> DeviceItems { get; set; }

    }
}
