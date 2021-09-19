using Application.Posts.Commands.CreatePost;
using Application.Posts.Query.GetPostImageUrl;
using Application.Posts.Query.GetPosts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagegramAPI.Controllers
{
    public class PostController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> CreatePost([FromBody] CreatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<GetPostsResult>> GetPosts([FromQuery] GetPostsQuery query)
        {
            return await Mediator.Send(query);
        }
        [HttpPost]
        public async Task<ActionResult<GetPostImageUrlResult>> GetPostUrl([FromBody] GetPostImageUrlQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
