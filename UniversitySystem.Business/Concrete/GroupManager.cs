using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.GroupDtos;
using UniversitySystem.Entities;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Business.DTO.CourseDtos;
using UniversitySystem.Business.DTO.StudentDtos;

namespace UniversitySystem.Business.Concrete
{
    public class GroupManager : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupManager(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<List<GroupToListDto>> GetAllGroups()
        {
            var groups = await _groupRepository.GetAllGroups();
            return _mapper.Map<List<GroupToListDto>>(groups);
        }

        public async Task<GroupToListDto> GetGroupById(int groupId)
        {
            var group = await _groupRepository.GetGroupById(groupId);
            return _mapper.Map<GroupToListDto>(group);
        }

        public async Task<GroupToAddDto> CreateGroup(GroupToAddDto dto)
        {
            var group = _mapper.Map<Group>(dto);
            var createdGroup = await _groupRepository.CreateGroup(group);
            return _mapper.Map<GroupToAddDto>(createdGroup);
        }

        public async Task<GroupToUpdateDto> UpdateGroup(int groupId, GroupToUpdateDto dto)
        {
            var existingGroup = await _groupRepository.GetGroupById(groupId);

            if (existingGroup == null)
            {
                return null;
            }

            _mapper.Map(dto, existingGroup);

            var updatedGroup = await _groupRepository.UpdateGroup(existingGroup);
            return _mapper.Map<GroupToUpdateDto>(updatedGroup);
        }

        public async Task DeleteGroupById(int groupId)
        {
            await _groupRepository.DeleteGroupById(groupId);
        }

        public async Task<List<ShortStudentToListDto>> GetGroupStudents(int groupId)
        {
            var students = await _groupRepository.GetGroupStudents(groupId);
            return _mapper.Map<List<ShortStudentToListDto>>(students);
        }

        public async Task<List<ShortCourseToListDto>> GetGroupCourses(int groupId)
        {
            var courses = await _groupRepository.GetGroupCourses(groupId);
            return _mapper.Map<List<ShortCourseToListDto>>(courses);
        }
    }
}
