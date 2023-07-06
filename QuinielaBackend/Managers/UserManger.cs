using Microsoft.EntityFrameworkCore;
using QuinielaBackend.Models;
using QuinielaBackend.ViewModels;

namespace QuinielaBackend.Managers
{
    public class UserManager
    {
        #region DI
        private DbContextQuiniela _DbContext;

        public UserManager(DbContextQuiniela dbContext)
        {
            _DbContext = dbContext;
        }
        #endregion
        public async Task<bool> AddNueUser(CreateNewUser model)
        {
            Users users = new Users
            {
                CreateAt = DateTime.Now,
                Email = model.Email,
                Lock = model.Lock,
                Name = model.Name,
                Password = model.Password,
                Username = model.Username
            };
            await _DbContext.Users.AddAsync(users);
            await _DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Users> GetUserByUserName(String userName)
        {
         
                var userdata = await _DbContext.Users.FirstOrDefaultAsync(U => U.Username == userName);
                if (userdata == null)
                {
                    return userdata;
                }
                else
                {
                userdata.Password = string.Empty;
                userdata.CreateAt = DateTime.Today;
                userdata.Email = string.Empty;
                    return userdata;
                }
           
        }

        public async Task<bool> UserRecord(String userName, String password)
        {
            bool record= await _DbContext.Users.AnyAsync(u=>u.Username == userName && u.Password==password);

            return record;
        }
    }

}
