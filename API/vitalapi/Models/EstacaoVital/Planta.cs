using vitalapi.Models.Usuario;
namespace vitalapi.Models.EstacaoVital
{
    public class Planta
    {
        public int Id { get; set; }
        ICollection<UsuarioPlanta> UsuarioPlantas { get; set; }
        public string Foto { get; set; }
    }
}