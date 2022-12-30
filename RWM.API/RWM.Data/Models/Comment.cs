namespace RWM.Data.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public uint Page { get; set; }
    }
}
