using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cursoplatziInventory3.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { "ASH", "Aseo Hogar" },
                    { "ASP", "Aseo Personal" },
                    { "HGR", "Hogar" },
                    { "PRF", "Perfumería" },
                    { "SLD", "Salud" },
                    { "VDJ", "Video Juegos" }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "WarehouseId", "WarehouseAddress", "WarehouseName" },
                values: new object[,]
                {
                    { "WH-1", "Calle 8 con 23", "Bodega Central" },
                    { "WH-2", "Calle norte con occidente", "Bodega Norte" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "ProductDescription", "ProductName", "TotalQuantity" },
                values: new object[,]
                {
                    { "ASJ-98745", "PRF", "", "Crema para manos marca Tersa", 0 },
                    { "RPT-5465879", "SLD", "", "Pastillas para la garganta LESUS", 0 }
                });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "StorageId", "LastUpdate", "PartialQuantity", "ProductId", "WarehouseId" },
                values: new object[,]
                {
                    { "S-1", new DateTime(2023, 2, 21, 12, 5, 42, 146, DateTimeKind.Local).AddTicks(2448), 1, "ASJ-98745", "WH-1" },
                    { "S-2", new DateTime(2023, 2, 21, 12, 5, 42, 146, DateTimeKind.Local).AddTicks(2467), 1, "RPT-5465879", "WH-2" }
                });

            migrationBuilder.InsertData(
                table: "InOut",
                columns: new[] { "InOutId", "InOutDate", "IsInput", "Quantity", "StorageId" },
                values: new object[,]
                {
                    { "IO-1", new DateTime(2023, 2, 21, 12, 5, 42, 146, DateTimeKind.Local).AddTicks(2480), true, 1, "S-1" },
                    { "IO-2", new DateTime(2023, 2, 21, 12, 5, 42, 146, DateTimeKind.Local).AddTicks(2483), false, 2, "S-2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "ASH");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "ASP");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "HGR");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "VDJ");

            migrationBuilder.DeleteData(
                table: "InOut",
                keyColumn: "InOutId",
                keyValue: "IO-1");

            migrationBuilder.DeleteData(
                table: "InOut",
                keyColumn: "InOutId",
                keyValue: "IO-2");

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "StorageId",
                keyValue: "S-1");

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "StorageId",
                keyValue: "S-2");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "ASJ-98745");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: "RPT-5465879");

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "WarehouseId",
                keyValue: "WH-1");

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "WarehouseId",
                keyValue: "WH-2");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "PRF");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "SLD");
        }
    }
}
