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
      set
      {
        if (CustomerHasOkayId(value) == true)
        {
          _id = value;
        }

      }
    }
    public string FirstName
    {
      get => _firstName;
      set
      {
        if (IsFirstNameOkay(value) == true)
        {
          _firstName = value;
        }
        else
        {
          _firstName = "DEFAULT";
        }

      }
    }

    public string LastName
    {
      get => _lastName;
      set
      {
        if (IsFirstNameOkay(value) == true)
        {
          _lastName = value;
        }
        else
        {
          _lastName = "DEFAULT";
        }

      }
    }
    public decimal Balance
    {
      get => _balance;
      set
      {
        if (value < 0)
        {
          _balance = 0;
        }
        else
        {
          _balance = value;
        }

      }
    }
    /// <summary>
    /// Check for valid first name
    /// </summary>
    /// <returns></returns>
    public bool IsFirstNameOkay(string name)
    {
      string forbbidenChars = "!@#$%^&*()";

      foreach (char i in name)
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
    /// <summary>
    /// check for valid last name
    /// </summary>
    /// <returns></returns>
    public bool IsLastNameOkay(string name)
    {
      string forbbidenChars = "!@#$%^&*()";

      foreach (char i in name)
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
    /// <summary>
    /// Check if customer owes money
    /// </summary>
    /// <returns></returns>

    public bool CustomerHasPositiveBalance()
    {
      return _balance > 0;
    }
    /// <summary>
    /// check is customer needs a refund
    /// </summary>
    /// <returns></returns>
    public bool CustomerHasNegativeBalance()
    {
      return _balance < 0;
    }

    public bool CustomerHasOkayId(int value)
    {
      return value > 0;
    }

  }
}
