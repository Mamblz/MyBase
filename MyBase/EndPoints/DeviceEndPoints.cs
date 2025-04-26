using MyBase.Models;
namespace MyBase.EndPoints
{
    public static class DeviceEndPoints
    {
        public static IEndpointRouteBuilder MapCatEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/deviceslistlist", (Device DeviceServises) =>DeviceServises.GetDevice());

            return app;
        }

    }
}
