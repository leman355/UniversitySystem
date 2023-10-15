using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.CourseDtos;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.Business.Concrete
{ 
    public class CourseManager : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseManager(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseToListDto>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            return _mapper.Map<List<CourseToListDto>>(courses);
        }

        public async Task<CourseToListDto> GetCourseById(int courseId)
        {
            var course = await _courseRepository.GetCourseById(courseId);
            return _mapper.Map<CourseToListDto>(course);
        }

        public async Task<CourseToAddDto> CreateCourse(CourseToAddDto dto)
        {
            var course = _mapper.Map<Course>(dto);
            var createdCourse = await _courseRepository.CreateCourse(course);
            return _mapper.Map<CourseToAddDto>(createdCourse);
        }

        public async Task<CourseToUpdateDto> UpdateCourse(int courseId, CourseToUpdateDto dto)
        {
            var existingCourse = await _courseRepository.GetCourseById(courseId);

            if (existingCourse == null)
            {
                return null;
            }

            _mapper.Map(dto, existingCourse);

            var updatedCourse = await _courseRepository.UpdateCourse(existingCourse);
            return _mapper.Map<CourseToUpdateDto>(updatedCourse);
        }

        public async Task DeleteCourseById(int courseId)
        {
            await _courseRepository.DeleteCourseById(courseId);
        }
    }
}
