using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

[Table("content")]
public class ContentModel
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string? LanguageCode { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Link { get; set; }

    public string? Content { get; set; }

    public bool IsSubContent { get; set; }

    public bool IsImageLibrary { get; set; }

    public bool IsVisibleOnIndex { get; set; }

    public bool IsFixed { get; set; }

    public bool IsCompleted { get; set; }

    public int SortOrder { get; set; }

    public Guid? HeaderContentId { get; set; }

    [ForeignKey(nameof(HeaderContentId))]
    public ContentModel? HeaderContent { get; set; }

    public ICollection<ImageLibraryModel>? Images { get; set; }
}