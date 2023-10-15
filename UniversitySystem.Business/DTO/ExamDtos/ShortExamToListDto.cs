namespace UniversitySystem.Business.DTO.ExamDtos
{
    public record ShortExamToListDto
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
