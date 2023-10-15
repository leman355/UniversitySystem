namespace UniversitySystem.Business.DTO.CourseDtos
{
    public record ShortCourseToListDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
    }
}
