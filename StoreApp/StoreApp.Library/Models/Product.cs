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
      Name = name;
      Description = description;
      Price = price;
    }

    public int Id
    {
      get => _id;
      set => _id = value;
    }

    public string Name
    {
      get => _name;
      set
      {
        if (ProductNameIsValid(value) == true)
        {
          _name = value;
        }
        else
        {
          _name = "PRODUCT NOT NAMED";
        }
      }
    }

    public string Description
    {
      get => _description;
      set => _description = value;
    }

    public decimal Price
    {
      get => _price;
      set
      {
        if (value >= 0)
        {
          _price = value;
        }
        else
        {
          _price = 0;
        }
      }
    }
    /// <summary>
    /// Check for error in price entry
    /// </summary>
    /// <returns></returns>
    public bool PriceIsNotNegative()
    {
      return _price >= 0M;
    }
    /// <summary>
    /// Check if price is greater than zero
    /// </summary>
    /// <returns></returns>
    public bool PriceIsGreaterThanZero()
    {
      return _price > 0M;
    }
    /// <summary>
    /// CHeck for empty descriptions
    /// </summary>
    /// <returns></returns>
    public bool DescriptionIsEmpty()
    {
      return _description.Length == 0;
    }
    /// <summary>
    /// Check for valid product name
    /// </summary>
    /// <returns></returns>
    public bool ProductNameIsValid(string productName)
    {
      string forbbidenChars = "!@#$%^&*()";

      foreach (char i in productName)
      {
        foreach (char j in forbbidenChars)
        {
          if (i == j)
          {
            return false;
          }
        }
      }
      return true;
    }
  }
}
