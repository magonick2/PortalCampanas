using PortalCampanas.Models;

namespace PortalCampanas.Data;

public static class MockData {
    public static List<Campana> Campanas = new List<Campana> {
        new Campana { Id = 1, Nombre = "CyberWow Electro", Categoria = "Electro", Estado = "Vigente", FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(7), DescuentoPct = 30, Canal = "Web", Descripcion = "Ofertas en toda la línea blanca." },
        new Campana { Id = 2, Nombre = "Renueva tu Hogar", Categoria = "Hogar", Estado = "Vigente", FechaInicio = DateTime.Now.AddDays(-5), FechaFin = DateTime.Now.AddDays(10), DescuentoPct = 25, Canal = "Tienda", Descripcion = "Muebles y decoración." }
    };
}