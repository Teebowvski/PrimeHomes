using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimeHomes.Data;

using PrimeHomes.Data.Services;
using PrimeHomes.Models;
using PrimeHomes.ViewModels;

namespace PrimeHomes.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PropertyController : Controller
    {
       
        private readonly IPropertyService _service;
        private readonly IAreaService _areaService;
        private readonly IBathroomService _bathroomService;
        private readonly IBedroomService _bedroomService;
        private readonly IFeaturesService _featuresService;
        private readonly IStatusService _statusService;
        private readonly IStockService _stockService;
        private readonly ITypeService _typeService;
        private readonly IBlogService _blogService;

        public PropertyController(IPropertyService service, IBlogService blogService, IAreaService areaService, IBathroomService bathroomService, IBedroomService bedroomService, IFeaturesService featuresService, IStatusService statusService, IStockService stockService, ITypeService typeService)
        {
            _service = service;
            _areaService = areaService;
            _bathroomService = bathroomService;
            _bedroomService = bedroomService;
            _featuresService = featuresService;
            _statusService = statusService;
            _stockService = stockService;
            _typeService = typeService;
            _blogService = blogService;

        }

        // GET: Property
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: Property/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            ViewData["AreaId"] = new SelectList(_areaService.Area(), "Id", "Name");
            ViewData["BathroomsId"] = new SelectList(_bathroomService.Bathroom(), "Id", "Number");
            ViewData["BedroomsId"] = new SelectList(_bedroomService.Bedrooms(), "Id", "Number");
            ViewData["FeaturesId"] = new SelectList(_featuresService.Features(), "Id", "Name");
            ViewData["StatusId"] = new SelectList(_statusService.Status(), "Id", "Name");
            ViewData["StockId"] = new SelectList(_stockService.Stock(), "Id", "Name");
            ViewData["TypeId"] = new SelectList(_typeService.Type(), "Id", "Name");
            return View(data);
        }
       

        // GET: Property/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_areaService.Area(), "Id", "Name");
            ViewData["BathroomsId"] = new SelectList(_bathroomService.Bathroom(), "Id", "Number");
            ViewData["BedroomsId"] = new SelectList(_bedroomService.Bedrooms(), "Id", "Number");
            ViewData["FeaturesId"] = new MultiSelectList(_featuresService.Features(), "Id", "Name");
            ViewData["StatusId"] = new SelectList(_statusService.Status(), "Id", "Name");
            ViewData["StockId"] = new SelectList(_stockService.Stock(), "Id", "Name");
            ViewData["TypeId"] = new SelectList(_typeService.Type(), "Id", "Name");
            return View();
        }

        // POST: Property/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Description1,Description2,Description3,Description4,Features1,Features2,Features3,Features4,SizeRange,ListingNumber,BedroomsId,BathroomsId,StatusId,TypeId,AreaId,LocationUrl,FeaturesId,Contact,StockId,ImageUrl,ImageUrl1,ImageUrl2,ImageUrl3,ImageUrl4")] Property property)
        {
            if (ModelState.IsValid)
            {
               await _service.AddAsync(property);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_areaService.Area(), "Id", "Name", property.AreaId);
            ViewData["BathroomsId"] = new SelectList(_bathroomService.Bathroom(), "Id", "Number", property.BathroomsId);
            ViewData["BedroomsId"] = new SelectList(_bedroomService.Bedrooms(), "Id", "Number", property.BedroomsId);
            ViewData["FeaturesId"] = new SelectList(_featuresService.Features(), "Id", "Name", property.FeaturesId);
            ViewData["StatusId"] = new SelectList(_statusService.Status(), "Id", "Name", property.StatusId);
            ViewData["StockId"] = new SelectList(_stockService.Stock(), "Id", "Name", property.StockId);
            ViewData["TypeId"] = new SelectList(_typeService.Type(), "Id", "Name", property.TypeId);
            return View(property);
        }

        // GET: Property/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var propertyDetails = await _service.GetByIdAsync(id);
            if (propertyDetails == null) return View("Not Found");

            ViewData["AreaId"] = new SelectList(_areaService.Area(), "Id", "Name");
            ViewData["BathroomsId"] = new SelectList(_bathroomService.Bathroom(), "Id", "Number");
            ViewData["BedroomsId"] = new SelectList(_bedroomService.Bedrooms(), "Id", "Number");
            ViewData["FeaturesId"] = new SelectList(_featuresService.Features(), "Id", "Name");
            ViewData["StatusId"] = new SelectList(_statusService.Status(), "Id", "Name");
            ViewData["StockId"] = new SelectList(_stockService.Stock(), "Id", "Name");
            ViewData["TypeId"] = new SelectList(_typeService.Type(), "Id", "Name");
            return View(propertyDetails);
        }

        // POST: Property/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Description1,Description2,Description3,Description4,Features1,Features2,Features3,Features4,SizeRange,ListingNumber,BedroomsId,BathroomsId,StatusId,TypeId,AreaId,LocationUrl,FeaturesId,Contact,StockId,ImageUrl,ImageUrl1,ImageUrl2,ImageUrl3,ImageUrl4")] Property property)
        {
           

            if (!ModelState.IsValid)
            {
                return View(id);
                
            }
            ViewData["AreaId"] = new SelectList(_areaService.Area(), "Id", "Name", property.AreaId);
            ViewData["BathroomsId"] = new SelectList(_bathroomService.Bathroom(), "Id", "Number", property.BathroomsId);
            ViewData["BedroomsId"] = new SelectList(_bedroomService.Bedrooms(), "Id", "Number", property.BedroomsId);
            ViewData["FeaturesId"] = new SelectList(_featuresService.Features(), "Id", "Name", property.FeaturesId);
            ViewData["StatusId"] = new SelectList(_statusService.Status(), "Id", "Name", property.StatusId);
            ViewData["StockId"] = new SelectList(_stockService.Stock(), "Id", "Name", property.StockId);
            ViewData["TypeId"] = new SelectList(_typeService.Type(), "Id", "Name", property.TypeId);
            await _service.UpdateAsync(id, property);
                return RedirectToAction(nameof(Index));
        }

        // GET: Property/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var propertyDetail =await  _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
            
            return View(propertyDetail);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyDetail =await  _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
          await  _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> area()
        {

            var data = _service.Property().Where(c => c.Area.Name == c.Name).ToList();
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ProductDetails(int id)
        {

            var data = await _service.GetByIdAsync(id);
            return View(data);
        }
        [AllowAnonymous]
        public IActionResult List(string types)
        {

            IEnumerable<Property> properties;
            string _types = types;

            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(types))
            {
                properties = _service.Property().OrderBy(x => x.Id);
                types = "All Types";
            }
            else
            {
                if (string.Equals("Commercial", _types, StringComparison.OrdinalIgnoreCase))
                {
                    properties = _service.Property().Where(x => x.Type.Name.Equals("Commercial")).OrderBy(x => x.Name);
                }
                else
                {
                    properties = _service.Property().Where(x => x.Type.Name.Equals("Residential")).OrderBy(x => x.Name);
                }

                types = _types;

            }


            var propertyListViewModel = new PropertyListViewModel()
            {
                Properties = _service.Property(),
                Features = _featuresService.Features(),
                Types = _typeService.Type(),
                Areas = _areaService.Area(),
                Status = _statusService.Status(),
                Blogs = _blogService.Blog() 
            };
            return View(propertyListViewModel);
        }
    }
}
