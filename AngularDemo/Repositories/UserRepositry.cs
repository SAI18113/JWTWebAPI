using AngularDemo.Data;
using AngularDemo.Models;

namespace AngularDemo.Repositories;

public class UserRepositry : IUserRepositry
{
    private readonly ApplicationDbContext _db;
    public UserRepositry(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<int> Create(User user)
    {
        _db.Users.Add(user);
        int rowsAffected = await _db.SaveChangesAsync();
        return rowsAffected;
    }

    public async Task<int> Delete(int id)
    {
        var std = _db.Users.Where(x => x.Id == id).FirstOrDefault();
        _db.Users.Remove(std);
        int rowsAffected = await _db.SaveChangesAsync();
        return rowsAffected;
    }

    public async Task<User> Get(string Email, string Password)
    {
        var user = _db.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
        return user;
    }

    public async Task<User> Get(string Email)
    {
        var user = _db.Users.Where(x => x.Email == Email).FirstOrDefault();
        return user;
    }
}
