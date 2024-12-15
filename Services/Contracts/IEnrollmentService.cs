using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface IEnrollmentService
	{
		IQueryable<Enrollment> GetAllEnrollments(bool trackChanges);
		(bool isSuccess, string message) UpdateOneEnrollmentGrade(EnrollmentDtoForGrade enrollmentDto);
		(bool isSuccess, string message) AddEnrollment(Enrollment enrollment);
	}
}