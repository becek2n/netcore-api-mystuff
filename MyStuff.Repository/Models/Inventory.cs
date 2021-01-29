using System;
using System.Collections.Generic;

#nullable disable

namespace MyStuff.Repository.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryImages = new HashSet<InventoryImage>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<InventoryImage> InventoryImages { get; set; }
    }
}
