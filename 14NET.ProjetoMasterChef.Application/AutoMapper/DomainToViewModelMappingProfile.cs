using _14NET.ProjetoMasterChef.Application.ViewModels;
using _14NET.ProjetoMasterChef.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace _14NET.ProjetoMasterChef.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Receita, ReceitaViewModel>().ForMember(x => x.Foto, opt => opt.Ignore());
            CreateMap<Receita, CreateUpdateReceitaViewModel>();
        }       
    }
}