using QuinielaBackend.Models;

namespace QuinielaBackend.ViewModels
{
    public class UserViewModels
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public bool Lock { get; set; }

       
    }

    public class CreateNewUser : UserViewModels
    {
        public Users CreateNewUserVM(CreateNewUser createNewUser)
        {
            Users users = new Users
            {
                //PublicKey = Guid.NewGuid(),
                Name = createNewUser.Name,
                Lock = createNewUser.Lock,
                Password= createNewUser.Password,
                Email = createNewUser.Email,
                Username = createNewUser.Username,
            };
            return users;
        }


    }

}
