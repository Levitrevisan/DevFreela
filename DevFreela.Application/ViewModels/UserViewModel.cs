using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public String FullName { get; private set; }
        public String Email { get; private set; }

    }
}