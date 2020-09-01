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
    public class TeacherController : ControllerBase
    {
        private readonly homeworkContext _context;
        public TeacherController(homeworkContext context)
        {
            _context = context;
        }
        [HttpGet("{openId}")]
        public Teacher GetTeacherById(string openId)
        {
            var teacher = _context.Teacher.Find(openId);
            return teacher;
        }
    }
}
