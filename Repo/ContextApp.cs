using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Context.Repo
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConfigurationTag>().HasData(
                new ConfigurationTag
                {
                    Id = 1,
                    Tag = "default_user_type_id",
                    Description = "default_user_type_id",
                    Value = "2",
                },
                new ConfigurationTag
                {
                    Id = 2,
                    Tag = "default_user_type_abreviations",
                    Description = "default_user_type_abreviations",
                    Value = "RP",
                },
                new ConfigurationTag
                {
                    Id=3,
                    Tag= "default_percent_compress",
                    Description= "default_percent_compress",
                    Value = "60"
                });
            modelBuilder.Entity<UserType>().HasData(
                new UserType
                {
                    Id = 1,
                    Abbreviation = "SADM",
                    Name = "Super Admin",
                    CreatedOn = DateTime.Now,
                    Deleted = false
                },
                  new UserType
                  {
                      Id = 2,
                      Abbreviation = "RP",
                      Name = "Representante",
                      CreatedOn = DateTime.Now,
                      Deleted = false
                  },
                   new UserType
                   {
                       Id = 3,
                       Abbreviation = "ADMF",
                       Name = "Administrador Filial",
                       CreatedOn = DateTime.Now,
                       Deleted = false
                   });
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Abbreviation = "BR",
                    PhonePrefix = 1,
                    Deleted = false,
                    Name = "Brazil",
                });


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            modelBuilder.Entity<LanguageTag>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<CodeValidation>();
            modelBuilder.Entity<PushNotificationKey>();
            modelBuilder.Entity<Company>();
            modelBuilder.Entity<ProposalHistoricEletric>();
            modelBuilder.Entity<Scheduler>();
            modelBuilder.Entity<Hierarchy>();
            modelBuilder.Entity<FAQ>();
            modelBuilder.Entity<CategoryBlog>();
            modelBuilder.Entity<Blog>();
            modelBuilder.Entity<Notication>();
            modelBuilder.Entity<Proposal>();
            modelBuilder.Entity<Cities>();

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<ConfigurationTag> ConfigurationTags { get; set; }
        public DbSet<LanguageTag> LanguageTags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CodeValidation> CodeValidations { get; set; }
        public DbSet<PushNotificationKey> PushNotificationKeys { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; }
        public DbSet<Hierarchy> Hierarchies { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<CategoryBlog> CategoriesBlog { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Notication> Notications { get; set; }
        public DbSet<Cities> Cities { get; set; }

        public DbSet<ProposalHistoricEletric> ProposalHistoricEletrics { get; set; }
        public DbSet<Proposal> Proposal { get; set; }
    }
}
