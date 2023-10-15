namespace UniversitySystem.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Group> Groups { get; set; }
        public List<ExamResult> ExamResults { get; set; }
    }
}
