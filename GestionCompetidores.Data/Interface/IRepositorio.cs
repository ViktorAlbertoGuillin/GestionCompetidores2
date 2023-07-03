using GestionCompetidores.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompetidores.Data.Interface
{
    public interface IRepositorio
    {
        
        List<Deporte> ListarDeportes();
        List<Competidor> ListarCompetidores();

        void GuardarCompetidor(Competidor competidor);
        void AgregarDeporte(Deporte deporte);

        void EditarDeporte(Deporte deporte);
        void EditarCompetidor(Competidor competidor);

        Deporte BuscarDeportePorId(int Id);
        Competidor BuscarCompetidorPorId(int Id);
        
    }
}
