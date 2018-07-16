using AutoMapper;
using ProjetoBaseCore.Application.ViewModels;
using ProjetoBaseCore.Domain.Entities;

namespace ProjetoBaseCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}