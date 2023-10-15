namespace UniversitySystem.Business.DTO.QuestionDtos
{
    public record ShortQuestionToListDto
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
    }
}
