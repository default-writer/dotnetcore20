using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public short Orderid { get; set; }
        public char? Customerid { get; set; }
        public short? Employeeid { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public short? Shipvia { get; set; }
        public float? Freight { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public string Shipregion { get; set; }
        public string Shippostalcode { get; set; }
        public string Shipcountry { get; set; }

        public Customers Customer { get; set; }
        public Employees Employee { get; set; }
        public Shippers ShipviaNavigation { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
