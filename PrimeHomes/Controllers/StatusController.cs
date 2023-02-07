using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimeHomes.Data;
using PrimeHomes.Data.Services;
using PrimeHomes.Models;

namespace PrimeHomes.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Status Status)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(Status);

                return RedirectToAction(nameof(Index));
            }
            return View(Status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Status = await _service.GetByIdAsync(id);
            if (Status == null)
            {
                return NotFound();
            }
            return View(Status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Status newStatus)
        {
            if (!ModelState.IsValid)
            {
                return View(id);

            }
            await _service.UpdateAsync(id, newStatus);
            return RedirectToAction(nameof(Index));
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");

            return View(propertyDetail);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
            return _service.Status().Any(e => e.Id == id);
        }
    }
}
