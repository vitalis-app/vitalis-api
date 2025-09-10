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
            CreateMap<Agendamento, AgendamentoReadDto>()
                .ForMember(dest => dest.UsuarioNome, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.EspecialistaNome, opt => opt.MapFrom(src => src.Especialista.Nome));
            CreateMap<AgendamentoCreateDto, Agendamento>();

            // Assinatura
            CreateMap<AssinaturaCreateDto, Assinatura>();
            CreateMap<Assinatura, AssinaturaReadDto>();
            CreateMap<AssinaturaUpdateDto, Assinatura>();

            // Disponibilidade
            CreateMap<Disponibilidade, DisponibilidadeReadDto>()
                        .ForMember(dest => dest.HorarioInicio, opt => opt.MapFrom(src => src.HorarioInicio.ToString("HH:mm")))
                        .ForMember(dest => dest.HorarioFim, opt => opt.MapFrom(src => src.HorarioFim.ToString("HH:mm")));
            CreateMap<DisponibilidadeCreateDto, Disponibilidade>()
                .ForMember(dest => dest.HorarioInicio, opt => opt.MapFrom(src => DateTime.Parse(src.HorarioInicio)))
                .ForMember(dest => dest.HorarioFim, opt => opt.MapFrom(src => DateTime.Parse(src.HorarioFim)));

            // Especialista / Especialidade
            CreateMap<EspecialistaCreateDto, Especialista>()
                .ForMember(dest => dest.Especialidades, opt => opt.Ignore());
            CreateMap<Especialista, EspecialistaReadDto>();
            CreateMap<EspecialistaUpdateDto, Especialista>();
            CreateMap<Especialidade, EspecialidadeReadDto>();

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
