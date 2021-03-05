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

    public Customer(string fname, string lname)
    {
      FirstName = fname;
      LastName = lname;
    }
    public Customer(string fname, string lname, decimal balance)
    {

      FirstName = fname;
      LastName = lname;
      Balance = balance;
    }
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
    public bool IsFirstNameOkay()
    {
      string forbbidenChars = "!@#$%^&*()";

      foreach (char i in _firstName)
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

    public bool IsLastNameOkay()
    {
      string forbbidenChars = "!@#$%^&*()";

      foreach (char i in _lastName)
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
