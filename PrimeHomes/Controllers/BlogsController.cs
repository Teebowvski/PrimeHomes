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
using SmartBreadcrumbs.Attributes;

namespace PrimeHomes.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService _service;

        public BlogsController(IBlogService service)
        {
            _service = service;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,DateCreated,Content,MainContent,MainContent2,MainContent3,AuthorName,AboutAuthor,AuthorImageUrl,FacebookUrl,InstagramUrl,TwitterUrl,LinkdelUrl,BlogImageUrl,BlogImageUrl2")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(blog);

                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Blog = await _service.GetByIdAsync(id);
            if (Blog == null)
            {
                return NotFound();
            }
            return View(Blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,DateCreated,Content,MainContent,MainContent2,MainContent3,AuthorName,AboutAuthor,AuthorImageUrl,FacebookUrl,InstagramUrl,TwitterUrl,LinkdelUrl,BlogImageUrl,BlogImageUrl2")] Blog blog)
        {

            if (!ModelState.IsValid)
            {
                return View(id);

            }
            await _service.UpdateAsync(id, blog);
            return RedirectToAction(nameof(Index));
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");

            return View(propertyDetail);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyDetail = await _service.GetByIdAsync(id);
            if (propertyDetail == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

       
      
        public async Task<IActionResult> MainBlog(int id)
        {

            var data = await _service.GetByIdAsync(id);
            return View(data);

            
        }
        public async Task<IActionResult> Blogs()
        {
            var propertyListViewModel = new PropertyListViewModel
            {
                
                Blogs = _service.Blog()
            };
            return View(propertyListViewModel);
          
            


        }
    }
}
