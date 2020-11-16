using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System.Collections.Generic;

namespace SoilMatesResources
{
    /// <summary>
    /// Maps between inventory resource and data model
    /// </summary>
    public interface IInventoryMapper
    {
        Inventory ParseInventory(InventoryResource inventory);
        InventoryResource ParseInventory(Inventory inventory);
        List<InventoryResource> ParseInventory(List<Inventory> inventory);
        List<Inventory> ParseInventory(List<InventoryResource> inventory);
    }
}
