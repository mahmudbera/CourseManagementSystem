using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface IEnrollmentService
	{
		IQueryable<Enrollment> GetAllEnrollments(bool trackChanges);
		void AddEnrollment(Enrollment enrollment);
		void UpdateOneEnrollmentGrade(EnrollmentDtoForGrade enrollmentDto);
	}
}