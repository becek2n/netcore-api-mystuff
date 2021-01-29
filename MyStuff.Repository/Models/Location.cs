using System;
using System.Collections.Generic;

#nullable disable

namespace MyStuff.Repository.Models
{
    public partial class Location
    {
        public Location()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
