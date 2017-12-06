using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class Employeeterritories
    {
        public short Employeeid { get; set; }
        public string Territoryid { get; set; }

        public Employees Employee { get; set; }
        public Territories Territory { get; set; }
    }
}
