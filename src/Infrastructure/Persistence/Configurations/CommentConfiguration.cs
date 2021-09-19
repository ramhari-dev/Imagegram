using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(e => e.Comments)
                .HasForeignKey(f => f.PostId);

            builder.HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(f => f.CreatorId);
        }
    }
}