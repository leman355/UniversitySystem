namespace UniversitySystem.Entities
{
    public class Major
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Student> Students { get; set; }
    }
}
