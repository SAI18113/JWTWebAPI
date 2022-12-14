using AngularDemo.Models;

namespace AngularDemo.Repositories;

public interface IUserRepositry
{
    Task<int> Create(User user);
    Task<User> Get(string Email, string Password);
    Task<int> Delete(int id);
    Task<User> Get(string Email);

}
