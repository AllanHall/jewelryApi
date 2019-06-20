using System;

namespace jewelryapi.models
{
  public class Model
  {
    public int id { get; set; }
    public int sku { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int stock { get; set; }
    public int price { get; set; }
    public DateTime dateordered { get; set; } = DateTime.Now;
    public int? LocationId { get; set; }
    public Locations Location { get; set; }
  }
}