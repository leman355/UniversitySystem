namespace UniversitySystem.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string HeadOfDepartment { get; set; }
        public List<Major> Majors { get; set; }
    }
}
