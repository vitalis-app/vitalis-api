using Microsoft.Extensions.Diagnostics.HealthChecks;
using vitalapi.Models.Usuario;

namespace vitalapi.Models
{
    public class Planta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Nivel { get; set; }
        public int XP { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public DateTime DataPlantio { get; set; }
        public int UsuarioId { get; set; }
        public Usuario.Usuario Usuario { get; set; }

        public DateTime UltimaRega { get; set; }
        public bool PodeRegar => UltimaRega.Date < DateTime.Today;
    }
}