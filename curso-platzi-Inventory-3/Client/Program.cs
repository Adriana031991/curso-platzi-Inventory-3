using curso_platzi_Inventory_3.Client;
using curso_platzi_Inventory_3.Client.Service.CategoryService;
using curso_platzi_Inventory_3.Client.Service.InputOutputService;
using curso_platzi_Inventory_3.Client.Service.ProductService;
using curso_platzi_Inventory_3.Client.Service.StorageService;
using curso_platzi_Inventory_3.Client.Service.WareHouseService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace curso_platzi_Inventory_3.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IWareHouseService, WarehouseService >();
			builder.Services.AddScoped<IStorageService, StorageService>();
			builder.Services.AddScoped<IInputOutputService, InputOutputService>();

			await builder.Build().RunAsync();
        }
    }
}