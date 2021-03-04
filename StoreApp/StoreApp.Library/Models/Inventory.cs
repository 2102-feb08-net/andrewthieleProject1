using System;
using System.Collections.Generic;

namespace StoreApp.Library.Models
{
  public class Inventory
  {
    private int _id;
    private int _storeId;
    private string _product;
    private int _quantity;
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

    public string Product
    {
      get => _product;
      set => _product = value;
    }

    public int quantity
    {
      get => _quantity;
      set => _quantity = value;
    }
  }
}
