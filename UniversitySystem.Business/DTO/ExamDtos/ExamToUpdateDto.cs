namespace UniversitySystem.Business.DTO.ExamDtos
{
    public record ExamToUpdateDto
    {
        public string ExamName { get; set; }
        public int CourseId { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
