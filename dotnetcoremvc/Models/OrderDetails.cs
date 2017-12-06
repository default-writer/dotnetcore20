using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class OrderDetails
    {
        public short Orderid { get; set; }
        public short Productid { get; set; }
        public float Unitprice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Orders Order { get; set; }
        public Products Product { get; set; }
    }
}
