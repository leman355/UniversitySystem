namespace UniversitySystem.Business.DTO.TeacherDtos
{
    public record TeacherToAddDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<int> GroupIds { get; set; }
    }
}
