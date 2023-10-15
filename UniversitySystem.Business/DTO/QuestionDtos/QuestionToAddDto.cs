namespace UniversitySystem.Business.DTO.QuestionDtos
{
    public record QuestionToAddDto
    {
        public string Content { get; set; }
        public int ExamId { get; set; }
    }
}
