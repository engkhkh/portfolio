using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class PortfolioViewModel
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string vedioUrl { get; set; }
        public IFormFile File { get; set; }
        public IFormFile vFile { get; set; }
        // new fields 
        public IFormFile File2 { get; set; }
        public IFormFile File3 { get; set; }
        public IFormFile File4 { get; set; }
        public IFormFile File5 { get; set; }
        public IFormFile File6 { get; set; }
        public IFormFile File7 { get; set; }
        public IFormFile File8 { get; set; }
        public IFormFile File9 { get; set; }
        public IFormFile File10 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string Image6 { get; set; }
        public string Image7 { get; set; }
        public string Image8 { get; set; }
        public string Image9 { get; set; }
        public string Image10 { get; set; }


    }
}
