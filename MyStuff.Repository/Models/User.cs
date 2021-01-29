using System;
using System.Collections.Generic;

#nullable disable

namespace MyStuff.Repository.Models
{
    public partial class User
    {
        public User()
        {
            Categories = new HashSet<Category>();
            Inventories = new HashSet<Inventory>();
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int? Email { get; set; }
        public string City { get; set; }
        public DateTime? Birthday { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
