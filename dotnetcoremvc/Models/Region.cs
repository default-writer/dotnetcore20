using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territories>();
        }

        public short Regionid { get; set; }
        public char Regiondescription { get; set; }

        public ICollection<Territories> Territories { get; set; }
    }
}
