using curso_platzi_Inventory_3.Server.ServerService.WareHouseService;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace curso_platzi_Inventory_3.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Warehousecontroller : ControllerBase
	{

		private readonly IWareHouseService _warehouseService;

		public Warehousecontroller(IWareHouseService warehouseService)
		{
			_warehouseService = warehouseService;
		}


		[HttpGet]
		public async Task<List<WarehouseEntity>> Get()
		{
			return await _warehouseService.GetWarehouses();
		}

		
		[HttpPost]
		public async Task<WarehouseEntity?> CreateWarehouse(WarehouseEntity warehouseEntity)
		{
			return await _warehouseService.Save(warehouseEntity);
		}

		[HttpPut("{id}")]
		public async Task<WarehouseEntity?> UpdateWarehouse(string id, WarehouseEntity warehouseEntity)
		{
			return await _warehouseService.Update(id, warehouseEntity);
		}

		[HttpDelete("{id}")]
		public async Task<bool> DeleteWarehouse(string id)
		{
			return await _warehouseService.Delete(id);
		}
	}
}
