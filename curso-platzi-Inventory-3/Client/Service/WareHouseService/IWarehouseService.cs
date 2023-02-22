using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Client.Service.WareHouseService
{
    public interface IWareHouseService
{
		List<WarehouseEntity> WarehousesList { get; set; }
		Task GetWarehouses();
		Task Save(WarehouseEntity warehouse);
		Task Update(string id, WarehouseEntity warehouse);
		Task Delete(string id);
	}
}
