using curso_platzi_Inventory_3.Server.ServerService.StorageService;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace curso_platzi_Inventory_3.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StorageController : ControllerBase
	{

		private readonly IStorageService _storageService;

		public StorageController(IStorageService storageService)
		{
			_storageService = storageService;
		}


		[HttpGet]
		public async Task<List<StorageEntity>> GetStorages()
		{
			return await _storageService.GetStorages();
		}


		[HttpPost]
		public async Task<StorageEntity?> CreateStorage(StorageEntity storageEntity)
		{
			return await _storageService.Save(storageEntity);
		}

		[HttpPut("{id}")]
		public async Task<StorageEntity?> UpdateStorage(string id, StorageEntity storageEntity)
		{
			return await _storageService.Update(id, storageEntity);
		}

		[HttpDelete("{id}")]
		public async Task<bool> DeleteStorage(string id)
		{
			return await _storageService.Delete(id);
		}

        [HttpGet("{id}")]
        public async Task<StorageEntity?> GetStorageById(string id)
        {
            return await _storageService.GetStorageById(id);
        }

        [HttpGet("isproductinwarehouse/{id}")]
		public async Task<Dictionary<string, bool>> IsProductInWarehouse(string id)
		{
			return await _storageService.IsProductInWarehouse(id);
		}


		[HttpGet("storagelistbywarehouse/{id}")]
		public async Task<List<StorageEntity?>> StorageListByWarehouse(string id)
		{
			return await _storageService.StorageListByWarehouse(id);
		}

	}
}
