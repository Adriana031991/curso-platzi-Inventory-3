using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Client.Service.StorageService
{
	public interface IStorageService
	{
		List<StorageEntity> StoragesList { get; set; }
        Task GetStorages();
		Task<StorageEntity> GetStorageById(string storageId);
		Task<Dictionary<string, bool>> IsProductInWarehouse(string storageId);
		Task StorageListByWarehouse(string idWarehouse);
		Task Save(StorageEntity storage);
		Task Update(string id, StorageEntity storage);
		Task Delete(string id);
	}
}
