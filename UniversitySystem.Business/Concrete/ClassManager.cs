using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.ClassDtos;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.Business.Concrete
{
    public class ClassManager : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassManager(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassToListDto>> GetAllClasses()
        {
            var classes = await _classRepository.GetAllClasses();
            return _mapper.Map<List<ClassToListDto>>(classes);
        }

        public async Task<ClassToListDto> GetClassById(int classId)
        {
            var classEntity = await _classRepository.GetClassById(classId);
            return _mapper.Map<ClassToListDto>(classEntity);
        }

        public async Task<List<ClassToListDto>> GetClassesByCourse(int courseId)
        {
            var classes = await _classRepository.GetClassesByCourse(courseId);
            return _mapper.Map<List<ClassToListDto>>(classes);
        }

        public async Task<ClassToAddDto> CreateClass(ClassToAddDto dto)
        {
            var classEntity = _mapper.Map<Class>(dto);
            var createdClass = await _classRepository.CreateClass(classEntity);
            return _mapper.Map<ClassToAddDto>(createdClass);
        }

        public async Task<ClassToUpdateDto> UpdateClass(int classId, ClassToUpdateDto dto)
        {
            var existingClass = await _classRepository.GetClassById(classId);

            if (existingClass == null)
            {
                return null;
            }

            _mapper.Map(dto, existingClass);

            var updatedClass = await _classRepository.UpdateClass(existingClass);
            return _mapper.Map<ClassToUpdateDto>(updatedClass);
        }

        public async Task DeleteClassById(int classId)
        {
            await _classRepository.DeleteClassById(classId);
        }
    }
}
