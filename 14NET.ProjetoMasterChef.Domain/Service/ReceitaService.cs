using _14NET.ProjetoMasterChef.Domain.Entities;
using _14NET.ProjetoMasterChef.Domain.Interfaces.Repository;
using _14NET.ProjetoMasterChef.Domain.Interfaces.Services;
using _14NET.ProjetoMasterChef.Domain.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _14NET.ProjetoMasterChef.Domain.Service
{
    public class ReceitaService : ServiceBase<Receita>, IReceitaService
    {
        private readonly IReceitaRepository _repository;

        public ReceitaService(IReceitaRepository repository)
            :base(repository)
        {
            _repository = repository;
        }
    }
}
