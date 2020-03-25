using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Prices
    {
        public string Product { get; set; }
        public decimal? Price { get; set; }
    }
}
