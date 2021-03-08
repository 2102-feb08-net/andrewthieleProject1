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

    [HttpGet("api/orders")]
    public List<StoreApp.Library.Models.Order> GetOrders()

    {
      return _orderRepository.GetOrders();
    }

    [HttpGet("api/order/{id}")]
    public StoreApp.Library.Models.Order GetOrderByIts(int id)
    {
      return _orderRepository.GetOrderById(id);
    }

    [HttpGet("api/order/customer/{id}")]
    public List<StoreApp.Library.Models.Order> GetOrdersByCustomerId(int id)
    {
      return _orderRepository.GetOrdersByCustomerId(id);
    }

    [HttpGet("api/order/location/{id}")]
    public List<Library.Models.Order> GetOrdersByLocationId(int id)
    {
      return _orderRepository.GetOrdersByLocationId(id);
    }

    [HttpPost("api/addOrder")]
    public void AddOrder(StoreApp.Library.Models.Order order)
    {
      _orderRepository.AddOrder(order);
      _orderRepository.Save();
    }
  }
}