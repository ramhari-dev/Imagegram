using Application.Comments.Commands.AddComment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagegramAPI.Controllers
{
    public class CommentController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] AddCommentCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
