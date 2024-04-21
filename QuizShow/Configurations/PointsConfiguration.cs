using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizShow.Models;

namespace QuizShow.Configurations
{
    public class PointsConfiguration : IEntityTypeConfiguration<Points>
    {
        public void Configure(EntityTypeBuilder<Points> builder)
        {
           
          
        }
    }
}
