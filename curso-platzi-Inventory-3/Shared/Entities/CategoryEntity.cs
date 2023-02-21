using System.ComponentModel.DataAnnotations;

namespace curso_platzi_Inventory_3.Shared.Entities
{

    public class CategoryEntity
    {
		public CategoryEntity()
		{
		}

		[Key]
        [StringLength(50)]
        public string CategoryId { get; set; }

        [Required(ErrorMessage ="* El campo Nombre es obligatorio")]
        [StringLength(100)]
		[Display(Name = "Category Name")]
		public string CategoryName { get; set; }

        //Relación con produtos (ProductEntity)
        public ICollection<ProductEntity>? Products { get; set; }

		public CategoryEntity(string categoryId, string categoryName, ICollection<ProductEntity>? products)
		{
			CategoryId = categoryId;
			CategoryName = categoryName;
			Products = products;
		}


		public override string ToString()
		{
			return $"categoria: {CategoryId}, nombre:{CategoryName}, Products: {Products} ";
		}

	}

}

