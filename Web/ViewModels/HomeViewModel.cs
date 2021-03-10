using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;


namespace Web.ViewModels
{
    public class HomeViewModel
    {

        public Owner Owner { get; set; }

        public List<portfolioitem> Portfolioitems { get; set; }
        public List<Career> Careers { get; set; }
    }
}
