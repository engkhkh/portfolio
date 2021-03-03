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
            //Hosting2 = hosting2;
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
       // [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        //[RequestSizeLimit(209715200)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath = Path.Combine(uploads,model.File.FileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    // new filelds 
                    string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath2 = Path.Combine(uploads2, model.File2.FileName);
                    model.File2.CopyTo(new FileStream(fullPath2, FileMode.Create));
                    // new filelds 
                    string uploads3 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath3 = Path.Combine(uploads3, model.File3.FileName);
                    model.File3.CopyTo(new FileStream(fullPath3, FileMode.Create));
                    // new filelds 
                    string uploads4 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath4 = Path.Combine(uploads4, model.File4.FileName);
                    model.File4.CopyTo(new FileStream(fullPath4, FileMode.Create));
                    // new filelds 
                    string uploads5 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath5 = Path.Combine(uploads5, model.File5.FileName);
                    model.File5.CopyTo(new FileStream(fullPath5, FileMode.Create));
                    // new filelds 
                    string uploads6 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath6 = Path.Combine(uploads6, model.File6.FileName);
                    model.File6.CopyTo(new FileStream(fullPath6, FileMode.Create));
                    // new filelds 
                    string uploads7 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath7 = Path.Combine(uploads7, model.File7.FileName);
                    model.File7.CopyTo(new FileStream(fullPath7, FileMode.Create));
                    // new filelds 
                    string uploads8 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath8 = Path.Combine(uploads8, model.File8.FileName);
                    model.File8.CopyTo(new FileStream(fullPath8, FileMode.Create));
                    // new filelds 
                    string uploads9 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath9 = Path.Combine(uploads9, model.File9.FileName);
                    model.File9.CopyTo(new FileStream(fullPath9, FileMode.Create));
                    // new filelds 
                    string uploads10 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath10 = Path.Combine(uploads10, model.File10.FileName);
                    model.File10.CopyTo(new FileStream(fullPath10, FileMode.Create));
                    // vFile
                    //string uploadsv = Path.Combine(Hosting2.WebRootPath, @"img\portfolio");
                    // string fullPathv = Path.Combine(uploadsv, model.vFile.FileName);
                    //  model.vFile.CopyTo(new FileStream(fullPathv, FileMode.Create)); 
                    string uploadsv = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fileName = $"{uploadsv}\\{model.vFile.FileName}";
               

                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        model.vFile.CopyTo(fs);
                        fs.Flush();
                    }
                   


                }

                portfolioitem portfolioItem = new portfolioitem
                {
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                  ImageUrl = model.File.FileName,
                    vedioUrl= model.vFile.FileName,
                    Image2=model.File2.FileName,
                    Image3 = model.File3.FileName,
                    Image4 = model.File4.FileName,
                    Image5 = model.File5.FileName,
                    Image6 = model.File6.FileName,
                    Image7 = model.File7.FileName,
                    Image8 = model.File8.FileName,
                    Image9 = model.File9.FileName,
                    Image10 = model.File10.FileName
                };

                _portfolio.Entity.insert(portfolioItem);
                _portfolio.save();
                //ViewData["message"] = $"{model.vFile.Length} bytes uploaded successfully!";

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
                vedioUrl= portfolioItem.vedioUrl,
                ProjectName = portfolioItem.ProjectName,
                Image2=portfolioItem.Image2,
                Image3 = portfolioItem.Image3,
                Image4 = portfolioItem.Image4,
                Image5 = portfolioItem.Image5,
                Image6 = portfolioItem.Image6,
                Image7 = portfolioItem.Image7,
                Image8 = portfolioItem.Image8,
                Image9 = portfolioItem.Image9,
                Image10 = portfolioItem.Image10,
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
                        // new filelds 
                        string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath2 = Path.Combine(uploads2, model.File2.FileName);
                        model.File2.CopyTo(new FileStream(fullPath2, FileMode.Create));
                        // new filelds 
                        string uploads3 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath3 = Path.Combine(uploads3, model.File3.FileName);
                        model.File3.CopyTo(new FileStream(fullPath3, FileMode.Create));
                        // new filelds 
                        string uploads4 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath4 = Path.Combine(uploads4, model.File4.FileName);
                        model.File4.CopyTo(new FileStream(fullPath4, FileMode.Create));
                        // new filelds 
                        string uploads5 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath5 = Path.Combine(uploads5, model.File5.FileName);
                        model.File5.CopyTo(new FileStream(fullPath5, FileMode.Create));
                        // new filelds 
                        string uploads6 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath6 = Path.Combine(uploads6, model.File6.FileName);
                        model.File6.CopyTo(new FileStream(fullPath6, FileMode.Create));
                        // new filelds 
                        string uploads7 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath7 = Path.Combine(uploads7, model.File7.FileName);
                        model.File7.CopyTo(new FileStream(fullPath7, FileMode.Create));
                        // new filelds 
                        string uploads8 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath8 = Path.Combine(uploads8, model.File8.FileName);
                        model.File8.CopyTo(new FileStream(fullPath8, FileMode.Create));
                        // new filelds 
                        string uploads9 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath9 = Path.Combine(uploads9, model.File9.FileName);
                        model.File9.CopyTo(new FileStream(fullPath9, FileMode.Create));
                        // new filelds 
                        string uploads10 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath10 = Path.Combine(uploads10, model.File10.FileName);
                        model.File10.CopyTo(new FileStream(fullPath10, FileMode.Create));
                        // vFile
                        //string uploadsv = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        //string fullPathv = Path.Combine(uploadsv, model.vFile.FileName);
                        //model.vFile.CopyTo(new FileStream(fullPathv, FileMode.Create));
                        string uploadsv = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fileName = $"{uploadsv}\\{model.vFile.FileName}";


                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            model.vFile.CopyTo(fs);
                            fs.Flush();
                        }
                    }

                    portfolioitem portfolioItem = new portfolioitem
                    {
                        Id = model.Id,
                        ProjectName = model.ProjectName,
                        Description = model.Description,
                        ImageUrl = model.File.FileName,
                       vedioUrl=model.vFile.FileName,
                        Image2 = model.File2.FileName,
                        Image3 = model.File3.FileName,
                        Image4 = model.File4.FileName,
                        Image5 = model.File5.FileName,
                        Image6 = model.File6.FileName,
                        Image7 = model.File7.FileName,
                        Image8 = model.File8.FileName,
                        Image9 = model.File9.FileName,
                        Image10 = model.File10.FileName
                    };

                    _portfolio.Entity.update(portfolioItem);
                    _portfolio.save();
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