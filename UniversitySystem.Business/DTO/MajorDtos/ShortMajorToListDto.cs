namespace UniversitySystem.Business.DTO.MajorDtos
{
    public record ShortMajorToListDto
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }

    }
}
