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
    public class ReceitaAppService : IReceitaAppService
    {
        private readonly IReceitaService _receitaService;
        private readonly IMapper _mapper;

        public ReceitaAppService(IReceitaService receitaService, IMapper mapper)
        {
            _receitaService = receitaService;
            _mapper = mapper;
        }

        public ReceitaViewModel Adicionar(ReceitaViewModel receitaViewModel)
        {
            var receita = _mapper.Map<Receita>(receitaViewModel);

            var retorno = _receitaService.Create(receita);

            var viewModel = _mapper.Map<ReceitaViewModel>(retorno);

            return viewModel;
        }

        public void Atualizar(ReceitaViewModel receitaViewModel)
        {

            var receita = _mapper.Map<Receita>(receitaViewModel);
            _receitaService.Update(receita);
        }

        public void Dispose()
        {
            _receitaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public ReceitaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<ReceitaViewModel>(_receitaService.GetById(id));
        }

        public async Task<IEnumerable<ReceitaViewModel>> ObterTodos()
        {
            var retorno = await _receitaService.GetAll();

            return _mapper.Map<List<Receita>, List<ReceitaViewModel>>(retorno);
        }

        public void Remover(Guid id)
        {
            _receitaService.Delete(id); ;
        }
    }
}
