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
    public class BathroomsController : Controller
    {
        private readonly IBathroomService _service;

        public BathroomsController(IBathroomService service)
        {
            _service = service;
        }

        // GET: Bathrooms
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Bathrooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: Bathrooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bathrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Bathrooms Bathrooms)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(Bathrooms);

                return RedirectToAction(nameof(Index));
            }
            return View(Bathrooms);
        }

        // GET: Bathrooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bathrooms = await _service.GetByIdAsync(id);
            if (Bathrooms == null)
            {
                return NotFound();
            }
            return View(Bathrooms);
        }

        // POST: Bathrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Bathrooms newBathrooms)
        {
            if (!ModelState.IsValid)
            {
                return View(id);

            }
            await _service.UpdateAsync(id, newBathrooms);
            return RedirectToAction(nameof(Index));
        }

        // GET: Bathrooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");

            return View(propertyDetail);
        }

        // POST: Bathrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BathroomsExists(int id)
        {
            return _service.Bathroom().Any(e => e.Id == id);
        }
    }
}
