using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Server.ServerService.StorageService
{
    public interface IStorageService
{
		Task<List<StorageEntity>> GetStorages();
		Task<StorageEntity?> GetStorageById(string storageId);
		Task<Dictionary<string, bool>>  IsProductInWarehouse(string storageId);
		Task<List<StorageEntity?>> StorageListByWarehouse(string idWarehouse);
		Task<StorageEntity?> Save(StorageEntity storage);
		Task<StorageEntity?> Update(string id, StorageEntity storage);
		Task<bool> Delete(string id);
	}
}
