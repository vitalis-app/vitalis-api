public class Tag
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ICollection<Video> Videos { get; set; }
}