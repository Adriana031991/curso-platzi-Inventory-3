using curso_platzi_Inventory_3.Server.DataAccess;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace curso_platzi_Inventory_3.Server.ServerService.WareHouseService
{
    public class WarehouseService : IWareHouseService
	{

		private readonly InventaryContext _context;
		public WarehouseService(InventaryContext context)
		{
			_context = context;
		}

		public async Task<bool> Delete(string id)
		{
			var dbWarehouse = await _context.Warehouses.FindAsync(id);
			if (dbWarehouse == null)
			{
				return false;
			}

			_context.Remove(dbWarehouse);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<List<WarehouseEntity>> GetWarehouses()
		{
			return await _context.Warehouses.ToListAsync();
		}

		public async Task<WarehouseEntity?> Save(WarehouseEntity warehouse)
		{
			_context.Add(warehouse);
			await _context.SaveChangesAsync();
			return warehouse;
		}

		public async Task<WarehouseEntity?> Update(string id, WarehouseEntity warehouse)
		{
			var dbWarehouse = await _context.Warehouses.FindAsync(id);
			if (dbWarehouse != null)
			{
				dbWarehouse.WarehouseName = warehouse.WarehouseName;
				dbWarehouse.WarehouseAddress = warehouse.WarehouseAddress;
				dbWarehouse.Storages = warehouse.Storages;

				await _context.SaveChangesAsync();
			}

			return dbWarehouse;
		}
	}
}
