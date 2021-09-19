using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Comments.Commands.AddComment
{
    class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(v => v.Content)
                .NotNull()
                .NotEmpty();

            RuleFor(v => v.PostId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
