using System.ComponentModel.DataAnnotations;

namespace curso_platzi_Inventory_3.Shared.Entities
{
	public class ProductEntity
	{
		[Key]
		[StringLength(50)]
		public string ProductId { get; set; }

		[Required(ErrorMessage = "* El campo Nombre es obligatorio")]
		[StringLength(100)]
		[Display(Name = "Product Name")]
		public string ProductName { get; set; }

		[StringLength(600)]
		[Display(Name = "Product Description")]
		public string ProductDescription { get; set; }

		public int TotalQuantity { get; set; }


		//Relación con categorias (CategoriaEntity)
		public string? CategoryId { get; set; }
		public CategoryEntity? Category { get; set; }


		//Relación con almacen (storageEntity)
		public ICollection<StorageEntity>? Storages { get; set; }

		public override string ToString()
		{
			return "ProductId: " +ProductId+ " ProductName: " + ProductName + " ProductDescription: "+ ProductDescription +
				" CategoryId: "+ CategoryId+ " TotalQuantity: "+ TotalQuantity;
		}

	}
}
