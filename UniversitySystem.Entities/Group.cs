namespace UniversitySystem.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
        public List<User> Users { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
