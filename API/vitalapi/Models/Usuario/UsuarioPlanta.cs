using vitalapi.Models.EstacaoVital;

namespace vitalapi.Models.Usuario
{
    public class UsuarioPlanta
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int PlantaId { get; set; }
        public Planta Planta { get; set; }

        public string Nome { get; set; }
        public DateTime DataPlantio { get; set; }
        public DateTime UltimaRega { get; set; }
        public bool PodeRegar => UltimaRega.Date < DateTime.Today;
        public int Nivel { get; set; }
        public int XP { get; set; }
    }
}