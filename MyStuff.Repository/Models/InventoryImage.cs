using System;
using System.Collections.Generic;

#nullable disable

namespace MyStuff.Repository.Models
{
    public partial class InventoryImage
    {
        public int Id { get; set; }
        public int? InventoryId { get; set; }
        public int? Image { get; set; }
        public string Description { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
