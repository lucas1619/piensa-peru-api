using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
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
        public DbSet<DataType>? DataTypes { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Paragraph>? Paragraphs { get; set; }
        public DbSet<PostType>? PostTypes { get; set; }
        public DbSet<PercentageData>? PercentagesData { get; set; }
        public DbSet<Content>? Contents { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Quiz>? Quizzes { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Option>? Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person Entity
            modelBuilder.Entity<Person>().ToTable("People");

            // Constraints
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().HasDiscriminator(p => p.PersonType);
            modelBuilder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();

            // Supervisor Constraints
            modelBuilder.Entity<Supervisor>().Property(s => s.Email).IsRequired();
            modelBuilder.Entity<Supervisor>().Property(s => s.Password).IsRequired();

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
            modelBuilder.Entity<Post>().Property(p => p.PostTypeId).IsRequired();

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
                        PostTypeId = 100
                    },

                    new Post
                    {
                        Id = 101,
                        Title = "Post 2",
                        AuthorName = "José Quispe",
                        Tag = "Tag 2",
                        ContentId = 101,
                        SupervisorId = 100,
                        PostTypeId = 100
                    },

                    new Post
                    {
                        Id = 102,
                        Title = "Post 3",
                        AuthorName = "José Quispe",
                        Tag = "Tag 3",
                        ContentId = 102,
                        SupervisorId = 100,
                        PostTypeId = 101
                    },

                    new Post
                    {
                        Id = 103,
                        Title = "Post 4",
                        AuthorName = "José Quispe",
                        Tag = "Tag 4",
                        ContentId = 103,
                        SupervisorId = 100,
                        PostTypeId = 101
                    },

                    new Post
                    {
                        Id = 104,
                        Title = "Post 5",
                        AuthorName = "José Quispe",
                        Tag = "Tag 5",
                        ContentId = 104,
                        SupervisorId = 100,
                        PostTypeId = 102
                    },

                    new Post
                    {
                        Id = 105,
                        Title = "Post 6",
                        AuthorName = "José Quispe",
                        Tag = "Tag 6",
                        ContentId = 105,
                        SupervisorId = 100,
                        PostTypeId = 102
                    },

                    new Post
                    {
                        Id = 106,
                        Title = "Post 7",
                        AuthorName = "José Quispe",
                        Tag = "Tag 7",
                        ContentId = 106,
                        SupervisorId = 100,
                        PostTypeId = 102
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

            // DataType Entity
            modelBuilder.Entity<DataType>().ToTable("DataTypes");

            // Constraints
            modelBuilder.Entity<DataType>().HasKey(dt => dt.Id);
            modelBuilder.Entity<DataType>().Property(dt => dt.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<DataType>().Property(dt => dt.Name).IsRequired();

            // DataType Seed Data

            modelBuilder.Entity<DataType>().HasData
                (
                    new DataType
                    {
                        Id = 100,
                        Name = "Percentage"
                    },

                    new DataType
                    {
                        Id = 101,
                        Name = "Number"
                    },

                    new DataType
                    {
                        Id = 102,
                        Name = "idk"
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
            modelBuilder.Entity<PercentageData>().Property(pd => pd.DataTypeId).IsRequired();

            // PercentageData Seed Data

            modelBuilder.Entity<PercentageData>().HasData
                (
                    new PercentageData
                    {
                        Id = 100,
                        Number = 20,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 100,
                        DataTypeId = 100
                    },

                    new PercentageData
                    {
                        Id = 101,
                        Number = 20,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 101,
                        DataTypeId = 101
                    },

                    new PercentageData
                    {
                        Id = 102,
                        Number = 30,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 102,
                        DataTypeId = 102
                    }
                 );

            // PostType Entity

            modelBuilder.Entity<PostType>().ToTable("PostTypes");

            // Constraints

            modelBuilder.Entity<PostType>().HasKey(pt => pt.Id);
            modelBuilder.Entity<PostType>().Property(pt => pt.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<PostType>().Property(pt => pt.Name).IsRequired();

            // PostType Seed Data

            modelBuilder.Entity<PostType>().HasData
                (
                    new PostType
                    {
                        Id = 100,
                        Name = "Post Type 1"
                    },

                    new PostType
                    {
                        Id = 101,
                        Name = "Post Type 2"
                    },

                    new PostType
                    {
                        Id = 102,
                        Name = "Post Type 3"
                    }
                );
            
            // Relationships

            modelBuilder.Entity<Post>().HasOne(p => p.Content).WithMany(c => c.Posts).HasForeignKey(p => p.ContentId);
            modelBuilder.Entity<Post>().HasOne(p => p.PostType).WithMany(pt => pt.Posts).HasForeignKey(p => p.PostTypeId);
            modelBuilder.Entity<Post>().HasMany(p => p.Images).WithOne(p => p.Post).HasForeignKey(p => p.PostId);
            modelBuilder.Entity<PercentageData>().HasOne(p => p.DataType).WithMany(p => p.PercentagesData).HasForeignKey(p => p.DataTypeId);
            modelBuilder.Entity<Paragraph>().HasOne(p => p.Post).WithMany(pt => pt.Paragraphs).HasForeignKey(p => p.PostId);
            modelBuilder.Entity<PercentageData>().HasOne(pd => pd.Content).WithMany(c => c.PercentagesData).HasForeignKey(pd => pd.ContentId);
            
            
            modelBuilder.ApplySnakeCaseNamingConvention();
        }
    }
}
