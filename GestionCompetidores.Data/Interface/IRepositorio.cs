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
        void GuardarCompetidor(Competidor competidor);
        List<Competidor> ListarCompetidores();
    }
}
