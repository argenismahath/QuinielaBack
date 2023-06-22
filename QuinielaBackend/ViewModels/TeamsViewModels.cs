using QuinielaBackend.Models;

namespace QuinielaBackend.ViewModels
{
    public class TeamsViewModels
    {
        public Guid PublicKey { get; set; }
        public String Name { get; set; }
        public String Img { get; set; }
        public bool Lock { get; set; }

       
    }

    public class CreateNewTeam : TeamsViewModels
    {
        public Teams CreateNewTeamVM(CreateNewTeam createNewTeam)
        {
            Teams team = new Teams
            {
                PublicKey = Guid.NewGuid(),
                Name = createNewTeam.Name,
                Img = createNewTeam.Img,
                Lock = createNewTeam.Lock
            };
            return team;
        }


    }

    public class WeekTable
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int Points { get; set; }
    }
}
