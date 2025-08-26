using AutoMapper;
using vitalapi.DTO_S;
using vitalapi.Models.Especialista;
using vitalapi.Models.Assinatura;
using vitalapi.Models.Usuario;

namespace vitalapi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AgendamentoDto, Agendamento>();
            CreateMap<AssinaturaDto, Assinatura>();
            CreateMap<DisponibilidadeDto,Disponibilidade>();
            CreateMap<EnderecoDto,Endereco>();
            CreateMap<EspecialistaDto, Especialista>();
            CreateMap<PlanoDto,Plano>();    
            CreateMap<UsuarioDto, Usuario>();
        }

    }
}
