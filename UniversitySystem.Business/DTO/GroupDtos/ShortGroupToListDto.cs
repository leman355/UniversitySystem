namespace UniversitySystem.Business.DTO.GroupDtos
{
    public record ShortGroupToListDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
