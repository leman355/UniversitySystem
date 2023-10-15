namespace UniversitySystem.Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}