namespace UniversitySystem.Entities
{
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public double Grade { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
