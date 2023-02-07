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
using PrimeHomes.ViewModels;

namespace PrimeHomes.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly ITeamMembersService _service;

        public TeamMembersController(ITeamMembersService service)
        {
            _service = service;
        }

        public IActionResult TeamsPage()
        {
           
         
                var propertyListViewModel = new PropertyListViewModel
                {

                    TeamMembers = _service.TeamMembers()
                };
                return View(propertyListViewModel);




           
            
        }

        // GET: TeamMembers
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: TeamMembers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: TeamMembers/Create
        public IActionResult Create()
        {
            return View();
        }

      

      


        // POST: TeamMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position,ImageUrl,FacebookUrl,TwitterUrl,LinkendenUrl")] TeamMembers teamMembers)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(teamMembers);

                return RedirectToAction(nameof(Index));
            }
            return View(teamMembers);
        }

        // GET: TeamMembers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TeamMembers = await _service.GetByIdAsync(id);
            if (TeamMembers == null)
            {
                return NotFound();
            }
            return View(TeamMembers);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Position,ImageUrl,FacebookUrl,TwitterUrl,LinkendenUrl")] TeamMembers teamMembers)
        {
            if (!ModelState.IsValid)
            {
                return View(id);

            }
            await _service.UpdateAsync(id, teamMembers);
            return RedirectToAction(nameof(Index));
        }

        // GET: TeamMembers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");

            return View(propertyDetail);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TeamMembersExists(int id)
        {
            return _service.TeamMembers().Any(e => e.Id == id);
        }
    }
}
