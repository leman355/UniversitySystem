using UniversitySystem.Business.DTO.AnswerDtos;
using UniversitySystem.Business.DTO.ExamDtos;

namespace UniversitySystem.Business.DTO.QuestionDtos
{
    public record QuestionToListDto
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public ShortExamToListDto Exam { get; set; }
        public List<ShortAnswerToListDto> Answers { get; set; }
    }
}
