using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Stores
    {
        public Stores()
        {
            OrderHistory = new HashSet<OrderHistory>();
            ReviewsNavigation = new HashSet<Reviews>();
        }

        public int StoreId { get; set; }
        public string Location { get; set; }
        public decimal? AvgReviewScore { get; set; }
        public int? Reviews { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        public virtual ICollection<Reviews> ReviewsNavigation { get; set; }
    }
}
