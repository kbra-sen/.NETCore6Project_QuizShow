using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizShow.Models;

namespace QuizShow.Configurations
{
    public class AnswersConfiguration : IEntityTypeConfiguration<Answers>
    {
        public void Configure(EntityTypeBuilder<Answers> builder)
        {
           
            builder.HasOne<Questions>(a => a.Question).WithMany(q => q.Answer).HasForeignKey(a => a.QuestionID);
        }
    }
}
