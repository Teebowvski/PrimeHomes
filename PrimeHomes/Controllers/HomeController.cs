using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeHomes.Data;
using PrimeHomes.Data.Services;
using PrimeHomes.Models;
using PrimeHomes.ViewModels;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPropertyService _service;
        private readonly ApplicationDbContext _context;
        public HomeController(IPropertyService service, ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index()
        {
            var propertyListViewModel = new PropertyListViewModel
            {
                Properties = _service.Property(),
                Blogs = _context.Blogs
            };
            return View(propertyListViewModel);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
