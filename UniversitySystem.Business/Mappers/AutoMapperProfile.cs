using AutoMapper;
using UniversitySystem.Business.DTO.AnswerDtos;
using UniversitySystem.Business.DTO.ClassDtos;
using UniversitySystem.Business.DTO.CourseDtos;
using UniversitySystem.Business.DTO.DepartmentDtos;
using UniversitySystem.Business.DTO.ExamDtos;
using UniversitySystem.Business.DTO.ExamResultDtos;
using UniversitySystem.Business.DTO.GroupDtos;
using UniversitySystem.Business.DTO.MajorDtos;
using UniversitySystem.Business.DTO.PaymentDtos;
using UniversitySystem.Business.DTO.QuestionDtos;
using UniversitySystem.Business.DTO.RoleDtos;
using UniversitySystem.Business.DTO.StudentDtos;
using UniversitySystem.Business.DTO.TeacherDtos;
using UniversitySystem.Business.DTO.UserDtos;
using UniversitySystem.Entities;

namespace UniversitySystem.Business.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserToAddDto, User>();
            CreateMap<User, UserToAddDto>();
            CreateMap<User, UserToListDto>();
            CreateMap<UserToUpdateDto, User>();
            CreateMap<User, UserToUpdateDto>();
            CreateMap<User, ShortUserToListDto>();

            CreateMap<TeacherToAddDto, Teacher>();
            CreateMap<Teacher, TeacherToAddDto>();
            CreateMap<Teacher, TeacherToListDto>();
            CreateMap<TeacherToUpdateDto, Teacher>();
            CreateMap<Teacher, TeacherToUpdateDto>();
            CreateMap<Teacher, ShortTeacherToListDto>();

            CreateMap<Student, StudentToAddDto>();
            CreateMap<StudentToAddDto, Student>();
            CreateMap<Student, StudentToListDto>();
            CreateMap<StudentToUpdateDto, Student>();
            CreateMap<Student, StudentToUpdateDto>();
            CreateMap<Student, ShortStudentToListDto>();

            CreateMap<Role, RoleToListDto>();
            CreateMap<Role, RoleToAddDto>();
            CreateMap<RoleToAddDto, Role>();
            CreateMap<RoleToUpdateDto, Role>();
            CreateMap<Role, RoleToUpdateDto>();
            
            CreateMap<Question, QuestionToListDto>();
            CreateMap<Question, QuestionToAddDto>();
            CreateMap<QuestionToAddDto, Question>();
            CreateMap<QuestionToUpdateDto, Question>();
            CreateMap<Question, QuestionToUpdateDto>();
            CreateMap<Question, ShortQuestionToListDto>();
            
            CreateMap<Payment, PaymentToListDto>();
            CreateMap<Payment, PaymentToAddDto>();
            CreateMap<PaymentToAddDto, Payment>();
            CreateMap<PaymentToUpdateDto, Payment>();
            CreateMap<Payment, PaymentToUpdateDto>();
            CreateMap<Payment, ShortPaymentToListDto>();

            CreateMap<Major, MajorToListDto>();
            CreateMap<Major, MajorToAddDto>();
            CreateMap<MajorToAddDto, Major>();
            CreateMap<MajorToUpdateDto, Major>();
            CreateMap<Major, MajorToUpdateDto>();
            CreateMap<Major, ShortMajorToListDto>();

            CreateMap<Group, GroupToListDto>();
            CreateMap<Group, GroupToAddDto>();
            CreateMap<GroupToAddDto, Group>();
            CreateMap<GroupToUpdateDto, Group>();
            CreateMap<Group, GroupToUpdateDto>();
            CreateMap<Group, ShortGroupToListDto>();

            CreateMap<ExamResult, ExamResultToListDto>();
            CreateMap<ExamResult, ExamResultToAddDto>();
            CreateMap<ExamResultToAddDto, ExamResult>();
            CreateMap<ExamResultToUpdateDto, ExamResult>();
            CreateMap<ExamResult, ExamResultToUpdateDto>();
            CreateMap<ExamResult, ShortExamResultToListDto>();
            CreateMap<ExamResult, ExamResultForExamToListDto>();
            
            CreateMap<Exam, ExamToListDto>();
            CreateMap<Exam, ExamToAddDto>();
            CreateMap<ExamToAddDto, Exam>();
            CreateMap<ExamToUpdateDto, Exam>();
            CreateMap<Exam, ExamToUpdateDto>();
            CreateMap<Exam, ShortExamToListDto>();

            CreateMap<Department, DepartmentToListDto>();
            CreateMap<Department, DepartmentToAddDto>();
            CreateMap<DepartmentToAddDto, Department>();
            CreateMap<DepartmentToUpdateDto, Department>();
            CreateMap<Department, DepartmentToUpdateDto>();
            CreateMap<Department, ShortDepartmentToListDto>();
          
            CreateMap<Course, CourseToListDto>();
            CreateMap<Course, CourseToAddDto>();
            CreateMap<CourseToAddDto, Course>();
            CreateMap<CourseToUpdateDto, Course>();
            CreateMap<Course, CourseToUpdateDto>();
            CreateMap<Course, ShortCourseToListDto>();

            CreateMap<Class, ClassToListDto>();
            CreateMap<Class, ClassToAddDto>();
            CreateMap<ClassToAddDto, Class>();
            CreateMap<ClassToUpdateDto, Class>();
            CreateMap<Class, ClassToUpdateDto>();
            CreateMap<Class, ShortClassToListDto>();

            CreateMap<Answer, AnswerToListDto>();
            CreateMap<Answer, AnswerToAddDto>();
            CreateMap<AnswerToAddDto, Answer>();
            CreateMap<AnswerToUpdateDto, Answer>();
            CreateMap<Answer, AnswerToUpdateDto>();
            CreateMap<Answer, ShortAnswerToListDto>();
        }
    }
}