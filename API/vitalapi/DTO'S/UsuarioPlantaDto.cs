namespace vitalapi.DTO_S
{
    public class UsuarioPlantaReadDto
    {
        public int PlantaId { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public DateTime DataPlantio { get; set; }
        public DateTime UltimaRega { get; set; }
        public bool PodeRegar { get; set; }
        public int Nivel { get; set; }
        public int XP { get; set; }
    }
    public class UsuarioPlantaUpdateDto
    {
        public string Nome { get; set; }
    }
}
