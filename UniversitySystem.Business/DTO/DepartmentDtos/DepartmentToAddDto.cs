namespace UniversitySystem.Business.DTO.DepartmentDtos
{
    public record DepartmentToAddDto
    {
        public string DepartmentName { get; set; }
        public string HeadOfDepartment { get; set; }
    }
}
