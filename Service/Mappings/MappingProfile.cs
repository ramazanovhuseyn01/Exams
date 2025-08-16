using Application.DTOs.Exam;
using Application.DTOs.Lesson;
using Application.DTOs.Student;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Service.DTOs.Exam;

namespace Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, ExamListDTO>();
            CreateMap<ExamCreateAndUpdateDto, Exam>();
            CreateMap<ExamCreateAndUpdateDto, Exam>().ReverseMap();

            CreateMap<StudentCreateAndUpdateDto, Student>();
            CreateMap<Student, StudentListDto>();
            CreateMap<StudentCreateAndUpdateDto, Student>().ReverseMap();

            CreateMap<LessonCreateAndUpdateDto, Lesson>();
            CreateMap<Lesson, LessonListDto>();
            CreateMap<LessonCreateAndUpdateDto, Lesson>().ReverseMap();
        }
      
    }
}
