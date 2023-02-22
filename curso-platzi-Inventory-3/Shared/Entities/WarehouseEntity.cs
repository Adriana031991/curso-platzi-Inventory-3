
using System.ComponentModel.DataAnnotations;

namespace curso_platzi_Inventory_3.Shared.Entities
{
	public class WarehouseEntity
	{
		[Key]
		[StringLength(50)]
		public string WarehouseId { get; set; }

		[Required(ErrorMessage = "* El campo Nombre es obligatorio")]

		[StringLength(100)]
		public string? WarehouseName { get; set; }

		[Required]
		[StringLength(100)]
		public string WarehouseAddress { get; set; }


		//Relación con almacenamiento (StorageEntity)
		public ICollection<StorageEntity> Storages { get; set; }


        public override string ToString()
        {
            return "WarehouseId: " + WarehouseId + " WarehouseName: " + WarehouseName + " WarehouseAddress: " + WarehouseAddress +
                " Storages: " + Storages ;
        }
    }
}
