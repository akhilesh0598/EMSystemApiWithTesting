using EMSystem.Models.Responses;

namespace EMSystem.Services
{
    public interface IDepartmentsService
    {
        DepartmentResponse GetById(int departmentId);
        DepartmentResponse GetByName(string departmentName);
    }
}