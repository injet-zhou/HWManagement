using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW.Entities;
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
    }
}
