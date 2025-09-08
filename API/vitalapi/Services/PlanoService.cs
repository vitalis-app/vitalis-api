using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Assinatura;
namespace vitalapi.Services
{
    public class PlanoService
    {
        private readonly VitalContext _context;
        private readonly IMapper _mapper;

        public PlanoService(VitalContext vitalcontext, IMapper mapper)
        {
            _context = vitalcontext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlanoReadDto>> GetAllAsync()
        {
            var items = await _context.Planos.ToListAsync();
            return _mapper.Map<IEnumerable<PlanoReadDto>>(items);
        }

        public async Task<PlanoReadDto> GetByIdAsync(int id)
        {
            var item = await _context.Planos.FindAsync(id);
            return _mapper.Map<PlanoReadDto>(item);
        }
    }
}
