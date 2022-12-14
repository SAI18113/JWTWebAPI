using AngularDemo.Models;
using AngularDemo.Models.ViewModels;
using AngularDemo.Repositories;

namespace AngularDemo.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepositry _repositry;
    private readonly IUserRepositry _userRepositry;
    public StudentService(IStudentRepositry repositry, IUserRepositry userRepositry)
    {
        _repositry = repositry;
        _userRepositry = userRepositry;
    }

    public async Task<bool> Create(StudentVM student)
    {
        var std = new Student()
        {
            FirstName=student.FirstName,
            LastName=student.LastName,
            Email=student.Email,
            Mobile=student.Mobile,
            State=student.State,
            City=student.City,
        };
        var user = new User
        {
            Email = student.Email,
            Password = student.Password,
            UserType = "Student"
        };
        await _userRepositry.Create(user);
        std.UserId = user.Id;
        int rowsAffected = await _repositry.Create(std);
        return rowsAffected > 0;
    }

    public async Task<bool> Delete(int id)
    {
        int rowsAffected = await _repositry.Delete(id);
        return rowsAffected > 0;
    }

    public async Task<Student> Get(int id)
    {
        var std = await _repositry.Get(id);
        var student = new Student()
        {
            FirstName = std.FirstName,
            LastName = std.LastName,
            Email = std.Email,
            Mobile = std.Mobile,
            State = std.State,
            City = std.City
        };
        return student;
    }

    public async Task<List<Student>> GetAll()
    {
        List<Student> obj = new List<Student>();
        obj = await _repositry.GetAll();
        return obj;

    }

    public async Task<bool> Update(int id, StudentView student)
    {
        int rowsAffected=await _repositry.Update(id, student);
        return rowsAffected > 0;
    }
}
