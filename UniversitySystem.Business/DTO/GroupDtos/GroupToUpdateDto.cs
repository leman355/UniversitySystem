namespace UniversitySystem.Business.DTO.GroupDtos
{
    public record GroupToUpdateDto
    {
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
