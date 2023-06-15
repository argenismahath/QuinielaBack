namespace QuinielaBackend.Models
{
    public class Teams
    {
        public int Id { get; set; }
        public Guid PublicKey { get; set; }
        public String Name { get; set; }
        public String Img { get; set; }
        public bool Lock { get; set; }
    }
}
