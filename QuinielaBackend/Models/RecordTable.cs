namespace QuinielaBackend.Models
{
    public class RecordTable
    {
        public int Id { get; set; }
        public Guid PublicKey { get; set; }
        //public int UsersId { get; set; }
        //public int GamesId { get; set; }
        public DateTime RecordDate { get; set; }
        public int PredictTeam1 { get; set; }
        public int PredictTeam2 { get; set; }
        public Games Games { get; set; }
        public Users Users { get; set; }
    }
}
