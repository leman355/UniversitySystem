using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public List<Group> Groups { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }
        public List<ExamResult> ExamResults { get; set; }
        public List<Question> Questions { get; set; }
    }
}
