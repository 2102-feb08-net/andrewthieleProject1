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
  public class LocationController : ControllerBase
  {
    private readonly LocationRepository _locationRepository;

    public LocationController(LocationRepository locationRepository)
    {
      _locationRepository = locationRepository;
    }

    [HttpGet("api/locations")]
    public IEnumerable<StoreApp.Library.Models.Location> GetLocations()
    {
      return _locationRepository.GetLocations();
    }

  }
}