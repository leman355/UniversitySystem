namespace UniversitySystem.Business.DTO.StudentDtos
{
    public record StudentToAddDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool IsPayingStudent { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool IsGraduated { get; set; }
        public double? AverageGrade { get; set; }
        public int MajorId { get; set; }
        public int GroupId { get; set; }
    }
}