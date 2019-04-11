using _14NET.ProjetoMasterChef.Application.ViewModels;
using _14NET.ProjetoMasterChef.Domain.Entities;
using AutoMapper;

namespace _14NET.ProjetoMasterChef.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<ReceitaViewModel, Receita>()
                .ForMember(x => x.Categoria, opt => opt.Ignore())
                .ForMember(x => x.CategoriaId, opt => opt.MapFrom(src => src.Categoria.Id));   
            
            CreateMap<CreateUpdateReceitaViewModel, Receita>();              
        }
    }
}
