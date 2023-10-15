namespace UniversitySystem.Business.DTO.AnswerDtos
{
    public record ShortAnswerToListDto
    {
        public int AnswerId { get; set; }
        public string Option { get; set; }
        public bool Status { get; set; } = false;
        public bool Selected { get; set; } = false;
    }
}
