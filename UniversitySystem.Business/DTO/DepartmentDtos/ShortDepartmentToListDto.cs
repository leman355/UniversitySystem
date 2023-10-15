namespace UniversitySystem.Business.DTO.DepartmentDtos
{
    public record ShortDepartmentToListDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string HeadOfDepartment { get; set; }
    }
}
