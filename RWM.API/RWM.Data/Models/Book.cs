using System.ComponentModel.DataAnnotations;

namespace RWM.Data.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Series { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string CoverImgUrl { get; set; }
       
    }
}
