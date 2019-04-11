using _14NET.ProjetoMasterChef.Application.Interfaces;
using _14NET.ProjetoMasterChef.Application.ViewModels;
using _14NET.ProjetoMasterChef.Domain.Entities;
using _14NET.ProjetoMasterChef.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _14NET.ProjetoMasterChef.Application
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaAppService(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public CategoriaViewModel Adicionar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);

            var retorno = _categoriaService.Create(categoria);

            categoriaViewModel = _mapper.Map<CategoriaViewModel>(retorno);

            return categoriaViewModel;
        }

        public void Atualizar(CategoriaViewModel categoriaViewModel)
        {
            _categoriaService.Update(_mapper.Map<Categoria>(categoriaViewModel));           
        }

        public void Dispose()
        {
            _categoriaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public CategoriaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(_categoriaService.GetById(id));
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            var retorno = await _categoriaService.GetAll();

            return _mapper.Map<List<CategoriaViewModel>>(retorno);
        }

        public void Remover(Guid id)
        {
            _categoriaService.Delete(id);
        }
    }
}
