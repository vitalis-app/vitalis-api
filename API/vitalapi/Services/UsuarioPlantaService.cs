using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.EstacaoVital;
using vitalapi.Models.Usuario;

namespace vitalapi.Services
{
    public class UsuarioPlantaService
    {
        private readonly VitalContext _context;
        private readonly IMapper _mapper;
        private const int NIVEL_MAXIMO_PARA_CONCLUSAO = 5;
        private const int XP_REGA_BASE = 25;
        private const int XP_BASE_LEVEL_UP = 100;

        public UsuarioPlantaService(VitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<object> RegarPlantaAtivaAsync(int usuarioId)
        {
            var plantaAtiva = await _context.UsuarioPlantas
                .Include(up => up.Planta)
                .FirstOrDefaultAsync(up => up.UsuarioId == usuarioId);

            var usuarioProgressoAtivo = await _context.UsuarioProgressos
                .FirstOrDefaultAsync(u => u.Id == usuarioId);

            int multiplicador = usuarioProgressoAtivo.DiasAtivosStreak == 0 ? 1 : usuarioProgressoAtivo.DiasAtivosStreak;
            int xpRega = XP_REGA_BASE * multiplicador;
            
            if (plantaAtiva == null)
                return new { success = false, message = "Nenhuma planta ativa encontrada para regar." };

            if (!plantaAtiva.PodeRegar)
                return new { success = false, message = "Aguarde até amanhã para regar novamente." };

            plantaAtiva.UltimaRega = DateTime.UtcNow;
            plantaAtiva.XP += xpRega;

            bool subiuDeNivel = false;
            bool concluiuPlanta = false;
            UsuarioPlanta novaPlanta = null;

            int xpParaProximoNivel = plantaAtiva.Nivel * XP_BASE_LEVEL_UP;
            if (plantaAtiva.XP >= xpParaProximoNivel)
            {
                plantaAtiva.Nivel++;
                subiuDeNivel = true;
            }

            if (plantaAtiva.Nivel >= NIVEL_MAXIMO_PARA_CONCLUSAO)
            {
                concluiuPlanta = true;
                novaPlanta = await AtribuirNovaPlantaAoUsuarioAsync(usuarioId);
            }

            await _context.SaveChangesAsync();

            return new
            {
                success = true,
                message = "Planta regada com sucesso!",
                plantaAtualizada = _mapper.Map<UsuarioPlantaReadDto>(plantaAtiva),
                subiuDeNivel,
                concluiuPlanta,
                novaPlantaAdotada = novaPlanta != null ? _mapper.Map<UsuarioPlantaReadDto>(novaPlanta) : null
            };
        }

        private async Task<UsuarioPlanta> AtribuirNovaPlantaAoUsuarioAsync(int usuarioId)
        {
            var idsPlantasDoUsuario = await _context.UsuarioPlantas
                .Where(up => up.UsuarioId == usuarioId)
                .Select(up => up.PlantaId)
                .ToListAsync();

            var proximaPlanta = await _context.Plantas
                .Where(p => !idsPlantasDoUsuario.Contains(p.Id))
                .OrderBy(p => p.Id)
                .FirstOrDefaultAsync();

            if (proximaPlanta == null) return null;

            var novaUsuarioPlanta = new UsuarioPlanta
            {
                UsuarioId = usuarioId,
                PlantaId = proximaPlanta.Id,
                Nome = "Plantinha",
                DataPlantio = DateTime.UtcNow,
                UltimaRega = DateTime.UtcNow,
                Nivel = 1,
                XP = 0
            };

            _context.UsuarioPlantas.Add(novaUsuarioPlanta);
            return novaUsuarioPlanta;
        }

        public async Task<IEnumerable<UsuarioPlantaReadDto>> GetByUsuarioAsync(int usuarioId)
        {
            var plantas = await _context.UsuarioPlantas
                .Where(up => up.UsuarioId == usuarioId)
                .Include(up => up.Planta)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UsuarioPlantaReadDto>>(plantas);
        }

        public async Task<bool> UpdateAsync(int usuarioId, int plantaId, UsuarioPlantaUpdateDto dto)
        {
            var entity = await _context.UsuarioPlantas
                .FirstOrDefaultAsync(up => up.UsuarioId == usuarioId && up.PlantaId == plantaId);

            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}