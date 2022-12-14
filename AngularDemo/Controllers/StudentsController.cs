using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularDemo.Data;
using AngularDemo.Models;
using AngularDemo.Models.ViewModels;
using AngularDemo.Services;
using Microsoft.AspNetCore.Authorization;

namespace AngularDemo.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _service;
    public StudentsController(IStudentService service)
    {
        _service = service;
    }

    // GET: api/Students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> Get(int id)
    {
        var student = await _service.Get(id);
        if(student == null)
        {
            return NotFound();
        }
        return student;
    }

    // PUT: api/Students/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, StudentView student)
    {
        await _service.Update(id, student);
        return Content("Updated Successfully");
    }

    // POST: api/Students
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Student>> Create(StudentVM student)
    {
        await _service.Create(student);
        return Content("Created Successfully");
    }

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Content("Deleted Successfully");
    }
}
