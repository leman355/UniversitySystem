using UniversitySystem.Business.DTO.QuestionDtos;

namespace UniversitySystem.Business.DTO.AnswerDtos
{
    public record AnswerToListDto
    {
        public int AnswerId { get; set; }
        public string Option { get; set; }
        public bool Status { get; set; }
        public bool Selected { get; set; }
        public ShortQuestionToListDto Question { get; set; }
    }
}
