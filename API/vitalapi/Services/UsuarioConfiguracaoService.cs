using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.DTO_S;
using vitalapi.Models.Usuario;
namespace vitalapi.Services
{
    public class UsuarioConfiguracaoService
    {
        private readonly VitalContext _context;
        private readonly IMapper _mapper;
    }
}