using System;

namespace StoreApp.Library.Models
{
  public class Orderline
  {
    private int _id;
    private int _orderId;
    private int _productId;
    private int _quantity;

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

  }
}
