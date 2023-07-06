namespace QuinielaBackend.Models
{
    public class Games
    {
        public int Id { get; set; }
        public Guid PublicKey { get; set; }
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set;}
        public DateTime StartHour { get; set; }
        public bool Lock { get; set; }
        public int JourneyNumber { get; set; }
        public String GameTitle { get; set; }
        public int? ScoreTeam1 { get; set; }
        public int? ScoreTeam2 { get; set; }
        public String? Link { get; set; }
        public IEnumerable<RecordTable> RecordsTables { get; set; }
        public IEnumerable<Teams> Teams { get; set; }

    }
}
