using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
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
            var item = await _context.Usuarios.FindAsync(id);
            return _mapper.Map<UsuarioReadDto>(item);
        }

        public async Task<UsuarioCreateDto> CreateAsync(UsuarioCreateDto dto)
        {
            var entity = _mapper.Map<Usuario>(dto);
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioCreateDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return false;

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
    }

}
