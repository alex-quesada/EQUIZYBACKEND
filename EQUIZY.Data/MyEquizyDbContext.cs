using EQUIZY.Core.Models;
using EQUIZY.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data
{
    public class MyEquizyDbContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        public DbSet<StateProvince> StatesProvinces { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<TypeAddress> TypesAddress { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddressList> UserAddressList { get; set; }
        public DbSet<TopicEvaluation> TopicsEvaluation { get; set; }
        public DbSet<TopicQuestion> TopicsQuestion { get; set; }
        public DbSet<CategoryEvaluation> CategoriesEvaluation { get; set; }
        public DbSet<CategoryQuestion> CategoriesQuestion { get; set; }
        public DbSet<TypeEvaluation> TypesEvaluation { get; set; }
        public DbSet<TypeQuestion> TypesQuestion { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<ProfessorEvaluationList> ProfessorEvaluationList { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerList> AnswerList { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuestionList> QuestionList { get; set; }

        public MyEquizyDbContext(DbContextOptions<MyEquizyDbContext> options) : base(options)
        {
        }

        public MyEquizyDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new StateProvinceConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new TypeAddressConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new UserAddressListConfiguration());
            builder.ApplyConfiguration(new TopicEvaluationConfiguration());
            builder.ApplyConfiguration(new TopicQuestionConfiguration());
            builder.ApplyConfiguration(new CategoryEvaluationConfiguration());
            builder.ApplyConfiguration(new CategoryQuestionConfiguration());
            builder.ApplyConfiguration(new TypeEvaluationConfiguration());
            builder.ApplyConfiguration(new TypeQuestionConfiguration());
            builder.ApplyConfiguration(new EvaluationConfiguration());
            builder.ApplyConfiguration(new ProfessorEvaluationListConfiguration());
            builder.ApplyConfiguration(new AnswerConfiguration());
            builder.ApplyConfiguration(new AnswerListConfiguration());
            builder.ApplyConfiguration(new QuizQuestionConfiguration());
            builder.ApplyConfiguration(new QuestionListConfiguration());
        }
    }
}
