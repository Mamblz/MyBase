using System.Data;
using Microsoft.EntityFrameworkCore;
using MyBase.Models;

namespace MyBase.Repositories
{
    public class DeviceRepository : BaseRepository
    {
        public DeviceRepository(KobzarContext testContext) : base(testContext) { }

        public async Task<List<Device>> GetDevice() => await testContext.Devices.Include(x => x.CustomerId).Include(x => x.DeviceType).Include(x => x.BrandId).ToListAsync();
    }
}

