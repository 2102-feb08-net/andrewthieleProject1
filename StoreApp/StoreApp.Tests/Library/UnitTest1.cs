using System;
using Xunit;
using StoreApp.Library.Models;

namespace StoreApp.Tests
{
  public class CustomerFirstNameOkay
  {
    [Fact]
    public void CustomerFirstName_DoesNotInvalidChars_ReturnTrue()
    {
      // arrange
      var customer = new Customer(0, "Bob", "Smith", 100.00M);

      // act
      bool isNameOkay = customer.IsFirstNameOkay();
      // assert
      Assert.True(isNameOkay);
    }
  }


}
