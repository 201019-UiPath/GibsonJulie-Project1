using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System.Collections.Generic;

namespace SoilMatesResources
{
    public interface IInventoryMapper
    {
        Inventory ParseInventory(InventoryResource inventory);
        InventoryResource ParseInventory(Inventory inventory);
        List<InventoryResource> ParseInventory(List<Inventory> inventory);
        List<Inventory> ParseInventory(List<InventoryResource> inventory);
    }
}
