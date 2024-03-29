﻿
using System.ComponentModel.DataAnnotations;

namespace curso_platzi_Inventory_3.Shared.Entities
{
    public class StorageEntity
{
    [Key]
    [StringLength(50)]
    public string StorageId { get; set; }

    [Required]
    public DateTime LastUpdate { get; set; }

    [Required]
    public int PartialQuantity { get; set; }


    //Relación con produtos (ProductEntity)
    public string ProductId { get; set; }
    public ProductEntity? Product { get; set; }


    //Relacion con bodegas (WherehouseEntity)
    public string WarehouseId { get; set; }
    public WarehouseEntity? Warehouse { get; set; }


    //Relación con movimientos (InputOutputEntity)
    public IEnumerable<InputOutputEntity>? InputOutputs { get; set; }

        public override string ToString()
        {
            return "StorageId: " + StorageId + " LastUpdate: " + LastUpdate + " PartialQuantity: " + PartialQuantity +
                " ProductId: " + ProductId + " WarehouseId: " + WarehouseId;
        }

    }
}
