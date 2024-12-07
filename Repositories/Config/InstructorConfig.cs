using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
			builder.HasKey(i => i.InstructorId);
			builder.Property(i => i.FirstName).IsRequired().HasMaxLength(50);
			builder.Property(i => i.LastName).IsRequired().HasMaxLength(50);
			builder.Property(i => i.Email).IsRequired().HasMaxLength(50);
			builder.Property(i => i.HireDate).IsRequired();

			builder.HasData(
				new Instructor { InstructorId = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@email.com", HireDate = DateTime.Now },
                new Instructor { InstructorId = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@email.com", HireDate = DateTime.Now }
			);
        }
    }
}