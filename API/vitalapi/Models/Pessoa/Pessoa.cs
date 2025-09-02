namespace vitalapi.Models.Pessoa
{
    public abstract class PessoaBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } // TO-DO: Fazer hash da senha
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public string FotoPerfil { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}