using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jewelryapi.models;


namespace jewelryapi.controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    // Get all items
    [HttpGet]
    public ActionResult<List<Model>> Get()
    {
      var db = new DatabaseContext();
      var rv = db.Items;
      return rv.ToList();
    }
    // Get each item
    [HttpGet("{id}")]
    public ActionResult<Model> Get(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(f => f.id == id);
      return item;
    }
    // Post a new item
    [HttpPost]
    public ActionResult<Model> Post([FromBody]Model item)
    {
      var db = new DatabaseContext();
      db.Items.Add(item);
      db.SaveChanges();
      return item;
    }
    // Update an item
    [HttpPut]
    public ActionResult<Model> Put([FromBody]Model item)
    {
      var db = new DatabaseContext();

    }
    // Delete an item

    // Get all items that are out of stock

    // Get item based on SKU
    [HttpGet("sku/{sku}")]
    public ActionResult<Model> Get(int sku)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(f => f.sku == sku);
    }
  }
}