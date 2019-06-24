using Microsoft.AspNetCore.Mvc;
using jewelryapi.models;
using System.Collections.Generic;
using System.Linq;

namespace jewelryapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    private DatabaseContext db;
    public LocationsController()
    {
      this.db = new DatabaseContext();
    }
    // Get All Locations
    [HttpGet]
    public ActionResult<List<Locations>> GetAllLocations()
    {
      var rv = db.Location;
      return rv.ToList();
    }
    // Create a new Location
    [HttpPost]
    public ActionResult<Locations> CreateNewLocation([FromBody]Locations Location)
    {
      db.Location.Add(Location);
      db.SaveChanges();
      return Location;
    }
  }
}