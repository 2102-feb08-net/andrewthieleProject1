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

    public IEnumerable<StoreApp.Library.Models.Inventory> GetInventories()
    {
      var query = _inventories.Inventories;
      if (query != null)
      {
        return query.Select(i => new StoreApp.Library.Models.Inventory
        {
          Id = i.Id,
          StoreId = (int)i.LocationId,
          ProductId = (int)i.ProductId,
          Quantity = i.InStock
        }).ToList();
      }
      else
      {
        return new List<StoreApp.Library.Models.Inventory>();
      }
    }

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

    public StoreApp.Library.Models.Inventory GetInventoryByStoreIdAndByProductId(int storeId, int productId)
    {

      var inventory = _inventories.Inventories.Where(i => i.LocationId == storeId && i.ProductId == productId).First();

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

    public StoreApp.Library.Models.Inventory AdjustInventory(int storeId, int productId, int quantity)
    {
      var inventory = _inventories.Inventories.Where(i => i.LocationId == storeId && i.ProductId == productId).First();

      if (inventory != null)
      {
        return new StoreApp.Library.Models.Inventory
        {
          Id = inventory.Id,
          StoreId = (int)inventory.LocationId,
          ProductId = (int)inventory.ProductId,
          Quantity = quantity <= inventory.InStock ? inventory.InStock - quantity : inventory.InStock
        };
      }
      else
      {
        throw new Exception("Inventory does not exist");
      }
    }



    public void Save()
    {
      _inventories.SaveChanges();
    }

  }
}
