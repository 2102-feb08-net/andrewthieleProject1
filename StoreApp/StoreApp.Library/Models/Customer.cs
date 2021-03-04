using System;
using System.Collections.Generic;

namespace StoreApp.Library.Models
{
  public class Customer
  {
    private int _id;
    private string _firstName;
    private string _lastName;

    private decimal _balance;

    public Customer() { }

    public Customer(int id, string fname, string lname, decimal balance)
    {
      Id = id;
      FirstName = fname;
      LastName = lname;
      Balance = balance;
    }
    public int Id
    {
      get => _id;
      set => _id = value;
    }
    public string FirstName
    {
      get => _firstName;
      set => _firstName = value;
    }

    public string LastName
    {
      get => _lastName;
      set => _lastName = value;
    }
    public decimal Balance
    {
      get => _balance;
      set => _balance = value;
    }
  }
}
