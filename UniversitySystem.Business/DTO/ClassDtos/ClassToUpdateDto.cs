namespace UniversitySystem.Business.DTO.ClassDtos
{
    public record ClassToUpdateDto
    {
        public string ClassName { get; set; }
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }
        public int CourseId { get; set; }
    }
}
