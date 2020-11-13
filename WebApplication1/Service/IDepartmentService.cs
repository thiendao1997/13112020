using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Model;

namespace WebApplication1.Service
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        Task<bool> CreateAsync(Department department);
        Task<bool> UpdateAsync(Department department);
        Task<bool> Delete(int departmentId);
        Task UpdateAsync(int id);
    }
}
