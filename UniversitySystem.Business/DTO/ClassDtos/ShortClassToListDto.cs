namespace UniversitySystem.Business.DTO.ClassDtos
{
    public record ShortClassToListDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }
    }
}
