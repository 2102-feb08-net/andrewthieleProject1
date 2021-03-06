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
  public class ProductController : ControllerBase
  {
    private readonly ProductRepository _productRepository;

    public ProductController(ProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    [HttpGet("api/products")]
    public IEnumerable<StoreApp.Library.Models.Product> GetProducts()
    {
      return _productRepository.GetProducts();
    }
  }
}