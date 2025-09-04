namespace vitalapi.Models.Usuario
{
    public class UsuarioSessao
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime ComecoSessao { get; set; }
        public DateTime FimSessao { get; set; }
        public bool IsActive { get; set; }

        // TO-DO:
        // Gerar token JWT
        // public string Token { get; set; }
    }
}