using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizShow.Models;

namespace QuizShow.Configurations
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {

            builder.HasOne<Points>(q => q.Point).WithMany(p => p.Question).HasForeignKey(q => q.PointID);
        }
    }
}
