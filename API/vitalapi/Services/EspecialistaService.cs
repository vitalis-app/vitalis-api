using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Configuracao;
using vitalapi.Models.Especialista;

namespace vitalapi.Services
{
    public class EspecialistaService
    {
        private readonly VitalContext _context;
        private readonly IMapper _mapper;

        public EspecialistaService(VitalContext vitalcontext, IMapper mapper)
        {
            _context = vitalcontext;
            _mapper = mapper;
        }

        public async Task<EspecialistaReadDto> CreateAsync(EspecialistaCreateDto dto)
        {
            var entity = _mapper.Map<Especialista>(dto);

            entity.Senha = HashPassword(dto.Senha);
            entity.DataCriacao = DateTime.UtcNow;
            entity.AvaliacaoMedia = 0;

            entity.Configuracoes = new EspecialistaConfiguracao
            {
                PreferenciaNotificacoes = new NotificacaoConfig()
            };

            if (dto.EspecialidadeIds != null && dto.EspecialidadeIds.Any())
            {
                var especialidades = await _context.Especialidades
                    .Where(e => dto.EspecialidadeIds.Contains(e.EspecialistaId))
                    .ToListAsync();
                entity.Especialidades = especialidades;
            }

            _context.Especialistas.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<EspecialistaReadDto>(entity);
        }

        public async Task<IEnumerable<EspecialistaReadDto>> GetAllAsync()
        {
            var items = await _context.Especialistas
                .Include(e => e.Especialidades)
                .ToListAsync();
            return _mapper.Map<IEnumerable<EspecialistaReadDto>>(items);
        }

        public async Task<EspecialistaReadDto> GetByIdAsync(int id)
        {
            var item = await _context.Especialistas
                .Include(e => e.Especialidades) 
                .FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<EspecialistaReadDto>(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Especialistas.FindAsync(id);
            if (entity == null) return false;

            _context.Especialistas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private string HashPassword(string password)
        {
            return "HASHED_" + password;
        }
    }
}