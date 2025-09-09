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
            // Agendamento
            CreateMap<AgendamentoCreateDto, Agendamento>();
            CreateMap<Agendamento, AgendamentoReadDto>()
                .ForMember(dest => dest.EspecialistaNome,
                    opt => opt.MapFrom(src => src.Especialista.Nome));
            CreateMap<AgendamentoUpdateDto, Agendamento>();

            // Assinatura
            CreateMap<AssinaturaCreateDto, Assinatura>();
            CreateMap<Assinatura, AssinaturaReadDto>();
            CreateMap<AssinaturaUpdateDto, Assinatura>();

            // Disponibilidade
            CreateMap<DisponibilidadeCreateDto, Disponibilidade>();
            CreateMap<Disponibilidade, DisponibilidadeReadDto>();
            CreateMap<DisponibilidadeUpdateDto, Disponibilidade>();

            // Especialista / Especialidade
            CreateMap<EspecialistaCreateDto, Especialidade>();
            CreateMap<Especialidade, EspecialistaReadDto>();
            CreateMap<EspecialistaUpdateDto, Especialidade>();

            // Usuario
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<Usuario, UsuarioReadDto>();
            CreateMap<UsuarioUpdateDto, Usuario>();

            // Relacionamentos
            CreateMap<UsuarioMissaoReadDto, UsuarioMissao>();
            CreateMap<UsuarioConquistaReadDto, UsuarioConquista>();
            CreateMap<UsuarioPlantaReadDto, UsuarioPlanta>();
            CreateMap<UsuarioPlantaUpdateDto, UsuarioPlanta>();
        }
    }
}
