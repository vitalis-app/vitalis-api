using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Especialista;
using vitalapi.Models.EstacaoVital;
using vitalapi.Models.Usuario;
namespace vitalapi.Services
{
    public class RegistroEmocionalService
    {
        private readonly VitalContext _context;
        private readonly IMapper _mapper;

        public async Task<RegistroEmocionalReadDto> CreateAsync(RegistroEmocionalCreateDto dto)
        {
            var entity = _mapper.Map<RegistroEmocional>(dto);
            await _context.RegistrosEmocionais.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<RegistroEmocionalReadDto>(entity);
        }

        public async Task<bool> RegarAsync(int usuarioId, int plantaId)
        {
            const int XpBase = 100;
            const int XpMax = 200;
            const int XpPorNivel = 100;

            var playerTask = _context.UsuarioProgressos
                .FirstOrDefaultAsync(up => up.Id == usuarioId);

            var plantaTask = _context.UsuarioPlantas
                .FirstOrDefaultAsync(up => up.UsuarioId == usuarioId && up.PlantaId == plantaId);

            var player = await playerTask;
            var plantaDoUsuario = await plantaTask;

            if (plantaDoUsuario == null || !plantaDoUsuario.PodeRegar || player == null)
                return false;

            plantaDoUsuario.UltimaRega = DateTime.Today;
            plantaDoUsuario.XP += Math.Min(XpBase + (player.DiasAtivosStreak * 5), XpMax);

            if (player.UltimaAtividade < DateTime.Today)
            {
                player.DiasAtivosStreak++;
                player.UltimaAtividade = DateTime.Today;
            }

            if (plantaDoUsuario.XP >= plantaDoUsuario.Nivel * XpPorNivel)
            {
                plantaDoUsuario.XP = 0;
                plantaDoUsuario.Nivel++;
            }

            await _context.SaveChangesAsync();
            return true;
        }

    }
}