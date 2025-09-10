using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Configuracao;
using vitalapi.Models.EstacaoVital; // Adicionado para ter acesso à Planta
using vitalapi.Models.Usuario;

namespace vitalapi.Services
{
    public class UsuarioService
    {
        private readonly VitalContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(VitalContext vitalcontext, IMapper mapper)
        {
            _context = vitalcontext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioReadDto>> GetAllAsync()
        {
            var items = await _context.Usuarios.ToListAsync();
            return _mapper.Map<IEnumerable<UsuarioReadDto>>(items);
        }

        public async Task<UsuarioReadDto> GetByIdAsync(int id)
        {
            var item = await _context.Usuarios
                .Include(u => u.Progresso)
                .FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<UsuarioReadDto>(item);
        }

        public async Task<UsuarioReadDto> CreateAsync(UsuarioCreateDto dto)
        {
            var entity = _mapper.Map<Usuario>(dto);

            entity.Senha = HashPassword(dto.Senha);
            entity.DataCriacao = DateTime.UtcNow;

            entity.Progresso = new UsuarioProgresso
            {
                XPTotal = 0,
                DiasAtivosStreak = 0,
                UltimaAtividade = DateTime.UtcNow,
            };

            entity.Configuracoes = new UsuarioConfiguracao
            {
                PreferenciaNotificacoes = new NotificacaoConfig
                {
                    AlertaDiarioAtivo = true,
                    LembreteSessaoAtivo = true
                }
            };

            // Lógica para criar a planta inicial
            var primeiraPlanta = await _context.Plantas.OrderBy(p => p.Id).FirstOrDefaultAsync();
            if (primeiraPlanta != null)
            {
                var usuarioPlanta = new UsuarioPlanta
                {
                    Usuario = entity,
                    PlantaId = primeiraPlanta.Id,
                    Nome = "Plantinha",
                    DataPlantio = DateTime.UtcNow,
                    UltimaRega = DateTime.UtcNow,
                    Nivel = 1,
                    XP = 0
                };
                entity.UsuarioPlantas.Add(usuarioPlanta);
            }

            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioReadDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return false;

            if (!string.IsNullOrEmpty(dto.Senha))
            {
                dto.Senha = HashPassword(dto.Senha);
            }

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return false;

            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private string HashPassword(string password)
        {
            // Substitua pela sua implementação real de Hashing
            return "HASHED_" + password;
        }
    }
}