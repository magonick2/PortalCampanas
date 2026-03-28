using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Models;
using PortalCampanas.Data;
using System.Linq;

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        // GET: /Campanas
        // Implementa el Listado (RF1) y los Filtros (RF3)
        public IActionResult Index(string categoria, string estado)
        {
            // Obtenemos todos los datos de la lista en memoria
            var query = MockData.Campanas.AsQueryable();

            // Lógica de filtrado en memoria
            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(c => c.Categoria == categoria);
            }

            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(c => c.Estado == estado);
            }

            return View(query.ToList());
        }
        //comentario pedido por el profesor linea 30
        // GET: /Campanas/Detalle/{id}
        // Implementa la visualización de detalle (RF2)
        public IActionResult Detalle(int id)
        {
            var campana = MockData.Campanas.FirstOrDefault(c => c.Id == id);
            
            if (campana == null)
            {
                return NotFound();
            }
            
            return View(campana);
        }

        // GET: /Campanas/Resumen
        // Implementa los indicadores calculados (RF4)
        public IActionResult Resumen()
        {
            //Hola profe estoy haceindo un cambio dentro de esta funcion, yaque ya la habia agregado antes :c
            // Cálculos solicitados en el objetivo del reto
            var totalCampanas = MockData.Campanas.Count;
            var vigentes = MockData.Campanas.Count(c => c.Estado == "Vigente");
            var proximas = MockData.Campanas.Count(c => c.Estado == "Próxima");
            
            // Promedio de descuento (evitando división por cero)
            var promedioDescuento = MockData.Campanas.Any() 
                ? MockData.Campanas.Average(c => c.DescuentoPct) 
                : 0;

            // Cantidad por canal
            var resumenPorCanal = MockData.Campanas
                .GroupBy(c => c.Canal)
                .Select(g => new { Canal = g.Key, Cantidad = g.Count() })
                .ToList();

            // Pasamos los datos a la vista mediante ViewBag o un ViewModel
            ViewBag.Total = totalCampanas;
            ViewBag.Vigentes = vigentes;
            ViewBag.Proximas = proximas;
            ViewBag.Promedio = promedioDescuento;
            ViewBag.Canales = resumenPorCanal;

            return View();
        }
    }
}