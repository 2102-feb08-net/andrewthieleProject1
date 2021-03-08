using System;
using Xunit;
using StoreApp.Library.Models;

namespace StoreApp.Tests
{
  public class CustomerFirstNameOkay
  {
    [Fact]
    public void CustomerFirstName_DoesNotHaveInvalidChars_ReturnTrue()
    {
      // arrange
      var customer = new Customer(0, "Bob", "Smith", 100.00M);

      // act
      bool isNameOkay = customer.IsFirstNameOkay("Bob");
      // assert
      Assert.True(isNameOkay);
    }
  }

  public class CustomerFirstNameNotOkay
  {
    [Fact]
    public void CustomerFirstName_DoesHave_InvalidChars_ReturnTrue()
    {
      // arrange
      var customer = new Customer(0, "B@b", "Smith", 100.00M);

      // act
      bool isNameOkay = customer.IsFirstNameOkay("B@b");
      // assert
      Assert.False(isNameOkay);
    }
  }
  public class CustomerLastNameOkay
  {
    [Fact]
    public void CustomerLastName_DoesNotInvalidChars_ReturnTrue()
    {
      // arrange
      var customer = new Customer(0, "Bob", "Smith", 100.00M);

      // act
      bool isNameOkay = customer.IsLastNameOkay("Smith");
      // assert
      Assert.True(isNameOkay);
    }
  }

  public class CustomerLastNameNotOkay
  {
    [Fact]
    public void CustomerLastName_DoesHave_InvalidChars_ReturnTrue()
    {
      // arrange
      var customer = new Customer(0, "Bob", "Sm!th", 100.00M);

      // act
      bool isNameOkay = customer.IsLastNameOkay("Sm!th");
      // assert
      Assert.False(isNameOkay);
    }
  }

  public class OrderHasValidId
  {
    [Fact]
    public void Order_Has_ValidId_ReturnTrue()
    {
      // arrrange
      var order = new Order(1, 1, DateTimeOffset.Now, 1);
      //act
      bool isOrderIdValid = order.HasValidOrderId();
      //assert
      Assert.True(isOrderIdValid);
    }
    [Fact]
    public void Order_Has_ValidId_ReturnFalse()
    {
      // arrrange
      var order = new Order(0, 1, DateTimeOffset.Now, 1);
      //act
      bool isOrderIdValid = order.HasValidOrderId();
      //assert
      Assert.False(isOrderIdValid);
    }
  }

  public class OrderHasInvalidId
  {
    [Fact]
    public void Order_Has_InvalidId_ReturnTrue()
    {
      // arrrange
      var order = new Order(0, 1, DateTimeOffset.Now, 1);
      //act
      bool isOrderIdValid = !order.HasValidOrderId();
      //assert
      Assert.True(isOrderIdValid);
    }
    [Fact]
    public void Order_Has_InvalidId_ReturnFalse()
    {
      // arrrange
      var order = new Order(1, 1, DateTimeOffset.Now, 1);
      //act
      bool isOrderIdValid = !order.HasValidOrderId();
      //assert
      Assert.False(isOrderIdValid);

    }
  }
  public class OrderHasValidCustomerId
  {
    [Fact]
    public void Order_Has_ValidCustomerId_ReturnTrue()
    {
      // arrrange
      var order = new Order(1, 1, DateTimeOffset.Now, 1);
      //act
      bool isOrderIdValid = order.HasValidCustomerId();
      //assert
      Assert.True(isOrderIdValid);
    }
    [Fact]
    public void Order_Has_ValidCustomerId_ReturnFalse()
    {
      // arrrange
      var order = new Order(1, 0, DateTimeOffset.Now, 1);
      //act
      bool isOrderIdValid = order.HasValidCustomerId();
      //assert
      Assert.False(isOrderIdValid);
    }
  }

  public class OrderHasInvalidCustomerId
  {
    [Fact]
    public void Order_Has_InvalidCustomerId_ReturnTrue()
    {
      // arrrange
      var order = new Order(1, 0, DateTimeOffset.Now, 1);
      //act
      bool isOrderIdValid = !order.HasValidCustomerId();
      //assert
      Assert.True(isOrderIdValid);
    }
    [Fact]
    public void Order_Has_InvalidCustomerId_ReturnFalse()
    {
      // arrrange
      var order = new Order(1, 1, DateTimeOffset.Now, 1);
      //act
      bool isOrderIdValid = !order.HasValidCustomerId();
      //assert
      Assert.False(isOrderIdValid);

    }
  }




}
