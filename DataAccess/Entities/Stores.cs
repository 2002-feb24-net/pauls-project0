using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Stores
    {
        public Stores()
        {
            Customers = new HashSet<Customers>();
            OrderHistory = new HashSet<OrderHistory>();
            ReviewsNavigation = new HashSet<Reviews>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public decimal? AvgReviewScore { get; set; }
        public int? Reviews { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        public virtual ICollection<Reviews> ReviewsNavigation { get; set; }
    }
}
