using _14NET.ProjetoMasterChef.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _14NET.ProjetoMasterChef.Application.Interfaces
{
    public interface IReceitaAppService : IDisposable
    {
        ReceitaViewModel Adicionar(ReceitaViewModel receitaViewModel);
        ReceitaViewModel ObterPorId(Guid id);
        Task<IEnumerable<ReceitaViewModel>> ObterTodos();
        void Atualizar(ReceitaViewModel receitaViewModel);
        void Remover(Guid id);
    }
}
