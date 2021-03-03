﻿using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess.Entities
{
  public partial class Customer
  {
    public Customer()
    {
      Orders = new HashSet<Order>();
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Balance { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
  }
}
