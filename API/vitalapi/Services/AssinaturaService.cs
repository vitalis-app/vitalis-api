using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Assinatura;
namespace vitalapi.Services
{
    public class AssinaturaService
    {
        private readonly VitalContext _context;
        private readonly IMapper _mapper;

        public AssinaturaService(VitalContext vitalcontext, IMapper mapper)
        {
            _context = vitalcontext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssinaturaReadDto>> GetAllAsync()
        {
            var items = await _context.Assinaturas.ToListAsync();
            return _mapper.Map<IEnumerable<AssinaturaReadDto>>(items);
        }

        public async Task<AssinaturaReadDto> GetByIdAsync(int id)
        {
            var item = await _context.Assinaturas.FindAsync(id);
            return _mapper.Map<AssinaturaReadDto>(item);
        }

        public async Task<AssinaturaCreateDto> CreateAsync(AssinaturaCreateDto dto)
        {
            var entity = _mapper.Map<Assinatura>(dto);
            _context.Assinaturas.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AssinaturaCreateDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, AssinaturaUpdateDto dto)
        {
            var entity = await _context.Assinaturas.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Assinaturas.FindAsync(id);
            if (entity == null) return false;

            _context.Assinaturas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
