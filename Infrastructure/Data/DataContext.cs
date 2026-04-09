using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<EmailVerification> EmailVerifications { get; set; }

        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);
                    
                entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

                entity.HasIndex(u => u.Email)
                .IsUnique();

                entity.Property(u => u.Password)
                .IsRequired();

                entity.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(u => u.Role)
                .HasDefaultValue(Role.User);


                entity.Property(u => u.ProfilePhoto)
                .HasMaxLength(500);

                entity.Property(u => u.Dob);

                entity.Property(u => u.Instagram)
                .HasMaxLength(200);

                entity.Property(u => u.YouTube)
                .HasMaxLength(200);

                entity.Property(u => u.EmailVerified)
                .HasDefaultValue(false);

                entity.Property(u => u.IsDeleted)
                .HasDefaultValue(false);

                entity.Property(u => u.IsActive)
              .HasDefaultValue(true);

                entity.Property(u => u.PasswordOtp)
      .HasMaxLength(10);

                entity.Property(u => u.EmailOtp)
                    .HasMaxLength(10);

                entity.Property(u => u.CreatedDate)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(u => u.UpdatedDate)
                    .HasDefaultValueSql("GETUTCDATE()");

 });

            modelBuilder.Entity<Movie>(entity =>    
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);   

                entity.Property(m => m.Title)
               .IsRequired()
               .HasMaxLength(200)
               .HasDefaultValue("Untitled");

                entity.Property(m => m.Poster)
                .IsRequired()
                .HasMaxLength(500);

                entity.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(2000);

                entity.Property(m => m.ReleaseYear)
                .IsRequired();

                entity.Property(m => m.Type)
                .IsRequired();

                entity.Property(m => m.Category)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(m => m.Genre)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(m => m.IsDeleted)
              .HasDefaultValue(false);

                entity.Property(m => m.CreatedDate)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(m => m.UpdatedDate)
                    .HasDefaultValueSql("GETUTCDATE()");

                // Relation with Reviews
                entity.HasMany(m => m.Reviews)
                    .WithOne(r => r.Movie)
                    .HasForeignKey(r => r.MovieId)
                    .OnDelete(DeleteBehavior.Cascade);


            });
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Comment)
                .IsRequired()
                .HasMaxLength(1000);

                entity.Property(r=>r.Rating)
                .IsRequired();

                entity.Property(r=>r.Type)
                 .IsRequired();

                entity.HasOne(r=>r.User)
                .WithMany(r =>r.Reviews)
                .HasForeignKey(r=>r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r=>r.Movie)
                .WithMany(r=>r.Reviews)
                .HasForeignKey(r=>r.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

});

            modelBuilder.Entity<EmailVerification>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e=>e.Email)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(e => e.Token)
                .IsRequired();

                entity.Property(e=>e.ExpiresDate)
                .IsRequired();

                entity.Property(e=> e.Vereified)
                .HasDefaultValue(false);
      });

            modelBuilder.Entity<PasswordResetToken>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(p => p.Token)
                .IsRequired();

                entity.Property (p => p.ExpiresDate)
                .IsRequired();
                    
                entity.Property(p => p.Used)
                .HasDefaultValue(false);

            });


        }


    }
}
