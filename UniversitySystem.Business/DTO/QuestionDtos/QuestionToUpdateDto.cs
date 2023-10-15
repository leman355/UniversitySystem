namespace UniversitySystem.Business.DTO.QuestionDtos
{
    public record QuestionToUpdateDto
    {
        public string Content { get; set; }
        public int ExamId { get; set; }
    }
}
