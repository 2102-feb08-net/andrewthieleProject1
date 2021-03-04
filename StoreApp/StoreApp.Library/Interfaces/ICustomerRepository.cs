using System.Collections.Generic;
using StoreApp.Library.Models;

namespace StoreApp.Library.Interfaces
{
  public interface ICustomerRepository
  {
    /// <summary>
    /// Get all customers with deferred execution
    /// </summary>
    /// <returns>A collection of customers</returns>
    IEnumerable<Customer> GetCustomers();

    /// <summary>
    /// Get a customer by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The customer with that id</returns>
    Customer GetCustomerById(int id);
    /// <summary>
    /// Get a customer by full name
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <returns>customer with that name</returns>
    Customer GetCustomerByFullName(string firstName, string lastName);
    /// <summary>
    /// Add a customer
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="LastName"></param>
    void AddCustomer(Customer customer);

    /// <summary>
    /// Save any changes to customers to data source
    /// </summary>
    void Save();

  }
}
