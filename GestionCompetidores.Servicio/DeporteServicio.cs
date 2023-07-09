using GestionCompetidores.Data.EF;
using GestionCompetidores.Data.Interface;
using GestionCompetidores.Servicio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompetidores.Servicio
{
    public class DeporteServicio : IDeporteServicio
    {
        private readonly IRepositorio _repositorio;
        public DeporteServicio(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Deporte> ListarDeportes()
        {
            return _repositorio.ListarDeportes();
        }

        public void AgregarDeporte(Deporte deporte)
        {
            _repositorio.AgregarDeporte(deporte);
        }

        public void EditarDeporte(Deporte deporte)
        {
            _repositorio.EditarDeporte(deporte);
        }
        public Deporte BuscarDeportePorId(int Id)
        {
            return _repositorio.BuscarDeportePorId(Id);
        }

        public void eliminarDeporteYCompetidores(int id)
        {
            _repositorio.EliminarDeporteYCompetidor(id);
        }
    }
}
