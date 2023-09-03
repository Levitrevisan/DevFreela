using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserServices(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateUser(NewUserInputModel user)
        {
            var newUser = new User(user.Fullname, user.Email, user.Birthdate, user.Password);

            _dbContext.Users.Add(newUser);

            _dbContext.SaveChanges();

            return newUser.Id;
        }

        public UserViewModel? GetById(int Id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == Id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email); ;

        }

        public int LoginAsync(LoginInputModel credentials)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == credentials.email);

            if (user == null | credentials.password == user.Password)
            {
                return 0;
            }
            else
            {
                return user.Id;
            }
        }
    }
}
