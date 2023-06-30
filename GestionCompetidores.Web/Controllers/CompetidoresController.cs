using GestionCompetidores.Data.EF;
using GestionCompetidores.Servicio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompetidores.Web.Controllers
{
    public class CompetidoresController : Controller
    {
        private readonly IDeporteServicio _deporteServicio;
        private readonly ICompetidorServicio _competidorServicio; 
        public CompetidoresController(IDeporteServicio deporteServicio, ICompetidorServicio competidorServicio)
        {
            _deporteServicio = deporteServicio;
            _competidorServicio = competidorServicio;
        }
        
        public IActionResult CrearCompetidor()
        {
            List<Deporte> deportes = _deporteServicio.ListarDeportes();
            return View(deportes);
        }

        [HttpPost]
        public IActionResult GuardarCompetidor(Competidor competidor)
        {
            _competidorServicio.GuardarCompetidor(competidor);
            return View("ListarCompetidores");
        }
        public IActionResult ListarCompetidores()
        {
            List<Competidor> listaCompetidores = _competidorServicio.ListarCompetidores();
            if(listaCompetidores != null)
            {
                return View(listaCompetidores);
            }
            return Redirect("Home");
        }
    }
}
