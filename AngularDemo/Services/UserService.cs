using AngularDemo.Models;
using AngularDemo.Repositories;

namespace AngularDemo.Services;

public class UserService : IUserService
{
    private readonly IUserRepositry _repositry;
    public UserService(IUserRepositry repositry)
    {
        _repositry = repositry;
    }

    public async Task<bool> Create(User user)
    {
        int rowsAffected = await _repositry.Create(user);
        return rowsAffected > 0;
    }

    public async Task<User> Get(string Email)
    {
        var user = await _repositry.Get(Email);
        return user;
    }

    public async Task<bool> IsValidUser(string Email, string Password)
    {
        var user = await _repositry.Get(Email, Password);
        return user != null;
    }
}
