using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Library.Interfaces;
using StoreApp.Library.Models;
using StoreApp.DbAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.DbAccess.Repositories
{
  public class InventoryRepository// : ILocationRepository
  {
    private readonly StoreProj0Context _inventories;

    public InventoryRepository(StoreProj0Context inventories)
    {
      _inventories = inventories;
    }
    /// <summary>
    /// returns all inventories
    /// </summary>
    /// <returns></returns>
    public List<StoreApp.Library.Models.Inventory> GetInventories()
    {
      var query = _inventories.Inventories;

      return query
      .Include(i => i.Product)
      .Include(i => i.Location)
      .Select(i => new StoreApp.Library.Models.Inventory
      {
        StoreId = (int)i.LocationId,
        ProductId = (int)i.ProductId,
        Quantity = i.InStock
      }).ToList();

    }
    /// <summary>
    /// Gets an inventory by it's id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public StoreApp.Library.Models.Inventory GetInventoryById(int id)
    {
      var inventory = _inventories.Inventories.Find(id);
      if (inventory != null)
      {
        return new Library.Models.Inventory
        {
          Id = inventory.Id,
          StoreId = (int)inventory.LocationId,
          ProductId = (int)inventory.ProductId,
          Quantity = inventory.InStock
        };
      }
      else
      {
        throw new Exception("Inventory does not exist");
      }
    }
    /// <summary>
    /// Gets Inventory of store with respect to it's product
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="productId"></param>
    /// <returns></returns>
    public StoreApp.Library.Models.Inventory GetInventoryByStoreIdAndByProductId(int storeId, int productId)
    {

      var inventory = _inventories.Inventories.Single(i => i.LocationId == storeId && i.ProductId == productId);

      if (inventory != null)
      {
        return new StoreApp.Library.Models.Inventory
        {
          Id = inventory.Id,
          StoreId = (int)inventory.LocationId,
          ProductId = (int)inventory.ProductId,
          Quantity = inventory.InStock
        };
      }
      else
      {
        throw new Exception("Inventory does not exist");
      }
    }
    /// <summary>
    /// Adjusts Inventory to a store
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    public void AdjustInventory(int storeId, int productId, int quantity)
    {
      var inventory = _inventories.Inventories.Single(i => i.LocationId == storeId && i.ProductId == productId);

      if (inventory != null)
      {
        inventory.InStock = quantity <= inventory.InStock ? inventory.InStock - quantity : inventory.InStock;
      }
      else
      {
        throw new Exception("Inventory does not exist");
      }
    }

    /// <summary>
    /// Saves changes to repo
    /// </summary>

    public void Save()
    {
      _inventories.SaveChanges();
    }

  }
}
