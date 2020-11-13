using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Data.Model;

namespace WebApplication1.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _dbcontext;
        public DepartmentService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> CreateAsync(Department department)
        {
            _dbcontext.Departments.Add(department);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int departmentId)
        {
            var dep = _dbcontext.Departments.Where(x => x.DepartmentId == departmentId).FirstOrDefault();
            _dbcontext.Departments.Remove(dep);
           await _dbcontext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbcontext.Departments;
        }

        public Department GetById(int id)
        {
            return _dbcontext.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Department department)
        {
            _dbcontext.Departments.Update(department);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAsync(int id)
        {
            var dep=GetById(id);
            _dbcontext.Departments.Update(dep);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
