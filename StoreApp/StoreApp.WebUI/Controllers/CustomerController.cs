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
  public class CustomerController : ControllerBase
  {
    private readonly CustomerRepository _customerRepository;

    public CustomerController(CustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    [HttpGet("api/customers")]
    public IEnumerable<StoreApp.Library.Models.Customer> GetCustomers()
    {
      return _customerRepository.GetCustomers();
    }




  }
}