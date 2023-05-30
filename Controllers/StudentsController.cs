using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_CFA.Data;
using Assignment_CFA.Entities;
using AutoMapper;
using Assignment_CFA.Repositories;

namespace Assignment_CFA.Controllers
{
    [Route("Home")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Assignment_CFAContext _context;
        private readonly IMapper mapper;
        private readonly IStudentRepo studentRepo;

        public StudentsController(Assignment_CFAContext context, IMapper mapper, IStudentRepo studentRepo)
        {
            _context = context;
            this.mapper = mapper;
            this.studentRepo = studentRepo;
        }

        // GET: api/Students
        [Route("getData")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudent()
        {/*
          if (_context.Student == null)
          {
              return NotFound();
          }
            return await _context.Student.ToListAsync();*/
            try
            {

                if (_context.Student == null)
                    return NotFound();

                var studentdto = await studentRepo.GetAll();
                //var studentdto = _context.StudentsDetails.ToListAsync();
                var studentdto1 = studentdto.Select(x => this.mapper.Map<Students>(x));
                return Ok(studentdto1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Students/5
        [Route("GetDataById")]
        [HttpGet]
        public async Task<ActionResult<Students>> GetStudent(Guid id)
        {


            if (_context.Student == null)
            {

                throw new ArgumentNullException(nameof(id));

            }
            var studentsDetail = await studentRepo.GetByID(id);

            if (studentsDetail == null)
            {
                return NotFound();
            }
            var item = mapper.Map<Students>(studentsDetail);
            return Ok(item);

        }

        [Route("PutDataOrUpdate")]
        [HttpPut]
        public async Task<IActionResult> PutStudent(Guid id, Students student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            var updateStu = mapper.Map<Students>(_context.Entry(student).State);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateStu);
        }
        [Route("PostData")]
        [HttpPost]
        public async Task<ActionResult<Students>> PostStudent(Students student)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'Assignment_CFAContext.Student'  is null.");
            }
            _context.Student.Add(student);
            mapper.Map<Students>(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);

        }

        // DELETE: api/Students/5
        [Route("deleteData")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (_context.Student == null)
            {
                return NotFound();
            }
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(Guid id)
        {
            return (_context.Student?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }//dummy route to learn the concept
        [HttpGet]
        [Route("getHello/{name}")]
        public string hello(string name)
        {
            return ( "hello "+name);
        }
    }
}
