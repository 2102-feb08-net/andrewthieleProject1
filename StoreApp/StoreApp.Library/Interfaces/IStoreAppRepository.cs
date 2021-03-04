// using System.Collections.Generic;
// using StoreApp.Library.Models;

// namespace StoreApp.Library.Interfaces
// {
//   public interface IStoreAppRepository
//   {

//     // ? CUSTOMER STUFF
//     /// <summary>
//     /// Get all customers with deferred execution.
//     /// </summary>
//     /// <returns></returns>
//     IEnumerable<Customer> GetCustomers();

//     /// <summary>
//     /// Search fxn for to return a customer
//     /// </summary>
//     /// <param name="firstName"></param>
//     /// <param name="lastName"></param>
//     /// <returns></returns>
//     Customer GetCustomerByFullName(string firstName, string lastName);

//     /// <summary>
//     /// Adds a customer
//     /// </summary>
//     /// <param name="customer"></param>
//     void AddCustomer(Customer customer);
//     /// Get all locations with deferred execution.

//     // ? LOCATION STUFF
//     /// <summary>
//     /// Gets locations to place an order
//     /// </summary>
//     /// <returns></returns>
//     IEnumerable<Location> GetLocations();
//     /// <summary>
//     /// Gets a location by the location code
//     /// </summary>
//     /// <param name="code"></param>
//     /// <returns></returns>
//     Location GetLocationByCode(string code);
//     /// <summary>
//     /// Gets order history from a customer
//     /// </summary>
//     /// <param name="customer"></param>
//     /// <returns></returns>
//     /// 
//     /// ? Order operations
//     IEnumerable<Order> GetOrdersByCustomer(Customer customer);
//     /// <summary>
//     /// Gets order history from a location
//     /// </summary>
//     /// <param name="location"></param>
//     /// <returns></returns>
//     IEnumerable<Order> GetOrdersByLocation(Location location);
//     /// <summary>
//     /// Gets an order by its id  
//     /// </summary>
//     /// <param name="id"></param>
//     /// <returns></returns>
//     Order GetOrderById(int id);
//     /// <summary>
//     /// Adds an order to the database
//     /// </summary>
//     /// <param name="order"></param>
//     void AddOrder(Order order);
//     /// <summary>
//     /// Gets all items that were in an order
//     /// </summary>
//     /// <param name="orderId"></param>
//     /// <returns></returns>
//     /// 
//     /// ? Orderline operations
//     IEnumerable<Orderline> GetOrderItemsByOrderId(int orderId);
//     /// <summary>
//     /// Saves to data source
//     /// </summary>
//     void Save();

//   }
// }
