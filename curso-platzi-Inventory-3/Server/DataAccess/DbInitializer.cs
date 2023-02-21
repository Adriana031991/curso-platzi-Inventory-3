using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Server.DataAccess
{
	public static class DbInitializer
	{
		public static void Initialize(InventaryContext context)
		{
			if (context.Products.Any())
			{
				return;   // DB has been seeded
			}

			var products = new ProductEntity[]
			{
				new ProductEntity { ProductId = "ASJ-98745", ProductName = "Crema para manos marca Tersa", ProductDescription = "", CategoryId = "PRF" , TotalQuantity = 1},
				new ProductEntity { ProductId = "RPT-5465879", ProductName = "Pastillas para la garganta LESUS", ProductDescription = "", CategoryId = "SLD", TotalQuantity = 1 }

			};

			foreach (ProductEntity p in products)
			{
				context.Products.Add(p);
			}
			context.SaveChanges();

			var categories = new CategoryEntity[] {
				new CategoryEntity { CategoryId = "ASH", CategoryName = "Aseo Hogar" },
				new CategoryEntity { CategoryId = "ASP", CategoryName = "Aseo Personal" },
				new CategoryEntity { CategoryId = "HGR", CategoryName = "Hogar" },
				new CategoryEntity { CategoryId = "PRF", CategoryName = "Perfumería" },
				new CategoryEntity { CategoryId = "SLD", CategoryName = "Salud" },
				new CategoryEntity { CategoryId = "VDJ", CategoryName = "Video Juegos" }
			};

			foreach (CategoryEntity c in categories)
			{
				context.Categories.Add(c);
			}
			context.SaveChanges();

			var warehouses = new WarehouseEntity[] {
				new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Central", WarehouseAddress = "Calle 8 con 23" },
				new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Norte", WarehouseAddress = "Calle norte con occidente" }

			};

			foreach (WarehouseEntity w in warehouses)
			{
				context.Warehouses.Add(w);
			}
			context.SaveChanges();


			var storages = new StorageEntity[] {
				new StorageEntity { 
					ProductId = products.Single(i => i.ProductName.Contains("tersa")).ProductId, 
					StorageId = Guid.NewGuid().ToString(), 
					LastUpdate = DateTime.Now, 
					PartialQuantity = 1, 
					WarehouseId = warehouses.Single(i => i.WarehouseName.Contains("Central")).WarehouseId },
				
				new StorageEntity { 
					ProductId = products.Single(i => i.ProductName.Contains("garganta")).ProductId, 
					StorageId = Guid.NewGuid().ToString(), 
					LastUpdate = DateTime.Now, 
					PartialQuantity = 1, 
					WarehouseId = warehouses.Single(i => i.WarehouseName.Contains("Norte")).WarehouseId }
			};

			foreach (StorageEntity s in storages)
			{
				context.Storages.Add(s);
			}
			context.SaveChanges();

			var inouts = new InputOutputEntity[] {
				new InputOutputEntity
				{
					InOutId = Guid.NewGuid().ToString(),
					InOutDate= DateTime.Now,
					IsInput= true,
					Quantity= 1,
					StorageId = storages.Single(i=>i.Product.ProductName.Contains("garganta")).StorageId
				},
				new InputOutputEntity
				{
					InOutId = Guid.NewGuid().ToString(),
					InOutDate= DateTime.Now,
					IsInput= false,
					Quantity= 2,
					StorageId = storages.Single(i=>i.Product.ProductName.Contains("Tersa")).StorageId
				}
			};

			foreach (InputOutputEntity i in inouts)
			{
				context.InOuts.Add(i);
			}
			context.SaveChanges();

		}
	};
}
