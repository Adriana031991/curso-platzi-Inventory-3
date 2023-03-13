

using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client.Extensions.Msal;

namespace curso_platzi_Inventory_3.Server.DataAccess
{
	public class InventaryContext : DbContext
	{
		public InventaryContext()
		{
		}

		public InventaryContext(DbContextOptions<InventaryContext> options) : base(options)
		{
		}

		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<InputOutputEntity> InOuts { get; set; }
		public DbSet<WarehouseEntity> Warehouses { get; set; }
		public DbSet<StorageEntity> Storages { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options.UseSqlServer("Server=PSOFKA0475;Database=InvetoryDb;Integrated Security=true;TrustServerCertificate=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ProductEntity>().ToTable("Product");
			modelBuilder.Entity<CategoryEntity>().ToTable("Category");
			modelBuilder.Entity<InputOutputEntity>().ToTable("InOut");
			modelBuilder.Entity<WarehouseEntity>().ToTable("Warehouse");
			modelBuilder.Entity<StorageEntity>().ToTable("Storage");

			//semillas no son mock
			modelBuilder.Entity<CategoryEntity>().HasData(
				new CategoryEntity { CategoryId = "ASH", CategoryName = "Aseo Hogar" },
				new CategoryEntity { CategoryId = "ASP", CategoryName = "Aseo Personal" },
				new CategoryEntity { CategoryId = "HGR", CategoryName = "Hogar" },
				new CategoryEntity { CategoryId = "PRF", CategoryName = "Perfumería" },
				new CategoryEntity { CategoryId = "SLD", CategoryName = "Salud" },
				new CategoryEntity { CategoryId = "VDJ", CategoryName = "Video Juegos" }
				);

			modelBuilder.Entity<WarehouseEntity>().HasData(
				new WarehouseEntity { 
					WarehouseId = "WH-1", 
					WarehouseName = "Bodega Central", 
					WarehouseAddress = "Calle 8 con 23" },

				new WarehouseEntity { 
					WarehouseId = "WH-2", 
					WarehouseName = "Bodega Norte", 
					WarehouseAddress = "Calle norte con occidente" }
				);

			modelBuilder.Entity<ProductEntity>().HasData(
				new ProductEntity { 
					ProductId = "ASJ-98745", 
					ProductName = "Crema para manos marca Tersa", 
					ProductDescription = "", 
					CategoryId = "PRF" },

				new ProductEntity { 
					ProductId = "RPT-5465879", 
					ProductName = "Pastillas para la garganta LESUS", 
					ProductDescription = "", 
					CategoryId = "SLD" }
				);


			modelBuilder.Entity<StorageEntity>().HasData(
				new StorageEntity
				{
					ProductId = "ASJ-98745",
					StorageId = "S-1",
					LastUpdate = DateTime.Now,
					PartialQuantity = 1,
					WarehouseId = "WH-1"
				},

				new StorageEntity
				{
					ProductId = "RPT-5465879",
					StorageId = "S-2",
					LastUpdate = DateTime.Now,
					PartialQuantity = 1,
					WarehouseId = "WH-2"
				}
				);
			
			modelBuilder.Entity<InputOutputEntity>().HasData(
				new InputOutputEntity
				{
					InOutId = "IO-1",
					InOutDate = DateTime.Now,
					IsInput = true,
					Quantity = 1,
					StorageId = "S-1"
				},
				new InputOutputEntity
				{
					InOutId = "IO-2",
					InOutDate = DateTime.Now,
					IsInput = false,
					Quantity = 2,
					StorageId = "S-2"
				}
				);

		}


	}
}
