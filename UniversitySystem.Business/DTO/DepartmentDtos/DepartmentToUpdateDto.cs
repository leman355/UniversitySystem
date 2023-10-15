namespace UniversitySystem.Business.DTO.DepartmentDtos
{
    public record DepartmentToUpdateDto
    {
        public string DepartmentName { get; set; }
        public string HeadOfDepartment { get; set; }
    }
}
