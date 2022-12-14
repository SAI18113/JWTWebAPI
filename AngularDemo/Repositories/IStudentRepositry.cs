using AngularDemo.Models;
using AngularDemo.Models.ViewModels;

namespace AngularDemo.Repositories;

public interface IStudentRepositry
{
    Task<int> Create(Student student);
    Task<int> Update(int id, StudentView student);
    Task<int> Delete(int id);
    Task<Student> Get(int id);
    Task<List<Student>> GetAll();
}
