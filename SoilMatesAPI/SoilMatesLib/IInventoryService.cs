using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesLib
{
    public interface IInventoryService
    {
        void AddInventory(Inventory inventory);
        void AddItemToInventory(Location location, Product product, int quantity);
        List<Inventory> GetAllInventory();
        Inventory GetInventoryItem(int productId, int locationId);
        List<Inventory> GetInventoryItemByProductId(int id);
        List<Inventory> GetInvetoryItemByLocationId(int id);
        void RemoveInventoryItem(Inventory item);
        void SaveChanges();
        void SoldInventoryUpdate(Inventory item, int quantity);
        void UpdateQuantity(Inventory item, int quantity);
    }
}