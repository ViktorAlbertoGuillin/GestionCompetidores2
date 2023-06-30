﻿using GestionCompetidores.Data.EF;
using GestionCompetidores.Data.Interface;
using GestionCompetidores.Servicio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompetidores.Servicio
{
    public class CompetidorServicio : ICompetidorServicio
    {
        private readonly IRepositorio _repositorio;
        public CompetidorServicio(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public void GuardarCompetidor(Competidor competidor)
        {
            _repositorio.GuardarCompetidor(competidor);
        }

        public List<Competidor> ListarCompetidores()
        {
            return _repositorio.ListarCompetidores();
        }
    }
}