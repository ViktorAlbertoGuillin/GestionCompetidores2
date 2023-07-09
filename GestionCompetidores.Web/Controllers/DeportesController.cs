using GestionCompetidores.Data.EF;
using GestionCompetidores.Servicio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompetidores.Web.Controllers
{
    public class DeportesController : Controller
    {
        private readonly IDeporteServicio _deporteServicio;
        private readonly ICompetidorServicio _competidorServicio;
        public DeportesController(IDeporteServicio deporteServicio, ICompetidorServicio competidorServicio)
        {
            _deporteServicio = deporteServicio;
            _competidorServicio = competidorServicio;
        }
        public IActionResult CrearDeporte()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearDeporte(Deporte deporte)
        {
            _deporteServicio.AgregarDeporte(deporte);
            List<Deporte> listaDeporte = _deporteServicio.ListarDeportes();
            return View("ListarDeportes", listaDeporte);
        }

        public IActionResult ListarDeportes()
        {
            List<Deporte> listaDeportes = _deporteServicio.ListarDeportes();
            return View(listaDeportes);
        }
        [HttpGet]
        public IActionResult EditarDeporte(int Id)
        {
            Deporte deporte = _deporteServicio.BuscarDeportePorId(Id);
            return View(deporte);
        }

        [HttpPost]
        public IActionResult EditarDeporte(Deporte deporte)
        {
            _deporteServicio.EditarDeporte(deporte);
            List<Deporte> listaDeporte = _deporteServicio.ListarDeportes();
            return View("ListarDeportes", listaDeporte);
        }

        [HttpGet]
        public IActionResult EliminarDeporte(int Id)
        {
            List<Competidor> listaCompetidores = _competidorServicio.BuscarCompetidoresPorIdDeporte(Id);
            return View(listaCompetidores);
        }
        [HttpGet]
        public IActionResult EliminarDeportesYCompetidores(int Id)
        {
            _deporteServicio.eliminarDeporteYCompetidores(Id);
            return View("listarDeportes");
        }
    }
}
