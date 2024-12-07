using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ClassroomConfig : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
			builder.HasKey(c => c.ClassroomId);
			builder.Property(c => c.ClassroomName).IsRequired().HasMaxLength(50);
			builder.Property(c => c.Capacity).IsRequired();
			
			builder.HasOne(c => c.Course)
			.WithOne(c => c.Classroom)
			.HasForeignKey<Classroom>(c => c.CourseId);

			builder.HasData(
				new Classroom {	ClassroomId = 1, ClassroomName = "Room A", Capacity = 30, CourseId = 1 },
                new Classroom { ClassroomId = 2, ClassroomName = "Room B", Capacity = 25, CourseId = 2 }
			);
        }
    }
}