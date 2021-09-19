using Application.Posts.Commands.CreatePost;
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
    }
}
