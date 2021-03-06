﻿using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesLib
{
    /// <summary>
    /// Inventory interface for inventory services
    /// </summary>
    public interface IInventoryService
    {
        void AddInventory(Inventory inventory);
        void AddItemToInventory(Location location, Product product, int quantity);

        void AddItemToInventory(int locationId, int productId, int quantity);
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