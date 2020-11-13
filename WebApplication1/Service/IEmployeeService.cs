using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data.Model;
using WebApplication1.ModelViews;

namespace WebApplication1.Service
{
    public interface IEmployeeService
    {
        Task<bool> CreateAsync(EmployeeCreate newEmp);
        Employee GetById(int employeeId);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> Delete(int employeeId);
        IEnumerable<Employee> GetAll();
        Task UpdateAsync(int id);
    }
}
