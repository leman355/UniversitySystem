namespace UniversitySystem.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public List<Answer> Answers { get; set; }
    }
}