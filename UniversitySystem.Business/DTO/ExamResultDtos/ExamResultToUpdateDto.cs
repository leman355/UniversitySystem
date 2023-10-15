namespace UniversitySystem.Business.DTO.ExamResultDtos
{
    public record ExamResultToUpdateDto
    {
        public double Grade { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
