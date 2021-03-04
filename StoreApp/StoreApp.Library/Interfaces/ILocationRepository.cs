using System.Collections.Generic;
using StoreApp.Library.Models;

namespace StoreApp.Library.Interfaces
{
  public interface ILocationRepository
  {
    /// <summary>
    /// Get all customers with deferred execution
    /// </summary>
    /// <returns>A collection of customers</returns>
    IEnumerable<Location> GetLocations();

    /// <summary>
    /// Get a customer by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The customer with that id</returns>
    void Save();

  }
}
