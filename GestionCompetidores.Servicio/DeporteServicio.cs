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
    }
}
