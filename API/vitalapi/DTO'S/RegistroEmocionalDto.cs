namespace vitalapi.DTO_S
{
    public class RegistroEmocionalCreateDto
    {
        public Humor HumorRegistrado { get; set; }
        public string ConfissaoUsuario { get; set; }
    }

    public class RegistroEmocionalReadDto
    {
        public Humor HumorRegistrado { get; set; }
        public string ConfissaoUsuario { get; set; }
        public DateTime DiaRegistrado { get; set; }
    }
}
