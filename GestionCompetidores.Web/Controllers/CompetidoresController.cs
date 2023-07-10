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
            List<Competidor> listaCompetidores = _competidorServicio.ListarCompetidores();
            return View("ListarCompetidores",listaCompetidores);
        }
        public IActionResult ListarCompetidores()
        {
            List<Competidor> listaCompetidores = _competidorServicio.ListarCompetidores();
            List<Deporte> deportes = _deporteServicio.ListarDeportes();
            ViewBag.Deportes = deportes;
            if (listaCompetidores != null)
            {
                return View(listaCompetidores);
            }
            return Redirect("Home");
        }

        
        [HttpGet]
        public IActionResult EditarCompetidor(int Id)
        {
            List<Deporte> deportes = _deporteServicio.ListarDeportes();
            ViewBag.Deportes = deportes;
            Competidor competidor = _competidorServicio.BuscarCompetidorPorId(Id);
            ViewBag.Competidor = competidor;
            return View();
        }

        [HttpPost]
        public IActionResult EditarCompetidor(Competidor competidor)
        {
            _competidorServicio.EditarCompetidor(competidor);
            List<Competidor> listaCompetidores = _competidorServicio.ListarCompetidores();
            return View("ListarCompetidores", listaCompetidores);
        }
        [HttpGet]
        public IActionResult EliminarCompetidor(int Id)
        {
            _competidorServicio.EliminarCompetidor(Id);
            List<Competidor> listaCompetidores = _competidorServicio.ListarCompetidores();
            return View("ListarCompetidores", listaCompetidores);
        }

        [HttpPost]
        public IActionResult Filtrar(int IdDeporte)
        {
            if (IdDeporte == 0)
            {
                return Redirect("/Competidores/ListarCompetidores");
            }
            List<Competidor> competidores = _competidorServicio.BuscarCompetidoresPorIdDeporte(IdDeporte);
            List<Deporte> deportes = _deporteServicio.ListarDeportes();
            ViewBag.Deportes = deportes;
            return View("ListarCompetidores", competidores);
        }
    }
}
