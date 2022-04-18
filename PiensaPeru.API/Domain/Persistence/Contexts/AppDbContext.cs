using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Models.UserBoundedContextModels;
using PiensaPeru.API.Extensions;

namespace PiensaPeru.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Person>? People { get; set; }
        public DbSet<Supervisor>? Supervisors { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Paragraph>? Paragraphs { get; set; }
        public DbSet<PercentageData>? PercentagesData { get; set; }
        public DbSet<Content>? Contents { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Quiz>? Quizzes { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Option>? Options { get; set; }
        public DbSet<Administrator>? Administrators { get; set; }
        public DbSet<Management>? Managements { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Calification>? Califications { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PoliticalParty>? PoliticalParties { get; set; }
        public DbSet<Period>? Periods { get; set; }
        public DbSet<Militant>? Militants { get; set; }
        public DbSet<MilitantContent>? MilitantContents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person Entity
            modelBuilder.Entity<Person>().ToTable("People");
            
            // Constraints
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().HasDiscriminator(p => p.PersonType).IsComplete(false);
            modelBuilder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();

            // Supervisor Constraints
            modelBuilder.Entity<Supervisor>().Property(s => s.Email).HasColumnName("email").IsRequired();
            modelBuilder.Entity<Supervisor>().Property(s => s.Password).HasColumnName("password").IsRequired();

            // Supervisor Seed Data

            modelBuilder.Entity<Supervisor>().HasData
                (
                    new Supervisor
                    {
                        Id = 100,
                        FirstName = "José",
                        LastName = "Quispe",
                        Email = "jose.quispe@gmail.com",
                        Password = "password123"
                    },

                    new Supervisor
                    {
                        Id = 101,
                        FirstName = "Olga",
                        LastName = "Pérez",
                        Email = "olga.perez@gmail.com",
                        Password = "password123"
                    }
                );

            // Aministrator Constraints
            modelBuilder.Entity<Administrator>().Property(a => a.Email).HasColumnName("email").IsRequired();
            modelBuilder.Entity<Administrator>().Property(a => a.Password).HasColumnName("password").IsRequired();

            // Administrator Seed Data
            modelBuilder.Entity<Administrator>().HasData
                (
                    new Administrator
                    {
                        Id = 102,
                        FirstName = "Juan",
                        LastName = "Pérez",
                        Email = "juan.perez@gmail.com",
                        Password = "password123"
                    },

                    new Administrator
                    {
                        Id = 103,
                        FirstName = "Gloria",
                        LastName = "Ramps",
                        Email = "gloria.ramos@gmail.com",
                        Password = "password123"
                    }
                );

            // User Constraints
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Subscribed).IsRequired();

            // User Seed Data
            modelBuilder.Entity<User>().HasData
                (
                    new User
                    {
                        Id = 104,
                        FirstName = "Rómulo",
                        LastName = "López",
                        Email = "romulo.lopez@gmail.com",
                        Password = "password123",
                        Subscribed = true
                    },
                    
                    new User
                    {
                        Id = 105,
                        FirstName = "María",
                        LastName = "García",
                        Email = "maria.garcia@gmail.com",
                        Password = "password123",
                        Subscribed = false
                    }
                );

            
            // Post Entity
            modelBuilder.Entity<Post>().ToTable("Posts");

            // Post Constraints
            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            modelBuilder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Post>().Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Post>().Property(p => p.AuthorName).IsRequired();
            modelBuilder.Entity<Post>().Property(p => p.Tag).IsRequired();
            modelBuilder.Entity<Post>().Property(p => p.ContentId).IsRequired();
            modelBuilder.Entity<Post>().Property(p => p.SupervisorId).IsRequired();
            modelBuilder.Entity<Post>().Property(p => p.PostType).IsRequired();

            // Post Seed Data
            modelBuilder.Entity<Post>().HasData
                (
                    new Post
                    {
                        Id = 100,
                        Title = "Post 1",
                        AuthorName = "José Quispe",
                        Tag = "Tag 1",
                        ContentId = 100,
                        SupervisorId = 100,
                        PostType = "Type 1"
                    },

                    new Post
                    {
                        Id = 101,
                        Title = "Post 2",
                        AuthorName = "José Quispe",
                        Tag = "Tag 2",
                        ContentId = 101,
                        SupervisorId = 100,
                        PostType = "Type 1"
                    },

                    new Post
                    {
                        Id = 102,
                        Title = "Post 3",
                        AuthorName = "José Quispe",
                        Tag = "Tag 3",
                        ContentId = 102,
                        SupervisorId = 100,
                        PostType = "Type 2"
                    },

                    new Post
                    {
                        Id = 103,
                        Title = "Post 4",
                        AuthorName = "José Quispe",
                        Tag = "Tag 4",
                        ContentId = 103,
                        SupervisorId = 100,
                        PostType = "Type 2"
                    },

                    new Post
                    {
                        Id = 104,
                        Title = "Post 5",
                        AuthorName = "José Quispe",
                        Tag = "Tag 5",
                        ContentId = 104,
                        SupervisorId = 100,
                        PostType = "Type 3"
                    },

                    new Post
                    {
                        Id = 105,
                        Title = "Post 6",
                        AuthorName = "José Quispe",
                        Tag = "Tag 6",
                        ContentId = 105,
                        SupervisorId = 100,
                        PostType = "Type 3"
                    },

                    new Post
                    {
                        Id = 106,
                        Title = "Post 7",
                        AuthorName = "José Quispe",
                        Tag = "Tag 7",
                        ContentId = 106,
                        SupervisorId = 100,
                        PostType = "Type 3"
                    }
                );

            // Content Entity
            modelBuilder.Entity<Content>().ToTable("Contents");

            // Content Constraints
            modelBuilder.Entity<Content>().HasKey(c => c.Id);
            modelBuilder.Entity<Content>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Content>().Property(c => c.Active).IsRequired();

            // Content Seed Data
            modelBuilder.Entity<Content>().HasData
                (
                    new Content
                    {
                        Id = 100,
                        Active = true
                    },

                    new Content
                    {
                        Id = 101,
                        Active = true
                    },

                    new Content
                    {
                        Id = 102,
                        Active = true
                    },

                    new Content
                    {
                        Id = 103,
                        Active = true
                    },

                    new Content
                    {
                        Id = 104,
                        Active = true
                    },

                    new Content
                    {
                        Id = 105,
                        Active = true
                    },

                    new Content
                    {
                        Id = 106,
                        Active = true
                    }
                );

            // Quiz Entity
            modelBuilder.Entity<Quiz>().ToTable("Quizzes");

            // Quiz Constraints
            modelBuilder.Entity<Quiz>().HasKey(q => q.Id);
            modelBuilder.Entity<Quiz>().Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Quiz>().Property(q => q.Title).IsRequired();
            modelBuilder.Entity<Quiz>().Property(q => q.PostId).IsRequired();

            // Quiz Seed Data
            modelBuilder.Entity<Quiz>().HasData
                (
                    new Quiz
                    {
                        Id = 100,
                        Title = "Quiz 1",
                        PostId = 100
                    },

                    new Quiz
                    {
                        Id = 101,
                        Title = "Quiz 2",
                        PostId = 101
                    },

                    new Quiz
                    {
                        Id = 102,
                        Title = "Quiz 3",
                        PostId = 102
                    },

                    new Quiz
                    {
                        Id = 103,
                        Title = "Quiz 4",
                        PostId = 103
                    },

                    new Quiz
                    {
                        Id = 104,
                        Title = "Quiz 5",
                        PostId = 104
                    }
                );

            // Question Entity
            modelBuilder.Entity<Question>().ToTable("Questions");

            // Question Constraints
            modelBuilder.Entity<Question>().HasKey(q => q.Id);
            modelBuilder.Entity<Question>().Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Question>().Property(q => q.QuizId).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.Description).IsRequired();

            // Question Seed Data
            modelBuilder.Entity<Question>().HasData
                (
                    new Question
                    {
                        Id = 100,
                        QuizId = 100,
                        Description = "Question 1"
                    },

                    new Question
                    {
                        Id = 101,
                        QuizId = 100,
                        Description = "Question 2"
                    },

                    new Question
                    {
                        Id = 102,
                        QuizId = 100,
                        Description = "Question 3"
                    },

                    new Question
                    {
                        Id = 103,
                        QuizId = 101,
                        Description = "Question 4"
                    },

                    new Question
                    {
                        Id = 104,
                        QuizId = 101,
                        Description = "Question 5"
                    },

                    new Question
                    {
                        Id = 105,
                        QuizId = 101,
                        Description = "Question 6"
                    },

                    new Question
                    {
                        Id = 106,
                        QuizId = 102,
                        Description = "Question 7"
                    },

                    new Question
                    {
                        Id = 107,
                        QuizId = 102,
                        Description = "Question 8"
                    },

                    new Question
                    {
                        Id = 108,
                        QuizId = 102,
                        Description = "Question 9"
                    },

                    new Question
                    {
                        Id = 109,
                        QuizId = 103,
                        Description = "Question 10"
                    },

                    new Question
                    {
                        Id = 110,
                        QuizId = 103,
                        Description = "Question 11"
                    },

                    new Question
                    {
                        Id = 111,
                        QuizId = 103,
                        Description = "Question 12"
                    },

                    new Question
                    {
                        Id = 112,
                        QuizId = 104,
                        Description = "Question 13"
                    },

                    new Question
                    {
                        Id = 113,
                        QuizId = 104,
                        Description = "Question 14"
                    },

                    new Question
                    {
                        Id = 114,
                        QuizId = 104,
                        Description = "Question 15"
                    }
                 );

            // Option Entity
            modelBuilder.Entity<Option>().ToTable("Options");

            // Option Constraints
            modelBuilder.Entity<Option>().HasKey(o => o.Id);
            modelBuilder.Entity<Option>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Option>().Property(o => o.QuestionId).IsRequired();
            modelBuilder.Entity<Option>().Property(o => o.Description).IsRequired();
            modelBuilder.Entity<Option>().Property(o => o.IsAnswer).IsRequired();

            // Option Seed Data
            modelBuilder.Entity<Option>().HasData
                (
                    new Option
                    {
                        Id = 100,
                        QuestionId = 100,
                        Description = "Option 1",
                        IsAnswer = true
                    },

                    new Option
                    {
                        Id = 101,
                        QuestionId = 100,
                        Description = "Option 2",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 102,
                        QuestionId = 100,
                        Description = "Option 3",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 103,
                        QuestionId = 100,
                        Description = "Option 4",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 104,
                        QuestionId = 101,
                        Description = "Option 5",
                        IsAnswer = true
                    },

                    new Option
                    {
                        Id = 105,
                        QuestionId = 101,
                        Description = "Option 6",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 106,
                        QuestionId = 101,
                        Description = "Option 7",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 107,
                        QuestionId = 101,
                        Description = "Option 8",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 108,
                        QuestionId = 102,
                        Description = "Option 9",
                        IsAnswer = true
                    },

                    new Option
                    {
                        Id = 109,
                        QuestionId = 102,
                        Description = "Option 10",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 110,
                        QuestionId = 102,
                        Description = "Option 11",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 111,
                        QuestionId = 102,
                        Description = "Option 12",
                        IsAnswer = false
                    },

                    new Option
                    {
                        Id = 112,
                        QuestionId = 102,
                        Description = "Option 13",
                        IsAnswer = false
                    }
                 );

            // Image Entity

            modelBuilder.Entity<Image>().ToTable("Images");

            // Constraints

            modelBuilder.Entity<Image>().HasKey(i => i.Id);
            modelBuilder.Entity<Image>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Image>().Property(i => i.Url).IsRequired();
            modelBuilder.Entity<Image>().Property(i => i.Title).IsRequired();
            modelBuilder.Entity<Image>().Property(i => i.PostId).IsRequired();

            // Image Seed Data

            modelBuilder.Entity<Image>().HasData
                (
                    new Image
                    {
                        Id = 100,
                        Url = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60",
                        Title = "Image 1",
                        PostId = 100
                    },

                    new Image
                    {
                        Id = 101,
                        Url = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60",
                        Title = "Image 2",
                        PostId = 100
                    },

                    new Image
                    {
                        Id = 102,
                        Url = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60",
                        Title = "Image 3",
                        PostId = 101
                    },

                    new Image
                    {
                        Id = 104,
                        Url = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60",
                        Title = "Image 4",
                        PostId = 101
                    }
              );

            // Paragraph Entity

            modelBuilder.Entity<Paragraph>().ToTable("Paragraphs");

            // Constraints

            modelBuilder.Entity<Paragraph>().HasKey(p => p.Id);
            modelBuilder.Entity<Paragraph>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Paragraph>().Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Paragraph>().Property(p => p.Content).IsRequired();
            modelBuilder.Entity<Paragraph>().Property(p => p.PostId).IsRequired();

            // Paragraph Seed Data

            modelBuilder.Entity<Paragraph>().HasData
                (
                    new Paragraph
                    {
                        Id = 100,
                        Title = "Paragraph 1",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PostId = 100
                    },

                    new Paragraph
                    {
                        Id = 101,
                        Title = "Paragraph 2",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PostId = 101
                    },

                    new Paragraph
                    {
                        Id = 102,
                        Title = "Paragraph 3",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PostId = 102
                    }
                 );

            // PercentageData Entity

            modelBuilder.Entity<PercentageData>().ToTable("PercentageData");

            // Constraints

            modelBuilder.Entity<PercentageData>().HasKey(pd => pd.Id);
            modelBuilder.Entity<PercentageData>().Property(pd => pd.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<PercentageData>().Property(pd => pd.Number).IsRequired();
            modelBuilder.Entity<PercentageData>().Property(pd => pd.Description).IsRequired();
            modelBuilder.Entity<PercentageData>().Property(pd => pd.ContentId).IsRequired();
            modelBuilder.Entity<PercentageData>().Property(pd => pd.DataType).IsRequired();

            // PercentageData Seed Data

            modelBuilder.Entity<PercentageData>().HasData
                (
                    new PercentageData
                    {
                        Id = 100,
                        Number = 20,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 100,
                        DataType = "Type 1"
                    },

                    new PercentageData
                    {
                        Id = 101,
                        Number = 20,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 101,
                        DataType = "Type 2"
                    },

                    new PercentageData
                    {
                        Id = 102,
                        Number = 30,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 102,
                        DataType = "Type 3"
                    }
                 );

            // Management Entity
            modelBuilder.Entity<Management>().ToTable("Managements");

            // Management Constraints
            modelBuilder.Entity<Management>().HasKey(m => m.Id);
            modelBuilder.Entity<Management>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Management>().Property(m => m.ManagementType).IsRequired();
            modelBuilder.Entity<Management>().Property(m => m.AdministratorId).IsRequired();
            modelBuilder.Entity<Management>().Property(m => m.ContentId).IsRequired();

            // Management Seed Data
            modelBuilder.Entity<Management>().HasData
                (
                    new Management
                    {
                        Id = 100,
                        ManagementType = "Type 1",
                        AdministratorId = 102,
                        ContentId = 100
                    },

                    new Management
                    {
                        Id = 101,
                        ManagementType = "Type 1",
                        AdministratorId = 102,
                        ContentId = 101
                    },

                    new Management
                    {
                        Id = 102,
                        ManagementType = "Type 1",
                        AdministratorId = 102,
                        ContentId = 102
                    },

                    new Management
                    {
                        Id = 103,
                        ManagementType = "Type 1",
                        AdministratorId = 101,
                        ContentId = 103
                    }
                );

            
            // Calification Entity
            modelBuilder.Entity<Calification>().ToTable("Califications");

            // Calification Constraints
            modelBuilder.Entity<Calification>().HasKey(c => c.Id);
            modelBuilder.Entity<Calification>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Calification>().Property(c => c.Score).IsRequired();
            modelBuilder.Entity<Calification>().Property(c => c.UserId).IsRequired();

            // Calification Seed Data
            modelBuilder.Entity<Calification>().HasData
                (
                    new Calification
                    {
                        Id = 100,
                        Score = 10,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 101,
                        Score = 20,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 102,
                        Score = 30,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 103,
                        Score = 40,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 104,
                        Score = 50,
                        UserId = 104
                    },

                    new Calification
                    {
                        Id = 105,
                        Score = 60,
                        UserId = 105
                    },

                    new Calification
                    {
                        Id = 106,
                        Score = 70,
                        UserId = 105
                    },

                    new Calification
                    {
                        Id = 107,
                        Score = 80,
                        UserId = 105
                    },

                    new Calification
                    {
                        Id = 108,
                        Score = 90,
                        UserId = 105
                    },

                    new Calification
                    {
                        Id = 109,
                        Score = 100,
                        UserId = 105
                    }
                );

            // Plan Entity
            modelBuilder.Entity<Plan>().ToTable("Plans");

            // Plan Constraints
            modelBuilder.Entity<Plan>().HasKey(p => p.UserId);
            modelBuilder.Entity<Plan>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Plan>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<Plan>().Property(p => p.Price).IsRequired();

            // Plan Seed Data
            modelBuilder.Entity<Plan>().HasData
                (
                    new Plan
                    {
                        UserId = 100,
                        Name = "Plan 1",
                        Description = "Plan 1 Description",
                        Price = 100
                    },

                    new Plan
                    {
                        UserId = 101,
                        Name = "Plan 2",
                        Description = "Plan 2 Description",
                        Price = 200
                    },

                    new Plan
                    {
                        UserId = 102,
                        Name = "Plan 3",
                        Description = "Plan 3 Description",
                        Price = 300
                    }
                );

            // Constraints

            modelBuilder.Entity<Militant>().Property(m => m.MilitantTypeId).IsRequired();
            modelBuilder.Entity<Militant>().Property(m => m.BirthPlace).IsRequired();
            modelBuilder.Entity<Militant>().Property(m => m.BirthDate).IsRequired();
            modelBuilder.Entity<Militant>().Property(m => m.Profession).IsRequired();
            modelBuilder.Entity<Militant>().Property(m => m.PolitcalPartyId).IsRequired();
            modelBuilder.Entity<Militant>().Property(m => m.PictureLink).IsRequired();
            modelBuilder.Entity<Militant>().Property(m => m.IsPresident).IsRequired();
            modelBuilder.Entity<Militant>().Property(m => m.FirstName).IsRequired();
            modelBuilder.Entity<Militant>().Property(m => m.LastName).IsRequired();

            // Militant Seed Data

            modelBuilder.Entity<Militant>().HasData
                (
                    new Militant
                    {
                        Id = 106,
                        MilitantTypeId = 100,
                        BirthPlace = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        BirthDate = new DateTime(2000, 1, 1),
                        Profession = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PolitcalPartyId = 100,
                        PictureLink = "https://gdb.voanews.com/FA20D409-3A95-46EE-AC95-5B49B1C389F2_cx0_cy1_cw0_w1023_r1_s.jpg",
                        IsPresident = true,
                        FirstName = "Pepe",
                        LastName = "Sech"
                    },
                    new Militant
                    {
                        Id = 107,
                        MilitantTypeId = 101,
                        BirthPlace = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        BirthDate = new DateTime(2000, 1, 1),
                        Profession = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PolitcalPartyId = 100,
                        PictureLink = "https://gdb.voanews.com/FA20D409-3A95-46EE-AC95-5B49B1C389F2_cx0_cy1_cw0_w1023_r1_s.jpg",
                        IsPresident = true,
                        FirstName = "Pepa",
                        LastName = "Sesha"
                    },
                    new Militant
                    {
                        Id = 108,
                        MilitantTypeId = 102,
                        BirthPlace = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        BirthDate = new DateTime(2000, 1, 1),
                        Profession = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PolitcalPartyId = 101,
                        PictureLink = "https://gdb.voanews.com/FA20D409-3A95-46EE-AC95-5B49B1C389F2_cx0_cy1_cw0_w1023_r1_s.jpg",
                        IsPresident = true,
                        FirstName = "ET",
                        LastName = "Czech"
                    }
                );

            // MilitantContent Entity

            modelBuilder.Entity<MilitantContent>().ToTable("MilitantContents");

            // Constraints

            modelBuilder.Entity<MilitantContent>().HasKey(mc => new { mc.MilitantId, mc.ContentId });
            modelBuilder.Entity<MilitantContent>().Property(mc => mc.MilitantId).IsRequired();
            modelBuilder.Entity<MilitantContent>().Property(mc => mc.ContentId).IsRequired();
            modelBuilder.Entity<MilitantContent>().Property(mc => mc.PeriodId).IsRequired();

            // MilitantContent Seed Data

            modelBuilder.Entity<MilitantContent>().HasData
                (
                    new MilitantContent
                    {
                        MilitantId = 100,
                        ContentId = 100,
                        PeriodId = 100
                    },
                    new MilitantContent
                    {
                        MilitantId = 101,
                        ContentId = 102,
                        PeriodId = 101
                    },
                    new MilitantContent
                    {
                        MilitantId = 101,
                        ContentId = 101,
                        PeriodId = 102
                    },
                    new MilitantContent
                    {
                        MilitantId = 102,
                        ContentId = 101,
                        PeriodId = 103
                    }
                );

            // Period Entity

            modelBuilder.Entity<Period>().ToTable("Periods");

            // Constraints

            modelBuilder.Entity<Period>().HasKey(p => p.Id);
            modelBuilder.Entity<Period>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Period>().Property(p => p.StartDate).IsRequired();
            modelBuilder.Entity<Period>().Property(p => p.EndDate).IsRequired();
            modelBuilder.Entity<Period>().Property(p => p.OriginOfCharge).IsRequired();

            // Period Seed Data

            modelBuilder.Entity<Period>().HasData
                (
                    new Period
                    {
                        Id = 100,
                        StartDate = new DateTime(2000, 1, 1),
                        EndDate = new DateTime(2000, 1, 1),
                        OriginOfCharge = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                    },
                    new Period
                    {
                        Id = 101,
                        StartDate = new DateTime(2000, 1, 1),
                        EndDate = new DateTime(2000, 1, 1),
                        OriginOfCharge = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                    },
                    new Period
                    {
                        Id = 102,
                        StartDate = new DateTime(2000, 1, 1),
                        EndDate = new DateTime(2000, 1, 1),
                        OriginOfCharge = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                    },
                    new Period
                    {
                        Id = 103,
                        StartDate = new DateTime(2000, 1, 1),
                        EndDate = new DateTime(2000, 1, 1),
                        OriginOfCharge = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                    }
                );

            // Political Party Entity

            modelBuilder.Entity<PoliticalParty>().ToTable("PoliticalParties");

            // Constraints

            modelBuilder.Entity<PoliticalParty>().HasKey(pp => pp.Id);
            modelBuilder.Entity<PoliticalParty>().Property(pp => pp.Id).IsRequired();
            modelBuilder.Entity<PoliticalParty>().Property(pp => pp.Name).IsRequired();
            modelBuilder.Entity<PoliticalParty>().Property(pp => pp.PresidentName).IsRequired();
            modelBuilder.Entity<PoliticalParty>().Property(pp => pp.FoundationDate).IsRequired();
            modelBuilder.Entity<PoliticalParty>().Property(pp => pp.Ideology).IsRequired();
            modelBuilder.Entity<PoliticalParty>().Property(pp => pp.Position).IsRequired();
            modelBuilder.Entity<PoliticalParty>().Property(pp => pp.PictureLink).IsRequired();

            // Political Party Seed Data

            modelBuilder.Entity<PoliticalParty>().HasData
                (
                    new PoliticalParty
                    {
                        Id = 100,
                        Name = "Political Party 1",
                        PresidentName = "President 1",
                        FoundationDate = new DateTime(2000, 1, 1),
                        Ideology = "Ideology 1",
                        Position = "Position 1",
                        PictureLink = "https://cdn.logojoy.com/wp-content/uploads/2018/05/30144704/2_big2-768x591.png"
                    },
                    new PoliticalParty
                    {
                        Id = 101,
                        Name = "Political Party 2",
                        PresidentName = "President 1",
                        FoundationDate = new DateTime(2000, 1, 1),
                        Ideology = "Ideology 1",
                        Position = "Position 1",
                        PictureLink = "https://cdn.logojoy.com/wp-content/uploads/2018/05/30144704/2_big2-768x591.png"
                    },
                    new PoliticalParty
                    {
                        Id = 102,
                        Name = "Political Party 3",
                        PresidentName = "President 1",
                        FoundationDate = new DateTime(2000, 1, 1),
                        Ideology = "Ideology 1",
                        Position = "Position 1",
                        PictureLink = "https://cdn.logojoy.com/wp-content/uploads/2018/05/30144704/2_big2-768x591.png"
                    }
                );

            // Militant Type Entity

            modelBuilder.Entity<MilitantType>().ToTable("MilitantTypes");

            // Constraints

            modelBuilder.Entity<MilitantType>().HasKey(mt => mt.Id);
            modelBuilder.Entity<MilitantType>().Property(mt => mt.Id).IsRequired();
            modelBuilder.Entity<MilitantType>().Property(mt => mt.Type).IsRequired();

            // Militant Type Seed Data

            modelBuilder.Entity<MilitantType>().HasData
                (
                    new MilitantType
                    {
                        Id = 100,
                        Type = "Militant Type 1"
                    },
                    new MilitantType
                    {
                        Id = 101,
                        Type = "Militant Type 2"
                    },
                    new MilitantType
                    {
                        Id = 102,
                        Type = "Militant Type 3"
                    }
                );
            
            // Relationships
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Content)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.ContentId);
            
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Images)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId);
            
            modelBuilder.Entity<Paragraph>()
                .HasOne(p => p.Post)
                .WithMany(pt => pt.Paragraphs)
                .HasForeignKey(p => p.PostId);
            
            modelBuilder.Entity<PercentageData>()
                .HasOne(pd => pd.Content)
                .WithMany(c => c.PercentagesData)
                .HasForeignKey(pd => pd.ContentId);

            modelBuilder.Entity<Supervisor>()
                .HasMany(s => s.Posts)
                .WithOne(p => p.Supervisor)
                .HasForeignKey(p => p.SupervisorId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Quiz)
                .WithOne(q => q.Post)
                .HasForeignKey<Quiz>(q => q.PostId);

            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);
            
            modelBuilder.Entity<Content>()
                .HasMany(c => c.Managements)
                .WithOne(m => m.Content)
                .HasForeignKey(m => m.ContentId);

            modelBuilder.Entity<Administrator>()
                .HasMany(a => a.Managements)
                .WithOne(p => p.Administrator)
                .HasForeignKey(p => p.AdministratorId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Califications)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Plan)
                .WithOne(p => p.User)
                .HasForeignKey<Plan>(p => p.UserId);

            modelBuilder.Entity<Militant>()
                .HasOne(p => p.PoliticalParty)
                .WithMany(c => c.Militants)
                .HasForeignKey(m => m.PolitcalPartyId);
            
            modelBuilder.Entity<Militant>()
                .HasOne(p => p.MilitantType)
                .WithMany(pt => pt.Militants)
                .HasForeignKey(p => p.MilitantTypeId);
            
            modelBuilder.Entity<MilitantContent>()
                .HasOne(p => p.Militant)
                .WithMany(pt => pt.MilitantContents)
                .HasForeignKey(p => p.MilitantId);

            modelBuilder.Entity<MilitantContent>()
                .HasOne(p => p.Content)
                .WithMany(pt => pt.MilitantContents)
                .HasForeignKey(p => p.ContentId);
            
            modelBuilder.Entity<MilitantContent>()
                .HasOne(p => p.Period)
                .WithOne(pt => pt.MilitantContent)
                .HasForeignKey<MilitantContent>(p => p.PeriodId);
            
            modelBuilder.ApplySnakeCaseNamingConvention();
        }
    }
}
