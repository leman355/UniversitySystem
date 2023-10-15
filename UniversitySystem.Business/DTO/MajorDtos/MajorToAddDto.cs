namespace UniversitySystem.Business.DTO.MajorDtos
{
    public record MajorToAddDto
    {
        public string MajorName { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
    }
}
