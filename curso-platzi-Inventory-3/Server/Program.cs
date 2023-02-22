using curso_platzi_Inventory_3.Server.DataAccess;
using curso_platzi_Inventory_3.Server.ServerService.CategoryService;
using curso_platzi_Inventory_3.Server.ServerService.InputOutputService;
using curso_platzi_Inventory_3.Server.ServerService.ProductService;
using curso_platzi_Inventory_3.Server.ServerService.StorageService;
using curso_platzi_Inventory_3.Server.ServerService.WareHouseService;
using Microsoft.AspNetCore.ResponseCompression;

namespace curso_platzi_Inventory_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
			builder.Services.AddDbContext<InventaryContext>();
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IInputOutputService, InputOutputService>();
			builder.Services.AddScoped<IStorageService, StorageService>();
			builder.Services.AddScoped<IWareHouseService, WarehouseService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}