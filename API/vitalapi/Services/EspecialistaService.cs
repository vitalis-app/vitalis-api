using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
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

        public async Task<IEnumerable<EspecialistaReadDto>> GetAllAsync()
        {
            var items = await _context.Especialistas.ToListAsync();
            return _mapper.Map<IEnumerable<EspecialistaReadDto>>(items);
        }

        public async Task<EspecialistaReadDto> GetByIdAsync(int id)
        {
            var item = await _context.Especialistas.FindAsync(id);
            return _mapper.Map<EspecialistaReadDto>(item);
        }
    }

}
