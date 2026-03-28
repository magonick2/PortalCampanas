using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;
using PortalCampanas.Data;

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        // Listado Principal
        public IActionResult Index()
        {
            var lista = MockData.Campanas;
            return View(lista);
        }
    }
}