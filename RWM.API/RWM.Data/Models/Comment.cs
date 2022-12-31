using System.ComponentModel.DataAnnotations;

namespace RWM.Data.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public int Page { get; set; }
        public Guid BookId { get; set; }
    }
}
