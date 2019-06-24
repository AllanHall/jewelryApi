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
    // Get all items
    [HttpGet]
    public ActionResult<List<Model>> GetAll()
    {
      var rv = db.Items;
      return rv.ToList();
    }

    // Get each item
    [HttpGet("{id}")]
    public ActionResult<Model> GetOneById(int id)
    {
      var item = db.Items.Find(id);
      return item;
    }
    // Post a new item
    [HttpPost]
    public ActionResult<Model> Post([FromBody]Model item)
    {
      db.Items.Add(item);
      db.SaveChanges();
      return item;
    }
    // Update an item
    [HttpPut("{id}")]
    public ActionResult<Model> Put(int id, [FromBody]Model item)
    {
      var data = db.Items.FirstOrDefault(f => f.id == id);
      data.sku = item.sku;
      data.name = item.name;
      data.description = item.description;
      data.stock = item.stock;
      data.price = item.price;
      db.SaveChanges();
      return data;
    }
    // Delete an item
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var item = db.Items.FirstOrDefault(f => f.id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        db.Items.Remove(item);
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

    // Get item based on SKU
    [HttpGet("sku/{sku}")]
    public ActionResult<Model> GetOneBySku(int sku)
    {
      var item = db.Items.FirstOrDefault(f => f.sku == sku);
      return item;
    }
  }
}
