using AutoMapper;
using ProjetoBaseCore.Application.ViewModels;
using ProjetoBaseCore.Domain.Entities;

namespace ProjetoBaseCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PessoaViewModel, Pessoa>()
                .ForMember(dest => dest.Cpf,
                opts => opts.MapFrom(src => src.CpfSemMascara))
                .ForMember(dest => dest.Telefone,
                opts => opts.MapFrom(src => src.TelefoneSemMascara));
            CreateMap<EnderecoViewModel, Endereco>()
                .ForMember(dest => dest.CEP,
                opts => opts.MapFrom(src => src.CEPSemMascara));
        }
    }
}