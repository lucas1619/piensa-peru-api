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
                        Id = 1,
                        Name = "Percentage"
                    },

                    new DataType
                    {
                        Id = 2,
                        Name = "Number"
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
                        Id = 1,
                        Url = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60",
                        Title = "Image 1",
                        PostId = 1
                    },

                    new Image
                    {
                        Id = 2,
                        Url = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60",
                        Title = "Image 2",
                        PostId = 1
                    },

                    new Image
                    {
                        Id = 3,
                        Url = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60",
                        Title = "Image 3",
                        PostId = 1
                    },

                    new Image
                    {
                        Id = 4,
                        Url = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60",
                        Title = "Image 4",
                        PostId = 1
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
                        Id = 1,
                        Title = "Paragraph 1",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PostId = 1
                    },

                    new Paragraph
                    {
                        Id = 2,
                        Title = "Paragraph 2",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PostId = 1
                    },

                    new Paragraph
                    {
                        Id = 3,
                        Title = "Paragraph 3",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        PostId = 1
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

            // PercentageData Seed Data

            modelBuilder.Entity<PercentageData>().HasData
                (
                    new PercentageData
                    {
                        Id = 1,
                        Number = 20,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 1
                    },

                    new PercentageData
                    {
                        Id = 2,
                        Number = 20,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 1
                    },

                    new PercentageData
                    {
                        Id = 3,
                        Number = 30,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        ContentId = 1
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
                        Id = 1,
                        Name = "Post Type 1"
                    },

                    new PostType
                    {
                        Id = 2,
                        Name = "Post Type 2"
                    },

                    new PostType
                    {
                        Id = 3,
                        Name = "Post Type 3"
                    }
                );

            // Content Entity

            modelBuilder.Entity<Content>().ToTable("Contents");

            // Constraints

            modelBuilder.Entity<Content>().HasKey(c => c.Id);
            modelBuilder.Entity<Content>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Content>().Property(c => c.Active).IsRequired();

            // Content Seed Data

            modelBuilder.Entity<Content>().HasData
                (
                    new Content
                    {
                        Id = 1,
                        Active = true
                    },

                    new Content
                    {
                        Id = 2,
                        Active = true
                    },

                    new Content
                    {
                        Id = 3,
                        Active = true
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
