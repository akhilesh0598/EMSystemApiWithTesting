using EMSystem.Models.DB;

namespace EMSystem.Repositories
{
    public interface IDepartmentsRepository
    {
        DepartmentDTO GetById(int departmentId);
        DepartmentDTO GetByName(string departmentName);
    }
}