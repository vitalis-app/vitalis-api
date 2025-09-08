using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Usuario;
namespace vitalapi.Services
{
    public class UsuarioPlantaService
    {
        private readonly VitalContext _context;
        private readonly IMapper _mapper;

        public UsuarioPlantaService(VitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioPlantaReadDto>> GetByUsuarioAsync(int usuarioId)
        {
            var plantas = await _context.UsuarioPlantas
                .Where(up => up.UsuarioId == usuarioId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UsuarioPlantaReadDto>>(plantas);
        }

        public async Task<UsuarioPlantaReadDto> GetAsync(int usuarioId, int plantaId)
        {
            var planta = await _context.UsuarioPlantas
                .FirstOrDefaultAsync(up => up.UsuarioId == usuarioId && up.PlantaId == plantaId);

            if (planta == null) return null;

            return _mapper.Map<UsuarioPlantaReadDto>(planta);
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

        public async Task<bool> DeleteAsync(int usuarioId, int plantaId)
        {
            var entity = await _context.UsuarioPlantas
                .FirstOrDefaultAsync(up => up.UsuarioId == usuarioId && up.PlantaId == plantaId);

            if (entity == null) return false;

            _context.UsuarioPlantas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}