namespace vitalapi.Models.Especialista
{
    public class EspecialistaEspecialidade
    {
        public int EspecialistaId { get; set; }
        public Especialista Especialista { get; set; }

        public Especialidade Especialidade { get; set; }
    }
}