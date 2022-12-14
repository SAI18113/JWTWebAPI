using AngularDemo.Data;
using AngularDemo.Models;
using AngularDemo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AngularDemo.Repositories;

public class StudentRepositry : IStudentRepositry
{
    private readonly ApplicationDbContext _db;
    public StudentRepositry(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<int> Create(Student student)
    {
        _db.Students.Add(student);
        int rowsAffected = await _db.SaveChangesAsync();
        return rowsAffected;

    }

    public async Task<int> Delete(int id)
    {
        var std = _db.Students.Where(x => x.Id == id).FirstOrDefault();
        _db.Students.Remove(std);
        int rowsAffected=await _db.SaveChangesAsync();
        return rowsAffected;
    }

    public async Task<Student> Get(int id)
    {
        var std = _db.Students.Where(x => x.Id == id).FirstOrDefault();
        return std;
    }

    public async Task<List<Student>> GetAll()
    {
        var std = await _db.Students.ToListAsync();
        return std;
    }

    public async Task<int> Update(int id, StudentView student)
    {
        var std = _db.Students.Where(x => x.Id == id).FirstOrDefault();
        std.FirstName = student.FirstName;
        std.LastName = student.LastName;
        std.Email = student.Email;
        std.Mobile = student.Mobile;
        std.State = student.State;
        std.City = student.City;
        _db.Students.Update(std);
        int rowsAffected = await _db.SaveChangesAsync();
        return rowsAffected;
    }
}
