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
  public class LocationRepository// : ICustomerRepository
  {
    private readonly StoreProj0Context _locations;

    public LocationRepository(StoreProj0Context locations)
    {
      _locations = locations;
    }

    public IEnumerable<StoreApp.Library.Models.Location> GetLocations()
    {
      var query = _locations.Locations;
      if (query != null)
      {
        return query.Select(l => new StoreApp.Library.Models.Location
        {
          Id = l.Id,
          Code = l.Code,
          Address1 = l.Address1,
          Address2 = l.Address2,
          City = l.City,
          State = l.State
        }).ToList();
      }
      else
      {
        return new List<StoreApp.Library.Models.Location>();
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
      _locations.SaveChanges();
    }

  }
}
