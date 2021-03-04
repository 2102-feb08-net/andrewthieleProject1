using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Library.Interfaces;
using StoreApp.Library.Models;
using StoreApp.DbAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.DbAccess.Repositories
{
  public class ProductRepository// : IProductRepository
  {
    private readonly StoreProj0Context _customers;

    public ProductRepository(StoreProj0Context customers)
    {
      _customers = customers;
    }

    public IEnumerable<StoreApp.Library.Models.Product> GetProducts()
    {
      var query = _customers.Products;
      if (query != null)
      {
        return query.Select(c => new StoreApp.Library.Models.Product
        {
          Id = c.Id,
          Name = c.Name,
          Description = c.Description,
          Price = (decimal)c.Price
        }).ToList();
      }
      else
      {
        return new List<StoreApp.Library.Models.Product>();
      }
    }

    // public StoreApp.Library.Models.Customer GetCustomerById(int id)
    // {
    //   return
    // }
    // public StoreApp.Library.Models.Customer GetCustomerByFullName(string firstName, string lastName)
    // {
    //   return new StoreApp.Library.Models.Customer(firstName, lastName);
    // }

    // public void AddCustomer(string firstName, string LastName)
    // {
    //   _customers.Add();
    // }

    public void Save()
    {
      _customers.SaveChanges();
    }

  }
}
