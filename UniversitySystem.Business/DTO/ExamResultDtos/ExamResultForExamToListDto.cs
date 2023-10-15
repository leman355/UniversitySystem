namespace UniversitySystem.Business.DTO.ExamResultDtos
{
    public record ExamResultForExamToListDto
    {
        public int ExamResultId { get; set; }
        public double Grade { get; set; }
    }
}
