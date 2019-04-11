using _14NET.ProjetoMasterChef.Domain.Entities;
using _14NET.ProjetoMasterChef.Domain.Interfaces.Repository;
using _14NET.ProjetoMasterChef.Infra.Data.Context;
using _14NET.ProjetoMasterChef.Infra.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _14NET.ProjetoMasterChef.Infra.Data.Repository
{
    public class ReceitaRepository : RepositoryBase<Receita>,  IReceitaRepository
    {
        public ReceitaRepository(MasterChefContext context)
            :base(context)
        {

        }
    }
}
