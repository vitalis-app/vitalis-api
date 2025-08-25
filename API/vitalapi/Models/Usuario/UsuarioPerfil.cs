namespace vitalapi.Models.Usuario
{
    public class UsuarioPerfil
    {
        public int Id { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public string FotoPerfil { get; set; }

        public int PlanoId { get; set; }
        public Plano Plano { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}