using System;

namespace StoreApp.Library.Models
{
  public class Orderline
  {
    private int _id;
    private int _orderId;

    private Order _order;
    private int _productId;
    private Product _product;

    private int _quantity;

    public Orderline() { }

    public Orderline(Order order, Product product, int quantity)
    {
      Order = order;
      Product = product;
      Quantity = quantity;
    }


    public int Id
    {
      get => _id;
      set => _id = value;
    }

    public int OrderId
    {
      get => _orderId;
      set => _orderId = value;
    }

    public Order Order
    {
      get => _order;
      set => _order = value;
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
      set
      {
        if (value >= 0)
        {
          _quantity = value;
        }
        else
        {
          _quantity = 0;
        }
      }
    }
    /// <summary>
    /// Adjust quantity of order
    /// </summary>
    /// <param name="howMuchBought"></param>
    public void AdjustQuantity(int howMuchBought)
    {
      if (howMuchBought <= _quantity)
      {
        _quantity -= howMuchBought;
      }
      else
      {
        _quantity -= 0;
      }
    }
    /// <summary>
    /// Check for valid Orderline id in database
    /// </summary>
    /// <returns></returns>
    public bool OrderlineHasValidId()
    {
      return _id > 0;
    }
    /// <summary>
    /// Check if Orderline has valid orderId
    /// </summary>
    /// <returns></returns>
    public bool OrderlineHasValidOrderId()
    {
      return _orderId > 0;
    }
    /// <summary>
    /// check if orderline has a valid productId
    /// </summary>
    /// <returns></returns>
    public bool OrderlineHasValidProductId()
    {
      return _productId > 0;
    }
  }
}
