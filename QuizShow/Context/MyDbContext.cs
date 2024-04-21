using Microsoft.EntityFrameworkCore;
using QuizShow.Configurations;
using QuizShow.Models;

namespace QuizShow.Context
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) //mydb den olusturduğumuz nesneyi base ile dbcontexte gönderdik
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswersConfiguration());
            modelBuilder.ApplyConfiguration(new PointsConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionsConfiguration());
         }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
