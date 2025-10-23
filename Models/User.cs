using System.ComponentModel.DataAnnotations;

namespace comments;

public class User
{
    public int UserId { get; set; }

    [Required]
    public string Name { get; set; } = "";
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}