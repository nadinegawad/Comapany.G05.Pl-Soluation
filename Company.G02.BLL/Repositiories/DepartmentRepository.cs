using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Data.Context;
using Company.G02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Repositiories
{
    public class DepartmentRepository :GenericRepository<Department>, IDepartmentRepository
    {

        

        public DepartmentRepository(AppDbContext context) : base(context) { }
      


 
    }
}
