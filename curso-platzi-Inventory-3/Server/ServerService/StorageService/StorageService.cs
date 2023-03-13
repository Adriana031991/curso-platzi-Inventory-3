using curso_platzi_Inventory_3.Server.DataAccess;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;

namespace curso_platzi_Inventory_3.Server.ServerService.StorageService
{
	public class StorageService : IStorageService
	{

		private readonly InventaryContext _context;
		public StorageService(InventaryContext context)
		{
			_context = context;
		}

		public async Task<bool> Delete(string id)
		{
			var dbStorage = await _context.Storages.FindAsync(id);
			if (dbStorage == null)
			{
				return false;
			}

			_context.Remove(dbStorage);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<List<StorageEntity>> GetStorages()
		{
			return await _context.Storages.ToListAsync();
		}

		public async Task<StorageEntity?> GetStorageById(string storageId)
		{
			var dbStorage = await _context.Storages.FindAsync(storageId);
			if (dbStorage is not null)
			{
				Console.WriteLine("GetStorageById " + dbStorage);
				return dbStorage;
			}
				Console.WriteLine("GetStorageById " + dbStorage);
				return null;
		}

		public async Task<Dictionary<string,bool>> IsProductInWarehouse(string storageId)
		{
			var response = new Dictionary<string, bool>();

			var storages = await _context.Storages.ToListAsync();
			//var storage = (from s in storages where (s.StorageId == storageId) select s);
			var storage = storages.Where(s => s.StorageId == storageId);

			response.Add("IsProductInWarehouse", storage.Any());

			return response;
		}

		public async Task<StorageEntity?> Save(StorageEntity storage)
		{
			_context.Add(storage);
			await _context.SaveChangesAsync();
			return storage;
		}

		public async Task<List<StorageEntity?>> StorageListByWarehouse(string idWarehouse)
		{
			var storages = await _context.Storages.ToListAsync();
			//TODO: pendiente revisar

			var a = (from p in storages
					where p.WarehouseId == idWarehouse
					select p).ToList();
			foreach(var b in a)
			{

            Console.WriteLine("StorageListByWarehouse " + b.ToString());
			}

            return a;

			//return products
			//		.Include(s => s.Product)
			//		.Include(s => s.Warehouse)
			//		.Where(s => s.WarehouseId == idWarehouse)
			//		.ToList();
		}

		public async Task<StorageEntity?> Update(string id, StorageEntity storage)
		{
			var dbStorage = await _context.Storages.FindAsync(id);
			if (dbStorage != null)
			{
				dbStorage.LastUpdate = storage.LastUpdate;
				dbStorage.PartialQuantity = storage.PartialQuantity;
				dbStorage.ProductId = storage.ProductId;
				dbStorage.WarehouseId = storage.WarehouseId;
				dbStorage.InputOutputs = storage.InputOutputs;

				await _context.SaveChangesAsync();
			}

			return dbStorage;
		}
	}
}
