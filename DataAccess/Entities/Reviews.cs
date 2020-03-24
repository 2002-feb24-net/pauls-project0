using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public decimal Score { get; set; }
        public int CustomerId { get; set; }
        public string Text { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Stores Store { get; set; }
    }
}
