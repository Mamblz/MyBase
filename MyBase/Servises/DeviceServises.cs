using MyBase.Repositories;
using Newtonsoft.Json;

namespace MyBase.Servises
{
    public class DeviceServises
    {
        readonly DeviceRepository repository;
        public DeviceServises(DeviceRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IResult> GetDevice() => Results.Text(JsonConvert.SerializeObject(await repository.GetDevice(),Formatting.Indented,new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
    }
}
