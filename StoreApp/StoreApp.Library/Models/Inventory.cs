using System;
using System.Collections.Generic;

namespace StoreApp.Library.Models
{
  public class Inventory
  {
    private int _id;
    private int _storeId;
    public Location _location;
    private int _productId;
    public Product _product;
    private int _quantity;

    public Inventory() { }

    public Inventory(Location location, Product product, int quantity)
    {
      Location = location;
      Product = product;
      Quantity = quantity;
    }

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

    public Location Location
    {
      get => _location;
      set => _location = value;
    }

    public int ProductId
    {
      get => _productId;
      set => _productId = value;
    }

    public Product Product
    {
      get => _product;
      set => _product = value;
    }

    public int Quantity
    {
      get => _quantity;
      set => _quantity = value;
    }
    /// <summary>
    /// Checks if item is in stock
    /// </summary>
    /// <returns>bool</returns>
    public bool ItemIsInStock()
    {
      return _quantity > 0;
    }
    /// <summary>
    /// Checks if item can be ordered
    /// </summary>
    /// <param name="demand"></param>
    /// <returns>bool</returns>
    public bool ItemCanBeFullFilledInOrder(int demand)
    {
      return demand <= _quantity;
    }
    /// <summary>
    /// Updates Quantity for a product
    /// </summary>
    /// <param name="purchased"></param>
    /// <returns></returns>
    public int UpdateQuantityOnProduct(int purchased)
    {
      return _quantity -= purchased;
    }
  }
}
