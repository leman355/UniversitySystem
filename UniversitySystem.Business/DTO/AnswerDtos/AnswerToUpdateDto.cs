namespace UniversitySystem.Business.DTO.AnswerDtos
{
    public record AnswerToUpdateDto
    {
        public string Option { get; set; }
        public bool Status { get; set; }
        public bool Selected { get; set; }
        public int QuestionId { get; set; }
    }
}
