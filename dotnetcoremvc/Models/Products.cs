using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public short Productid { get; set; }
        public string Productname { get; set; }
        public short? Supplierid { get; set; }
        public short? Categoryid { get; set; }
        public string Quantityperunit { get; set; }
        public float? Unitprice { get; set; }
        public short? Unitsinstock { get; set; }
        public short? Unitsonorder { get; set; }
        public short? Reorderlevel { get; set; }
        public int Discontinued { get; set; }

        public Categories Category { get; set; }
        public Suppliers Supplier { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
