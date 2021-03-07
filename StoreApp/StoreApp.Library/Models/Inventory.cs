using System;
using System.Collections.Generic;

namespace StoreApp.Library.Models
{
  public class Inventory
  {
    private int _id;
    private int _storeId;
    // private Location _location();
    private int _productId;
    private int _quantity;

    public Inventory() { }

    public Inventory(int id, int storeId, int productId, int quantity)
    {
      Id = id;
      StoreId = storeId;
      ProductId = productId;
      Quantity = quantity;
    }
    public Inventory(int storeId, int productId, int quantity)
    {
      StoreId = storeId;
      ProductId = productId;
      Quantity = quantity;
    }
    public int Id
    {
      get => _id;
      set => _id = value;
    }
    public int StoreId
    {
      get => _storeId;
      set => _storeId = value;
    }

    public int ProductId
    {
      get => _productId;
      set => _productId = value;
    }

    public int Quantity
    {
      get => _quantity;
      set => _quantity = value;
    }
  }
}
