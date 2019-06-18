using System;

namespace jewelryapi.models
{
  public class models
  {
    public int id { get; set; }
    public int sku { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int stock { get; set; }
    public int price { get; set; }
    public DateTime DateOrdered { get; set; }
  }
}