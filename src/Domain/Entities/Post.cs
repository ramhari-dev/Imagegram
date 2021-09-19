using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
        public Account Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string CreatorId { get; set; }
    }
}
