
using System.ComponentModel.DataAnnotations;

namespace curso_platzi_Inventory_3.Shared.Entities
{
	public class InputOutputEntity
	{
		[Key]
		[StringLength(50)]
		public string InOutId { get; set; }


		[Required(ErrorMessage = "* El campo Fecha es obligatorio")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime InOutDate { get; set; }


		[Required(ErrorMessage = "* El campo Cantidad es obligatorio")]
		public int Quantity { get; set; }

		[Required]
		public bool IsInput { get; set; }


		//Relación con almacenamiento (StorageEntity)
		public string StorageId { get; set; }
		public StorageEntity Storage { get; set; }
	}
}
