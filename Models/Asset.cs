using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace comments;

public class Asset
{
    public int AssetId { get; set; }

    [Required]
    public string Path { get; set; } = "";
    [Required]
    public int UserId { get; set; }
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}