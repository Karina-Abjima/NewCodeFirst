using Assignment_CFA.Dto;
using Assignment_CFA.Entities;
using AutoMapper;
namespace Assignment_CFA.Mapper
{
    public class Automapper:Profile

    {
       public Automapper() {
            CreateMap<Students, StudentDto>();
         //   CreateMap<StudentDto, Students>();
        }
    }
}
