using Microsoft.AspNetCore.Mvc;
using PrimeHomes.Data.Services;
using System.Linq;

namespace PrimeHomes.Components
{
    public class TypeMenu:ViewComponent 
    {
        private readonly ITypeService _service;
        public TypeMenu(ITypeService service)
        {
            _service = service;
        }
        public IViewComponentResult Invoke()
        {
            var types = _service.Type().OrderBy(s => s.Name);
            return View(types);
        }
    }
}
