using AngularDemo.Models;
using AngularDemo.Models.ViewModels;

namespace AngularDemo.Services;

public interface IStudentService
{
    Task<bool> Create(StudentVM student);
    Task<bool> Update(int id, StudentView student);
    Task<bool> Delete(int id);
    Task<Student> Get(int id);
    Task<List<Student>> GetAll();

}
