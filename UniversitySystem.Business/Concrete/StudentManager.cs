using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.StudentDtos;
using UniversitySystem.Entities;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Business.DTO.ExamResultDtos;

namespace UniversitySystem.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentManager(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentToListDto>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudents();
            return _mapper.Map<List<StudentToListDto>>(students);
        }

        public async Task<StudentToListDto> GetStudentById(int studentId)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            return _mapper.Map<StudentToListDto>(student);
        }

        public async Task<StudentToAddDto> CreateStudent(StudentToAddDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            var createdStudent = await _studentRepository.CreateStudent(student);
            return _mapper.Map<StudentToAddDto>(createdStudent);
        }
        /*    
            List<ExamResult> exRes = await _studentRepository.GetExamResults(dto.ExamResultIds);
            student.ExamResults = exRes;

            await _teacherRepository.CreateTeacher(teacher);
            dto.ExamResultIds = teacher.ExamResults.Select(e => g.GroupId).ToList();
            return dto;
        }

        }*/
        public async Task<StudentToUpdateDto> UpdateStudent(int id, StudentToUpdateDto dto)
        {
            var existingStudent = await _studentRepository.GetStudentById(id);

            if (existingStudent == null)
            {
                return null;
            }

            _mapper.Map(dto, existingStudent);

            var updatedStudent = await _studentRepository.UpdateStudent(existingStudent);
            return _mapper.Map<StudentToUpdateDto>(updatedStudent);
        }

        public async Task DeleteStudentById(int studentId)
        {
            await _studentRepository.DeleteStudentById(studentId);
        }

        public async Task<List<ShortExamResultToListDto>> GetStudentExamResults(int studentId)
        {
            List<ExamResult> examResults = await _studentRepository.GetStudentExamResults(studentId);
            List<ShortExamResultToListDto> resultDtos = _mapper.Map<List<ShortExamResultToListDto>>(examResults);
            return resultDtos;
        }
    }
}
