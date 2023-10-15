namespace UniversitySystem.Business.DTO.CourseDtos
{
    public record CourseToAddDto
    {
        public string CourseName { get; set; }
        public string? Description { get; set; }
    }
}
