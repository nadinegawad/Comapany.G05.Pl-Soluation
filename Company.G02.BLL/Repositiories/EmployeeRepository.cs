using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Data.Context;
using Company.G02.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Repositiories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        
        public EmployeeRepository(AppDbContext context) :base(context) { }

    public IQueryable<Employee> GetEmployeeByName(string searchName)
    {
           return _context.Employees.Where(E => E.Name.ToLower().Contains(searchName.ToLower())).Include(E => E.Departments);
    }
}
}
