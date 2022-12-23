using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Request;

public class ContentUpdateDTO
{
    [Required]
    public Guid Id { get; set; }
    public string? LanguageCode { get; set; }
    public string? Name { get; set; }
    public string? Content { get; set; }
    public bool? ImageLibrary { get; set; }
    public bool? VisibleOnMain { get; set; }
    public bool? IsFixed { get; set; }
    public int SortOrder { get; set; }
}