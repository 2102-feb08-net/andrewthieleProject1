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
  /// <summary>
  /// Repository for all locations
  /// </summary>
  public class LocationRepository// : ICustomerRepository
  {
    private readonly StoreProj0Context _locations;

    public LocationRepository(StoreProj0Context locations)
    {
      _locations = locations;
    }
    /// <summary>
    /// Return all locations
    /// </summary>
    /// <returns></returns>
    public IEnumerable<StoreApp.Library.Models.Location> GetLocations()
    {
      return _locations.Locations
    // .Include(l => l.Address1)
    // .Include(l => l.Address2)
    // .Include(l => l.City)
    // .Include(l => l.State)
    // .Include(l => l.Code)
    .Select(l => new StoreApp.Library.Models.Location
    {
      Id = l.Id,
      Code = l.Code,
      Address1 = l.Address1,
      Address2 = l.Address2,
      City = l.City,
      State = l.State
    }).ToList();

    }


    public void Save()
    {
      _locations.SaveChanges();
    }

  }
}
