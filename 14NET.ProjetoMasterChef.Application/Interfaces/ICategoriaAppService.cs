using _14NET.ProjetoMasterChef.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _14NET.ProjetoMasterChef.Application.Interfaces
{
    public interface ICategoriaAppService : IDisposable
    {
        CategoriaViewModel Adicionar(CategoriaViewModel categoriaViewModel);
        CategoriaViewModel ObterPorId(Guid id);
        Task<IEnumerable<CategoriaViewModel>> ObterTodos();
        void Atualizar(CategoriaViewModel categoriaViewModel);
        void Remover(Guid id);       
    }
}
