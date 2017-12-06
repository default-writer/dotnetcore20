using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class Customercustomerdemo
    {
        public char Customerid { get; set; }
        public char Customertypeid { get; set; }

        public Customers Customer { get; set; }
        public Customerdemographics Customertype { get; set; }
    }
}
