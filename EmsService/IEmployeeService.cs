using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsService
{
    public interface IEmployeeService : IService<Employee>
    {
        Employee Get(string id);
        Employee Get(Employee emp);
        int InsertEmp(Employee emp);

        int UpdateEmp(Employee emp);
        int Delete(int id);
    }
}
