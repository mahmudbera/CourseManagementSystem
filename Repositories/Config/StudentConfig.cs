using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);
			builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
			builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
			builder.Property(s => s.Email).IsRequired().HasMaxLength(50);
			builder.Property(s => s.DateOfBirth).IsRequired();
			builder.Property(s => s.EnrollmentDate).IsRequired();
        
			builder.HasData(
				new Student { StudentId = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@email.com", DateOfBirth = DateTime.Parse("2000-01-01"), EnrollmentDate = DateTime.Now },
                new Student { StudentId = 2, FirstName = "Bob", LastName = "Brown", Email = "bob@email.com", DateOfBirth = DateTime.Parse("2000-02-01"), EnrollmentDate = DateTime.Now }
			);
		}
    }
}