namespace vitalapi.Models.Usuario.Conquistas
{
    public class ProgressoConquistaUsuario
    {
        public int Id { get; set; }
        public int ConquistaId { get; set; }
        public Conquista Conquista { get; set; }
        public int ProgressoAtual { get; set; }
        public bool Concluida { get; set; }
        public DateTime? DataConcluida { get; set; }
    }
}