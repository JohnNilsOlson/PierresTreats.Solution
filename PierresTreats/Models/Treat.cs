using System.Collections.Generic;

namespace PierresTreats.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavors = new HashSet<Flavor>();
    }

    public int TreatId { get; set; }
    public string TreatName { get; set; }
    public ICollection<Flavor> Flavors { get; set; }
  }
}