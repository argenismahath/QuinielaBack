using QuinielaBackend.Models;

namespace QuinielaBackend.ViewModels
{
    public class GamesViewModels
    {
        public Guid PublicKey { get; set; }
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set; }
        public DateTime StartHour { get; set; }
        public bool Lock { get; set; }
        public int JourneyNumber { get; set; }
        public String GameTitle { get; set; }
        public int? ScoreTeam1 { get; set; }
        public int? ScoreTeam2 { get; set; }

        public String Link { get; set; }

    }

    public class CreateNewGame : GamesViewModels
    {
        public Games CreateNewGameVM(CreateNewGame data)
        {
            Games games = new Games
            {
                PublicKey = Guid.NewGuid(),
                GameTitle = data.GameTitle,
                ScoreTeam1 = data.ScoreTeam1,
                ScoreTeam2 = data.ScoreTeam2,
                JourneyNumber = data.JourneyNumber,
                StartHour = data.StartHour,
                Lock = data.Lock,
                TeamId1 = data.TeamId1,
                TeamId2 = data.TeamId2,
            };
            return games;
        }

    }

    public class GetGameVM
    {
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set; }
        public DateTime StartHour { get; set; }
        public bool Lock { get; set; }
        public int? ScoreTeam1 { get; set; }
        public int? ScoreTeam2 { get; set; }
        public String GameTitle { get; set; }
        public String img1 { get; set; }
        public String img2 { get; set; }
        public int? Points { get; set; }
        public String Link { get; set; } 
    }
}
