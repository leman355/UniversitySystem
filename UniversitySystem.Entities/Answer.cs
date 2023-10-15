namespace UniversitySystem.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Option { get; set; }
        public bool Status { get; set; } = false;
        public bool Selected { get; set; } = false;
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}