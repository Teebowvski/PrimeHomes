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

namespace PrimeHome.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BedroomsController : Controller
    {
        private readonly IBedroomService _service;

        public BedroomsController(IBedroomService service)
        {
            _service = service;
        }

        // GET: Bedrooms
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Bedrooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: Bedrooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bedrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Bedrooms Bedrooms)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(Bedrooms);

                return RedirectToAction(nameof(Index));
            }
            return View(Bedrooms);
        }

        // GET: Bedrooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bedrooms = await _service.GetByIdAsync(id);
            if (Bedrooms == null)
            {
                return NotFound();
            }
            return View(Bedrooms);
        }

        // POST: Bedrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Bedrooms newBedrooms)
        {
            if (!ModelState.IsValid)
            {
                return View(id);

            }
            await _service.UpdateAsync(id, newBedrooms);
            return RedirectToAction(nameof(Index));
        }

        // GET: Bedrooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");

            return View(propertyDetail);
        }

        // POST: Bedrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BedroomsExists(int id)
        {
            return _service.Bedrooms().Any(e => e.Id == id);
        }
    }
}
