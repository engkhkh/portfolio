using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Entities;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IunitOfWork<Owner> Owner { get; }
        public IunitOfWork<portfolioitem>_PORTFOLIO { get; }


        public HomeController(IunitOfWork<Owner> owner,IunitOfWork<portfolioitem> PORTFOLIO)
        {
            Owner = owner;
            _PORTFOLIO = PORTFOLIO;
        }
        public IActionResult Index()
        {

            var HomeViewModel = new HomeViewModel
            {
                Owner = Owner.Entity.GetAll().First(),
                Portfolioitems = _PORTFOLIO.Entity.GetAll().ToList()
            };
            return View(HomeViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Career()
        {
            return View();
        }
    }
}