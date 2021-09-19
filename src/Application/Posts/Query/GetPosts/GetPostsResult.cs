namespace Application.Posts.Query.GetPosts
{
    public class GetPostsResult
    {
        public int NextCursor { get; set; }
        public object Data { get; set; }
    }
}