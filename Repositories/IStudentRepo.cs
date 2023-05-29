using Assignment_CFA.Entities;

namespace Assignment_CFA.Repositories
{
    public interface IStudentRepo
    {

      public  Task<List<Students>> GetAll();
      public  Task<Students> GetByID(Guid id);
      public  Task<Students> AddStudentAsync(Students student);

     public   Task<Students> DeleteStudentAsync(Guid id, IStudentRepo studentRepo);
      public  Task<Students> UpdateDetail(Guid id, Students student);
    }
}
