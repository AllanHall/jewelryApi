using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jewelryapi.models;
using Microsoft.EntityFrameworkCore;


namespace jewelryapi.controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    private DatabaseContext db;
    public ItemsController()
    {
      this.db = new DatabaseContext();
    }
    // Get all items by location
    [HttpGet]
    public ActionResult<List<Model>> GetAll([FromQuery] int? LocationId)
    {
      if (LocationId == null)
      {
        return Unauthorized();
      }
      // var rv = db.Location.Include(i => i.Items).FirstOrDefault(f => f.id == LocationId);
      // return rv.Items;
      var vr = db.Items.Include(i => i.Location);
      return vr.ToList();
    }

    // Get each item by location
    [HttpGet("{id}")]
    public ActionResult<Model> GetOneById(int id, [FromQuery] int? LocationId)
    {
      if (LocationId == null)
      {
        return Unauthorized();
      }
      var first = db.Location
      .Include(i => i.Items)
      .FirstOrDefault(f => f.id == LocationId)
      .Items.FirstOrDefault(item => item.id == id)
      ;
      return new Model
      {
        sku = first.sku,
        name = first.name,
        description = first.description,
        stock = first.stock,
        price = first.price,
        dateordered = first.dateordered,
        LocationId = first.LocationId,
        Location = first.Location
      };
    }
    // Post a new item by location
    [HttpPost("{LocationId}")]
    public ActionResult<Model> Post([FromBody]Model item, int? LocationId)
    {
      if (LocationId == null)
      {
        return Unauthorized();
      }
      var location = db.Location.FirstOrDefault(f => f.id == LocationId);
      if (location == null)
      {
        location = new Locations
        {
          id = LocationId.GetValueOrDefault()
        };
        db.Location.Add(location);
        db.SaveChanges();
      }
      location.Items.Add(item);
      db.SaveChanges();
      return item;
    }
    // Update an item
    [HttpPut("{id}")]
    public ActionResult<Model> Put(int id, [FromBody]Model item, [FromQuery] int? LocationId)
    {
      var data = db.Items
      .Where(w => w.LocationId == LocationId.GetValueOrDefault())
      .FirstOrDefault(f => f.id == id);
      // Changes location of book from URL
      // data.LocationId = LocationId;
      // Changes location of book from body
      // data.LocationId = item.LocationId;
      data.sku = item.sku;
      data.name = item.name;
      data.description = item.description;
      data.stock = item.stock;
      data.price = item.price;
      db.SaveChanges();
      return data;
    }
    // Delete an item by location
    [HttpDelete("{id}")]
    public ActionResult Delete(int id, [FromQuery] int? LocationId)
    {
      var item = db.Items.FirstOrDefault(f => f.id == id);
      if (item == null)
      {
        return NotFound();
      }
      if (LocationId == null)
      {
        return Unauthorized();
      }
      else
      {
        var location = db.Location.FirstOrDefault(f => f.id == LocationId);
        location.Items.Remove(item);
        db.SaveChanges();
        return Ok();
      }
    }
    // Get all items that are out of stock
    [HttpGet("out-of-stock")]
    public ActionResult<List<Model>> GetOutOfStock(int stock)
    {
      var outOfStock = db.Items.Where(item => (item.stock == 0));
      return outOfStock.ToList();
    }

    // Get items out of stock by location
    [HttpGet("out-of-stock-by-location")]
    public ActionResult<List<Model>> GetOutOfStockByStore([FromQuery] int? LocationId)
    {
      if (LocationId == null)
      {
        return Unauthorized();
      }
      var outOfStock = db.Items.Where(w => w.LocationId == LocationId.GetValueOrDefault()).Where(item => (item.stock == 0));
      return outOfStock.ToList();
    }

    // Get item based on SKU
    [HttpGet("sku/{sku}")]
    public ActionResult<Model> GetOneBySku(int sku, [FromQuery] int? LocationId)
    {
      if (LocationId == null)
      {
        return Unauthorized();
      }
      var first = db.Location
      .Include(i => i.Items)
      .FirstOrDefault(f => f.id == LocationId)
      .Items.FirstOrDefault(item => item.sku == sku)
      ;
      return new Model
      {
        id = first.id,
        sku = first.sku,
        name = first.name,
        description = first.description,
        stock = first.stock,
        price = first.price,
        dateordered = first.dateordered,
        LocationId = first.LocationId
      };
    }
  }
}
