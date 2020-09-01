using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW.Entities;
using HW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly homeworkContext _context;
        public StudentController(homeworkContext context)
        {
            _context = context;
        }
        [HttpGet("{openId}")]
        public Student GetById(string openId)
        {
            var student = _context.Student.Find(openId);
            return student;
        }
        [HttpPut]
        public ResponseModel AddStudent([FromBody] StudentAddModel sam)
        {
            if (sam != null)
            {
                Student student = new Student
                {
                    OpenId = sam.OpenId,
                    StudentId = sam.StudentId,
                    Name = sam.Name,
                    Sclass = sam.Sclass,
                    Pwd = sam.Pwd,
                    Avatar = sam.Avatar
                };
                _context.Student.Add(student);
                _context.SaveChanges();
                ResponseModel rs = new ResponseModel(200, "succeeded");
                return rs;
            }
            else
            {
                return new ResponseModel(400, "error");
            }
        }
        [HttpDelete("{openId}")]
        public ResponseModel DeleteStudent(string openId)
        {
            Student student = _context.Student.Find(openId);
            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
                return new ResponseModel(200, "succeeded");
            }
            else
            {
                return new ResponseModel(400, "failed");
            }
        }
        [HttpPost]
        public ResponseModel Update([FromBody] PostModel pm)
        {
            if (pm != null)
            {
                Student student = _context.Student.Find(pm.Id);
                if (student != null)
                {
                    switch (pm.Type)
                    {
                        case "studentId":student.StudentId = pm.ToChange;break;
                        case "name": student.Name = pm.ToChange; break;
                        case "sclass": student.Sclass = pm.ToChange; break;
                        case "phone": student.Phone = pm.ToChange; break;
                        case "pwd": student.Pwd = pm.ToChange; break;
                        case "avatar": student.Avatar = pm.ToChange; break;
                    }
                    _context.SaveChanges();
                    return new ResponseModel(200, "succeeded");
                }
                return new ResponseModel(401, "failed");
            }
            return new ResponseModel(400, "failed");
        }
    }
}
