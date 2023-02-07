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
    public class TypesController : Controller
    {
        private readonly ITypeService _service;

        public TypesController(ITypeService service)
        {
            _service = service;
        }

        // GET: Type
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Type/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Models.Type Type)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(Type);

                return RedirectToAction(nameof(Index));
            }
            return View(Type);
        }

        // GET: Type/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Type = await _service.GetByIdAsync(id);
            if (Type == null)
            {
                return NotFound();
            }
            return View(Type);
        }

        // POST: Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Models.Type newType)
        {
            if (!ModelState.IsValid)
            {
                return View(id);

            }
            await _service.UpdateAsync(id,newType);
            return RedirectToAction(nameof(Index));
        }

        // GET: Type/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");

            return View(propertyDetail);
        }

        // POST: Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TypeExists(int id)
        {
            return _service.Type().Any(e => e.Id == id);
        }
    }
}
