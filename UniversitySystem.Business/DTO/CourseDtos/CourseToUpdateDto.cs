namespace UniversitySystem.Business.DTO.CourseDtos
{
    public record CourseToUpdateDto
    {
        public string CourseName { get; set; }
        public string? Description { get; set; }
    }
}
