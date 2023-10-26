using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.UserDtos;
using UniversitySystem.Entities;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Business.DTO.GroupDtos;

namespace UniversitySystem.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserToListDto>> GetAllUsers()
        {
            List<User> entities = await _userRepository.GetAllUsers();
            List<UserToListDto> dtos = _mapper.Map<List<UserToListDto>>(entities);
            return dtos;
        }

        public async Task<UserToListDto> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return _mapper.Map<UserToListDto>(user);
        }

        public async Task<List<UserToListDto>> GetUsersByRoleId(int roleId)
        {
            var users = await _userRepository.GetUsersByRoleId(roleId);
            return _mapper.Map<List<UserToListDto>>(users);
        }

        public async Task<UserToAddDto> CreateUser(UserToAddDto dto)
        {
            User user = _mapper.Map<User>(dto);
            List<Group> groups = await _userRepository.GetGroups(dto.GroupIds);
            user.Groups = groups;
         
            var createdUser = await _userRepository.CreateUser(user);
            
            dto.GroupIds = user.Groups.Select(group => group.GroupId).ToList();
            return dto;
        }

        public async Task<UserToUpdateDto> UpdateUser(int id, UserToUpdateDto userToUpdateDto)
        {
            User existingUser = await _userRepository.GetUserById(id);

            if (existingUser == null)
            {
                return null;
            }
            /*
            if (userToUpdateDto.GroupIds == null)
            {
                userToUpdateDto.GroupIds = existingUser.Groups.Select(group => group.GroupId).ToList();
            }
            */
            _mapper.Map(userToUpdateDto, existingUser);

            List<Group> groups = await _userRepository.GetGroups(userToUpdateDto.GroupIds);
            existingUser.Groups = groups;

            var updatedUser = await _userRepository.UpdateUser(existingUser);

            var resp = _mapper.Map<UserToUpdateDto>(updatedUser);
            resp.GroupIds = userToUpdateDto.GroupIds;

            return resp;
        }

        public async Task DeleteUserById(int userId)
        {
            await _userRepository.DeleteUserById(userId);
        }

        public async Task<List<ShortGroupToListDto>> GetUserGroups(int userId)
        {
            List<Group> groups = await _userRepository.GetUserGroups(userId);
            List<ShortGroupToListDto> result= _mapper.Map<List<ShortGroupToListDto>>(groups);
            return result;
        }

        public async Task<Role> GetUserRoleByEmail(string email)
        {
            return await _userRepository.GetUserRoleByEmail(email);
        }
    }
}