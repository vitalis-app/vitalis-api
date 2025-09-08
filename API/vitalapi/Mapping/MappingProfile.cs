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

            CreateMap<AssinaturaReadDto, Assinatura>();
            CreateMap<AssinaturaCreateDto, Assinatura>();
            CreateMap<AssinaturaUpdateDto, Assinatura>();

            CreateMap<DisponibilidadeCreateDto, Disponibilidade>();
            CreateMap<DisponibilidadeReadDto, Disponibilidade>();
            CreateMap<DisponibilidadeUpdateDto, Disponibilidade>();

            CreateMap<EspecialistaCreateDto, Especialidade>();
            CreateMap<EspecialistaReadDto, Especialidade>();
            CreateMap<EspecialistaUpdateDto, Especialidade>();

            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<UsuarioReadDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();

            CreateMap<UsuarioMissaoReadDto, UsuarioMissao>();
            CreateMap<UsuarioConquistaReadDto, UsuarioConquista>();
            
            CreateMap<UsuarioPlantaReadDto, UsuarioPlanta>();
            CreateMap<UsuarioPlantaUpdateDto, UsuarioPlanta>();
        }
    }
}
