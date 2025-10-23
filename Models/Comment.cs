namespace comments;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Comment
{
    public int CommentId { get; set; }
    public int Score { get; set; }

    [Required]
    public string Content { get; set; } = "";
    public int? ParentCommentId { get; set; } = null;

    [JsonIgnore]
    public virtual Comment? ParentComment { get; set; }
    public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
