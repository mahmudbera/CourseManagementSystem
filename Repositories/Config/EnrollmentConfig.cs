using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
	public class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
	{
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.EnrollmentId);
			builder.Property(e => e.StudentId).IsRequired();
			builder.Property(e => e.CourseId).IsRequired();
			builder.Property(e => e.Grade).IsRequired(false);
			builder.Property(e => e.EnrollmentDate).IsRequired();

			builder.HasOne(e => e.Student)
				.WithMany(s => s.Enrollments)
				.HasForeignKey(e => e.StudentId);

			builder.HasOne(e => e.Course)
				.WithMany(c => c.Enrollments)
				.HasForeignKey(e => e.CourseId);

			builder.HasData(
				new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.Now },
                new Enrollment { EnrollmentId = 2, StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.Now }
            );
        }
    }
}