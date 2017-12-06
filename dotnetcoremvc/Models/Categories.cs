using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public short Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
