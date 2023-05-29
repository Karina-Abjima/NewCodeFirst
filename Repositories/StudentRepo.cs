using Assignment_CFA.Dto;
using Assignment_CFA.Entities;
using Assignment_CFA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_CFA.Repositories
{
    public class StudentRepo:IStudentRepo
    {

      private readonly Assignment_CFAContext _context;

        public StudentRepo(Assignment_CFAContext context)
        {
            _context = context;
        }

        public  async  Task<List<Students>> GetAll() 
            {
                return await _context.Student.ToListAsync();
            }
          public async  Task<Students> GetByID(Guid id)

        {
            try
            {
                var data = await _context.Student.FindAsync(id);
                return data;//here

            }
            catch (Exception ex)
            {
                return null;
            }
        }
          public async Task<Students>  AddStudentAsync(Students student)


        {
            _context.Student.Add(student);
            var s = await _context.SaveChangesAsync();
            return student;
          
        }

           public async Task<Students> DeleteStudentAsync(Guid id, IStudentRepo studentRepo)
         {
            var student = await studentRepo.GetByID(id);
            if (student != null)
            {
                return student;
            }
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }
           public async Task<Students> UpdateDetail(Guid id, Students student)
        {
            throw new NotImplementedException();

        }

        }
    }