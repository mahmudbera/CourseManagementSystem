using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);
			builder.Property(c => c.CourseName).IsRequired().HasMaxLength(50);
			builder.Property(c => c.Description).IsRequired().HasMaxLength(255);
			builder.Property(c => c.Credits).IsRequired();
			builder.Property(c => c.InstructorId).IsRequired();
			builder.Property(c => c.Status).IsRequired().HasMaxLength(20).HasDefaultValue("Deactive");

			builder.HasOne(c => c.Instructor)
				.WithMany(i => i.Courses)
				.HasForeignKey(c => c.InstructorId);

			builder.HasData(
				new Course { CourseId = 1, CourseName = "Math 101", Description = "Basic Mathematics", Credits = 3, InstructorId = 1, Status = "Active" },
				new Course { CourseId = 2, CourseName = "History 101", Description = "Basic History", Credits = 3, InstructorId = 2, Status = "Active" }
			);
        }
    }
}