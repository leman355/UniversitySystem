namespace UniversitySystem.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
        public List<Group> Groups { get; set; }
        public List<Class> Classes { get; set; }
        public bool IsDeleted { get; set; }
        public Exam Exam { get; set; }
        public List<Payment> Payments { get; set; }
    }
}