using GestionCompetidores.Data.EF;
using GestionCompetidores.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompetidores.Data
{
    public class Repositorio : IRepositorio
    {
        private  GestionCompetidoresContext _contexto;
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
           return _contexto.Competidors.Include(e => e.IdDeporteNavigation).ToList();
        }

        public void AgregarDeporte(Deporte deporte)
        {
            _contexto.Deportes.Add(deporte);
            _contexto.SaveChanges();
        }

        public void EditarDeporte(Deporte deporteEditado)
        {
            Deporte deporte = BuscarDeportePorId(deporteEditado.IdDeporte);
            deporte.NombreDeporte = deporteEditado.NombreDeporte;
            _contexto.Deportes.Update(deporte);
            _contexto.SaveChanges();    
        }
        public Deporte BuscarDeportePorId(int Id)
        {
            Deporte deporte = _contexto.Deportes.FirstOrDefault(c => c.IdDeporte == Id);
            return deporte;
        }

        public Competidor BuscarCompetidorPorId(int Id)
        {
            Competidor competidor = _contexto.Competidors.FirstOrDefault(c => c.IdCompetidor == Id); 
            return competidor;
        }
        public void EditarCompetidor(Competidor competidorEditado)
        {
            Competidor competidor = BuscarCompetidorPorId(competidorEditado.IdCompetidor);
            if (competidor != null)
            {
                competidor.NombreCompetidor = competidorEditado.NombreCompetidor;
                competidor.IdDeporte = competidorEditado.IdDeporte;  
                _contexto.SaveChanges();
            }
        }

        public void EliminarCompetidor(int Id)
        {
            Competidor competidor = _contexto.Competidors.FirstOrDefault(c => c.IdCompetidor == Id);
            _contexto.Competidors.Remove(competidor);
            _contexto.SaveChanges();
        }

        public List<Competidor> BuscarCompetidoresPorIdDeporte(int id)
        {
            List<Competidor> listaCompetidoresPorIdDeporte = _contexto.Competidors.Include(j=>j.IdDeporteNavigation).Where(c => c.IdDeporte == id).ToList();
            return listaCompetidoresPorIdDeporte;
        }

        public void EliminarDeporteYCompetidor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
