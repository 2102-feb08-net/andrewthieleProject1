using System;
using System.Collections.Generic;

namespace StoreApp.Library.Models
{
  public class Product
  {
    private int _id;
    private string _name;
    private string _description;
    private decimal _price;

    public Product() { }

    public Product(int id, string name, string description, decimal price)
    {
      _id = id;
      _name = name;
      _description = description;
      _price = price;

    }
    public Product(string name, string description, decimal price)
    {
      _name = name;
      _description = description;
      _price = price;

    }

    public int Id
    {
      get => _id;
      set => _id = value;
    }

    public string Name
    {
      get => _name;
      set => _name = value;
    }

    public string Description
    {
      get => _description;
      set => _description = value;
    }

    public decimal Price
    {
      get => _price;
      set => _price = value;
    }
  }
}
