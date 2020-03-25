using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Inventory
    {
        public int StoreId { get; set; }
        public string Location { get; set; }
        public int Hamburgers { get; set; }
        public int Buns { get; set; }
        public int Cheese { get; set; }
        public int Bacon { get; set; }
        public int Lettuce { get; set; }
        public int Tomatoes { get; set; }
        public int Onions { get; set; }
        public int Pickles { get; set; }
        public int Mayonaise { get; set; }
        public int Ketchup { get; set; }
        public int Mustard { get; set; }
        public int EdSauce { get; set; }
        public int Fries { get; set; }
        public int Cola { get; set; }

        public virtual Stores Store { get; set; }
    }
}
