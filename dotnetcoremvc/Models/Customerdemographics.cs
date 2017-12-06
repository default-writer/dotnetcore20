using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class Customerdemographics
    {
        public Customerdemographics()
        {
            Customercustomerdemo = new HashSet<Customercustomerdemo>();
        }

        public char Customertypeid { get; set; }
        public string Customerdesc { get; set; }

        public ICollection<Customercustomerdemo> Customercustomerdemo { get; set; }
    }
}
