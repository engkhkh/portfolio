using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels;

namespace Web.Controllers
{
    public class PortfolioitemsController : Controller
    {
        private readonly IunitOfWork<portfolioitem> _portfolio;
        private readonly IHostingEnvironment _hosting;

        public IHostingEnvironment Hosting2 { get; }

        public PortfolioitemsController(IunitOfWork<portfolioitem> portfolio, IHostingEnvironment hosting, IHostingEnvironment hosting2)
        {
            _portfolio = portfolio;
            _hosting = hosting;
            Hosting2 = hosting2;
        }

        // GET: Portfolioitems
        public IActionResult Index()
        {
            return View(_portfolio.Entity.GetAll());
        }

        // GET: Portfolioitems/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.getbyid(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // GET: Portfolioitems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolioitems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                   
                    
                }

                portfolioitem portfolioItem = new portfolioitem
                {
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                  ImageUrl = model.File.FileName,
                   // vedioUrl= model.vFile.FileName
                };

                _portfolio.Entity.insert(portfolioItem);
                _portfolio.save();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Portfolioitems/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.getbyid(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            PortfolioViewModel portfolioViewModel = new PortfolioViewModel
            {
                Id = portfolioItem.Id,
                Description = portfolioItem.Description,
                ImageUrl = portfolioItem.ImageUrl,
                //vedioUrl= portfolioItem.vedioUrl,
                ProjectName = portfolioItem.ProjectName
            };

            return View(portfolioViewModel);
        }

        // POST: Portfolioitems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, PortfolioViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.File != null)
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath = Path.Combine(uploads, model.File.FileName);
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                        //// vFile
                        //string uploadsv = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        //string fullPathv = Path.Combine(uploadsv, model.vFile.FileName);
                        //model.vFile.CopyTo(new FileStream(fullPathv, FileMode.Create));
                    }

                    portfolioitem portfolioItem = new portfolioitem
                    {
                        Id = model.Id,
                        ProjectName = model.ProjectName,
                        Description = model.Description,
                        ImageUrl = model.File.FileName,
                       // vedioUrl=model.vFile.FileName
                    };

                    _portfolio.Entity.update(portfolioItem);
                    _portfolio.GetType();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioItemExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Portfolioitems/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.getbyid(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // POST: Portfolioitems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            try
            {
                // TODO: Add delete logic here

                _portfolio.Entity.delete(id);
                _portfolio.save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
        private bool PortfolioItemExists(Guid id)
        {
            return _portfolio.Entity.GetAll().Any(e => e.Id == id);
        }
    }
}