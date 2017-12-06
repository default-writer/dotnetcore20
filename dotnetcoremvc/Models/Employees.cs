using System;
using System.Collections.Generic;

namespace dotnetcoremvc.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Employeeterritories = new HashSet<Employeeterritories>();
            InverseReportstoNavigation = new HashSet<Employees>();
            Orders = new HashSet<Orders>();
        }

        public short Employeeid { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Title { get; set; }
        public string Titleofcourtesy { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? Hiredate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Homephone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public short? Reportsto { get; set; }
        public string Photopath { get; set; }

        public Employees ReportstoNavigation { get; set; }
        public ICollection<Employeeterritories> Employeeterritories { get; set; }
        public ICollection<Employees> InverseReportstoNavigation { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
