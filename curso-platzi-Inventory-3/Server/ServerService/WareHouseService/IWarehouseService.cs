using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Server.ServerService.WareHouseService
{
    public interface IWareHouseService
{
		Task<List<WarehouseEntity>> GetWarehouses();
		
		Task<WarehouseEntity?> Save(WarehouseEntity warehouse);
		Task<WarehouseEntity?> Update(string id, WarehouseEntity warehouse);
		Task<bool> Delete(string id);
	}
}
