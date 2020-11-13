using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Data.Model;
using WebApplication1.ModelViews;

namespace WebApplication1.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbcontext;
        public EmployeeService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> CreateAsync(EmployeeCreate newEmp)
        {
            var employee = new Employee
            {
                FullName = newEmp.FullName,
                DOB=newEmp.DOB,
                Address=newEmp.Address,
                Gender=newEmp.Gender
            };
            await _dbcontext.Employees.AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int employeeId)
        {
            var emp = GetById(employeeId);
            _dbcontext.Employees.Remove(emp);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbcontext.Employees;
        }

        public Employee GetById(int employeeId)
        {
           return  _dbcontext.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            _dbcontext.Employees.Update(employee);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAsync(int id)
        {
            var emp = GetById(id);
            _dbcontext.Employees.Update(emp);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
