namespace UniversitySystem.Business.DTO.GroupDtos
{
    public record GroupToAddDto
    {
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
