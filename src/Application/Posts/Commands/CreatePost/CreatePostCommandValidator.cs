using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(v => v.Caption)
                .NotNull()
                .NotEmpty();            
            RuleFor(v => v.Image)
                .NotNull()
                .NotEmpty();
        }
    }
}
