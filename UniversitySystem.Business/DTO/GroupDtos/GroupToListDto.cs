using UniversitySystem.Business.DTO.CourseDtos;
using UniversitySystem.Business.DTO.ExamDtos;
using UniversitySystem.Business.DTO.StudentDtos;
using UniversitySystem.Business.DTO.TeacherDtos;
using UniversitySystem.Business.DTO.UserDtos;

namespace UniversitySystem.Business.DTO.GroupDtos
{
    public record GroupToListDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<ShortTeacherToListDto> Teachers { get; set; }
        public List<ShortCourseToListDto> Courses { get; set; }
        public List<ShortStudentToListDto> Students { get; set; }
        public List<ShortUserToListDto> Users { get; set; }
        public List<ShortExamToListDto> Exams { get; set; }
    }
}
