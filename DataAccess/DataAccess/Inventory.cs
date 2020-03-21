using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int LeominsterQuantity { get; set; }
        public int GardnerQuantity { get; set; }
        public int WorcesterQuantity { get; set; }
    }
}
