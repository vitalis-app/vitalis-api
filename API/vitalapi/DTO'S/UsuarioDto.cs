using vitalapi.Models.Usuario;

namespace vitalapi.DTO_S
{
    public class UsuarioCreateDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
    }
    public class UsuarioUpdateDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }
        public string? FotoPerfil { get; set; }
        public int? PlanoId { get; set; }
    }
    public class UsuarioReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string FotoPerfil { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public int AssinaturaAtivaId { get; set; }
    }

    public class UsuarioConquistaReadDto
    {
        public int ProgressoConquista { get; set; }
        public DateTime DataConclusao { get; set; }
        public StatusPendencia StatusConquista { get; set; }
    }

    public class UsuarioMissaoReadDto
    {
        public int MissaoId { get; set; }
        public int MissaoNome { get; set; }
        public int ProgressoConquista { get; set; }
        public bool isConluida { get; set; }
    }
}
