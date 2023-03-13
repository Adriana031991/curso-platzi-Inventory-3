using curso_platzi_Inventory_3.Server.DataAccess;
using curso_platzi_Inventory_3.Server.ServerService.ProductService;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests
{
	//[TestFixture]
	public class TestsProductService
	{
		Mock<IProductService> _IproductService;
		Mock<InventaryContext> _inventaryContext;
		Mock<DbSet<ProductEntity>> _mockDbSet;
		private ProductService _productService;
		private ProductEntity _product;



		[SetUp]
		public void Setup()
		{
			var data = new List<ProductEntity>
			{
				new ProductEntity {
					ProductId = "ASJ-98745",
					ProductName = "Crema para manos marca Tersa",
					ProductDescription = "",
					CategoryId = "PRF" },

				new ProductEntity {
					ProductId = "RPT-5465879",
					ProductName = "Pastillas para la garganta LESUS",
					ProductDescription = "",
					CategoryId = "SLD" },
				};


		_mockDbSet = new Mock<DbSet<ProductEntity>>();
			_inventaryContext = new Mock<InventaryContext>();
			_inventaryContext.Setup(x => x.Products).Returns(_mockDbSet.Object);
			
			_IproductService = new Mock<IProductService>();
			_productService = new ProductService(_inventaryContext.Object);

	}
	//private IServiceProvider CreateContext(string nameDB)
	//{
	//	var services = new ServiceCollection();

	//	services.AddDbContext<InventaryContext>(opt => opt.UseInMemoryDatabase(databaseName: nameDB),
	//		ServiceLifetime.Scoped,
	//		ServiceLifetime.Scoped);

	//	return services.BuildServiceProvider();
	//}

	[Test]
	public async Task TestGetProducts()
		{
			var products = await _productService.GetProducts();



			//_mockDbSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(data.Provider);
			//_mockDbSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
			//_mockDbSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);

			//_mockDbSet.Verify(m => m.Add(It.IsAny<ProductEntity>()), Times.Once());
			//_inventaryContext.Verify(m => m.SaveChanges(), Times.Once());

		}
}
}
