using UniversitySystem.Entities;

namespace UniversitySystem.Business.DTO.UserDtos
{
    public record ShortUserToListDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
    }
}