using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInformationProject.Data;
using StudentInformationProject.Model;

namespace StudentInformationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
        private readonly StudentInformationProjectContext _context;

        public StudentDetailsController(StudentInformationProjectContext context)
        {
            _context = context;
        }

        // GET: api/StudentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDetails>>> GetStudentDetails()
        {
          if (_context.StudentDetails == null)
          {
              return NotFound();
          }
            return await _context.StudentDetails.ToListAsync();
        }

        // GET: api/StudentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetails>> GetStudentDetails(int id)
        {
          if (_context.StudentDetails == null)
          {
              return NotFound();
          }
            var studentDetails = await _context.StudentDetails.FindAsync(id);

            if (studentDetails == null)
            {
                return NotFound();
            }

            return studentDetails;
        }

        // PUT: api/StudentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDetails(int id, StudentDetails studentDetails)
        {
            if (id != studentDetails.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailsExists(id))
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

        // POST: api/StudentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDetails>> PostStudentDetails(StudentDetails studentDetails)
        {
          if (_context.StudentDetails == null)
          {
              return Problem("Entity set 'StudentInformationProjectContext.StudentDetails'  is null.");
          }
            _context.StudentDetails.Add(studentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentDetails", new { id = studentDetails.StudentId }, studentDetails);
        }

        // DELETE: api/StudentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentDetails(int id)
        {
            if (_context.StudentDetails == null)
            {
                return NotFound();
            }
            var studentDetails = await _context.StudentDetails.FindAsync(id);
            if (studentDetails == null)
            {
                return NotFound();
            }

            _context.StudentDetails.Remove(studentDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentDetailsExists(int id)
        {
            return (_context.StudentDetails?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
