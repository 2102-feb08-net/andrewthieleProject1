using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Library.Models;
using StoreApp.DbAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Library.Interfaces;
using StoreApp.DbAccess.Repositories;
using System.Net.Http;
using System.Net;

namespace StoreApp.WebUI.Controllers
{
  [ApiController]
  public class InventoryController : ControllerBase
  {
    private readonly InventoryRepository _inventoryRepository;

    public InventoryController(InventoryRepository inventoryRepository)
    {
      _inventoryRepository = inventoryRepository;
    }

    [HttpGet("api/inventories")]
    public IEnumerable<StoreApp.Library.Models.Inventory> GetInventories()
    {
      return _inventoryRepository.GetInventories();
    }

    [HttpPost("api/adjust/inventory")]
    public void AdjustInventory(int storeId, int productId, int quantity )
    {
      _inventoryRepository.AdjustInventory(storeId, productId, quantity);
      _inventoryRepository.Save();
    }

  }
}