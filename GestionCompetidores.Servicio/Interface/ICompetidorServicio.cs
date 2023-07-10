using GestionCompetidores.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompetidores.Servicio.Interface
{
    public interface ICompetidorServicio
    {
        void GuardarCompetidor(Competidor competidor);
        List<Competidor> ListarCompetidores();
        Competidor BuscarCompetidorPorId(int Id);
        void EditarCompetidor(Competidor competidor);
        void EliminarCompetidor(int Id);
        List<Competidor> BuscarCompetidoresPorIdDeporte(int IdDeporte);
    }
}
