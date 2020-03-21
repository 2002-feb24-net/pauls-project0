using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class OrderHistory
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string Location { get; set; }
        public int StoreId { get; set; }
        public DateTime DateTime { get; set; }
        public string Order { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Stores Store { get; set; }
    }
}
