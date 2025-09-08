using UsuarioModel = vitalapi.Models.Usuario.Usuario;


namespace vitalapi.Models.Especialista
{
    public class Agendamento
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        public int EspecialistaId { get; set; }
        public Especialista Especialista { get; set; }

        public DateTime DataHora { get; set; }
        public StatusPendencia StatusAtual { get; set; }
        public decimal ValorPago { get; set; }
    }
}