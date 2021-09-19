using System;

namespace Domain.Entities
{
    public class Comment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Content { get; set; }
        public Account Creator { get; set; }
        public Post Post { get; set; }
        public string PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatorId { get; set; }
    }
}
