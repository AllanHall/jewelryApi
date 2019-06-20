using System.Collections.Generic;

namespace jewelryapi.models
{
  public class Locations
  {
    public int id { get; set; }
    public string Address { get; set; }
    public string ManagerName { get; set; }
    public string PhoneNumber { get; set; }
    public List<Model> Items { get; set; } = new List<Model>();
  }
}