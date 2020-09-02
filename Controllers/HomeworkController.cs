using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HW.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using HW.Models;
using HW.Services;

namespace HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly homeworkContext _context;
        private readonly IGlobalService _globalService;

        public HomeworkController(homeworkContext context, IGlobalService globalService)
        {
            _context = context;
            _globalService = globalService;
        }

        // GET: api/Homework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetHomework()
        {
            return await _context.Homework.ToListAsync();
        }

        // GET: api/Homework/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Homework>> GetHomework(string id)
        {
            var homework = await _context.Homework.FindAsync(id);

            if (homework == null)
            {
                return NotFound();
            }

            return homework;
        }

        // PUT: api/Homework/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomework(string id, Homework homework)
        {
            if (id != homework.HomeworkId)
            {
                return BadRequest();
            }

            _context.Entry(homework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeworkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Homework
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Homework>> PostHomework([FromBody] HomeworkAddModel ham)
        {
            string hid = _globalService.GenRandomId(15);
            Homework homework = new Homework
            {
                HomeworkId = hid,
                Name = ham.Name,
                CourseId = ham.CourseId,
                Due = ham.Due,
                Created = DateTime.Now,
                Content = ham.Content,
                Published = ham.Published,
                Mulsubmit = ham.Mulsubmit
            };
            _context.Homework.Add(homework);
            try
            {
                await _context.SaveChangesAsync();
                SyncToSubmission(hid, ham.CourseId);
            }
            catch (DbUpdateException)
            {
                if (HomeworkExists(hid))
                {
                    return Conflict();
                }
                else
                {
                    throw; 
                }
            }

            return CreatedAtAction("GetHomework", new { id = homework.HomeworkId }, homework);
        }

        // DELETE: api/Homework/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Homework>> DeleteHomework(string id)
        {
            var homework = await _context.Homework.FindAsync(id);
            if (homework == null)
            {
                return NotFound();
            }

            _context.Homework.Remove(homework);
            await _context.SaveChangesAsync();

            return homework;
        }
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<Homework>> GetByCourseId(string courseId)
        {
            var homework =await _context.Homework.Where(h => h.CourseId == courseId).ToListAsync();
            return Ok(homework);
        }

        private bool HomeworkExists(string id)
        {
            return _context.Homework.Any(e => e.HomeworkId == id);
        }
        private bool SyncToSubmission(string hid,string courseId)
        {
            var enrollment = _context.Enrollment.Where(e => e.CourseId == courseId).ToList();
            List<Submission> subs = new List<Submission>();
            foreach(Enrollment el in enrollment)
            {
                var sub = new Submission
                {
                    SubmissionId = genRandomId(12),
                    CourseId = courseId,
                    HomeworkId = hid,
                    OpenId = el.OpenId,
                    Score = 0,
                };
                subs.Add(sub);
            }
            try
            {
                _context.Submission.AddRange(subs);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        private string genRandomId(int num)
        {
            if (num <= 0)
            {
                return null;
            }
            var ran = new Random();
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            string number = "0123456789";
            string Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string id = "";
            
            for(int i = 0; i < num;i++)
            {
                int choice = ran.Next(1, 3);
                switch (choice)
                {
                    case 1:id += alpha[ran.Next(0, alpha.Length-1)];break;
                    case 2: id += number[ran.Next(0, number.Length - 1)]; break;
                    case 3: id += Alpha[ran.Next(0, Alpha.Length - 1)]; break;
                }
            }
            return id;
        }
    }
}
