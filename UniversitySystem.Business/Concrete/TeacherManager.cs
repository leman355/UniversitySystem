using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.TeacherDtos;
using UniversitySystem.Entities;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Business.DTO.GroupDtos;

namespace UniversitySystem.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherManager(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<List<TeacherToListDto>> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();
            return _mapper.Map<List<TeacherToListDto>>(teachers);
        }

        public async Task<TeacherToListDto> GetTeacherById(int teacherId)
        {
            var teacher = await _teacherRepository.GetTeacherById(teacherId);
            return _mapper.Map<TeacherToListDto>(teacher);
        }

        public async Task<TeacherToAddDto> CreateTeacher(TeacherToAddDto dto)
        {
            var teacher = _mapper.Map<Teacher>(dto);
            List<Group> groups = await _teacherRepository.GetGroups(dto.GroupIds);
            teacher.Groups = groups;

            await _teacherRepository.CreateTeacher(teacher);
            dto.GroupIds = teacher.Groups.Select(group => group.GroupId).ToList();
            return dto;
        }

        public async Task<TeacherToUpdateDto> UpdateTeacher(int id, TeacherToUpdateDto teacherToUpdateDto)
        {
            Teacher existingTeacher = await _teacherRepository.GetTeacherById(id);

            if (existingTeacher == null)
            {
                return null;
            }

            _mapper.Map(teacherToUpdateDto, existingTeacher);

            List<Group> groups = await _teacherRepository.GetGroups(teacherToUpdateDto.GroupIds);
            existingTeacher.Groups = groups;

            var updatedTeacher = await _teacherRepository.UpdateTeacher(existingTeacher);

            var responseDto = _mapper.Map<TeacherToUpdateDto>(updatedTeacher);
            responseDto.GroupIds = teacherToUpdateDto.GroupIds; 

            return responseDto;
        }

        public async Task DeleteTeacherById(int teacherId)
        {
            await _teacherRepository.DeleteTeacherById(teacherId);
        }

        public async Task<List<ShortGroupToListDto>> GetTeacherGroups(int teacherId)
        {
            List<Group> groups = await _teacherRepository.GetTeacherGroups(teacherId);
            List<ShortGroupToListDto> res = _mapper.Map<List<ShortGroupToListDto>>(groups);
            return res;
        }
    }
}
