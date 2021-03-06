using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Library.Models;
using StoreApp.DbAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Library.Interfaces;
using StoreApp.DbAccess.Repositories;

namespace StoreApp.WebUI.Controllers
{
  [ApiController]
  public class OrderController : ControllerBase
  {
    private readonly OrderRepository _orderRepository;

    public OrderController(OrderRepository orderRepository)
    {
      _orderRepository = orderRepository;
    }

    // [HttpGet("api/orders")]
    // public IEnumerable<StoreApp.Library.Models.Order> GetOrders()
    // {
    //   return _orderRepository.GetOrders();
    // }

    // [HttpPost("api/addOrder")]
    // public void AddOrder(StoreApp.Library.Models.Order order)
    // {

    //   _orderRepository.AddOrder(order);
    //   _orderRepository.Save();

    // }

    [HttpGet("api/searchOrder")]
    public StoreApp.Library.Models.Order SearchedAndFoundOrder(string firstName, string lastName)
    {
      //      _orderRepository.SearchForFirst(firstName, lastName);

      return new Library.Models.Order();
    }




  }
}