using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OU.ApiSchoolDb.Filter;
using OU.ApiSchoolDb.Paging;
using OU.ApiSchoolDb.Models;
using OU.ApiSchoolDb.Context;
using Microsoft.EntityFrameworkCore;

namespace OU.ApiSchoolDb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolDb _context;

        public StudentController(SchoolDb context)
        {
            _context = context;
        }
        [HttpGet("GetStudents")]

        public IActionResult GetStudent([FromQuery] PagingParameter p , [FromQuery] StudentFilter sf) 
        {
            var query = _context.Students.AsQueryable();

            if(sf.Gender != null) 
            {
                query = query.Where(x => x.Gender == sf.Gender.Value);
            
            }
            if(sf.Age != null) 
            {
                query = query.Where(x => x.Age == sf.Age);
            
            }
             query = query.Skip(p.Pagesize.Value*(p.PageNumber.Value-1)).Take(p.Pagesize.Value);

            return Ok(query.ToList());
        }
        [HttpPost("AddExamToStudent")]
        public IActionResult AddExamToStudent(ExamAddDTo dto) 
        {
            var item = _context.Students.Find(dto.StudentId);
            if (item == null) return BadRequest("Ögrenci bulunamadı");

            item.Exams.Add(new() 
            {
                
             TypeofExam = dto.TypeofExam,
             Lesson=dto.Lesson,
             Grade=dto.Grade,
            
            });
            _context.SaveChanges();
           

            return Ok();
        }
        [HttpGet("GetAvarage/{studentId}/{Lesson}")]
        public IActionResult GetAvarage(int studentId, Lesson Lesson) 
        {
            var student = _context.Students.Where(x => x.Id == studentId).Include(x => x.Exams.Where(x => x.Lesson == Lesson)).First();
            decimal sum = 0;
            if (student.Exams.Count(x=>x.Lesson==Lesson)==3)
            {
                student.Exams.Where(x => x.Lesson == Lesson).ToList().ForEach(x =>
                {
                   sum += x.Grade;

                });
            }
            else 
            {
                return BadRequest("Öğrenci sınavı eksiktir ortalama hesplaması yapılamaz");
            
            }

            var result = sum / 3;



            return Ok(result);
        }
    }
}
