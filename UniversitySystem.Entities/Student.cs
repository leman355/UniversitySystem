namespace UniversitySystem.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool IsPayingStudent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool IsGraduated { get; set; }
        public double? AverageGrade { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<ExamResult> ExamResults { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
