namespace vitalapi.Models.Usuario
{
    public class UsuarioHumor
    {
        public int Id { get; set; }
        public Humor Humor { get; set; }

        public int UsuarioProgressoId { get; set; }
        public UsuarioProgresso UsuarioProgresso { get; set; }
    }
}