namespace Backend.DTOs.Response;

public class ImageDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int SortOrder { get; set; }
    public bool IsCover { get; set; }
    public Guid ContentId { get; set; }
}