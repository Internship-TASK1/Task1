using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid(); // Khởi tạo Id tự động

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string? DeletedBy { get; set; }

    public DateTimeOffset CreatedTime { get; set; }

    public DateTimeOffset LastUpdatedTime { get; set; }

    public DateTimeOffset? DeletedTime { get; set; }
}
