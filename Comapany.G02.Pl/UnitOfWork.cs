using Company.G02.BLL.Interfaces;
using Company.G02.BLL.Repositiories;
using Company.G02.DAL.Data.Context;

namespace Comapany.G02.Pl
{
    public class UnitOfWork : IUnitOFWork
    {
        private AppDbContext _context;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
       

        public UnitOfWork(AppDbContext context)
        {
            _departmentRepository=new DepartmentRepository(context);
            _employeeRepository = new EmployeeRepository(context);
            _context = context;
        }
        public IDepartmentRepository DepartmentRepository => _departmentRepository;

        public IEmployeeRepository EmployeeRepository => _employeeRepository;
    }
}
