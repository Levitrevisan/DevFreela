using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserServices
    {
        UserViewModel GetById(int Id);

        int CreateUser(NewUserInputModel user);

        int LoginAsync(LoginInputModel credentials);

    }
}
