using System.ComponentModel.DataAnnotations;

namespace RWM.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Series { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public uint Pages { get; set; }
        public string CoverImgUrl { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
       
    }
}
