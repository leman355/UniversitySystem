namespace UniversitySystem.Business.DTO.TeacherDtos
{
    public record ShortTeacherToListDto
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
