using GestionCompetidores.Data.EF;
using GestionCompetidores.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompetidores.Data
{
    public class Repositorio : IRepositorio
    {
        private readonly GestionCompetidoresContext _contexto;
        public Repositorio(GestionCompetidoresContext contexto)
        {
            _contexto = contexto;
        }

        public List<Deporte> ListarDeportes()
        {
            return _contexto.Deportes.OrderBy(c=> c.NombreDeporte).ToList();
        }
        public void GuardarCompetidor(Competidor competidor)
        {
            _contexto.Competidors.Add(competidor);
            _contexto.SaveChanges();
        }

        public List<Competidor> ListarCompetidores()
        {
            //return _contexto.Competidors.Include(e => e.IdDeporteNavigation).ToList();
            return _contexto.Competidors
            .Include(s => s.IdDeporteNavigation)
            .ToList();
        }
    }
}
