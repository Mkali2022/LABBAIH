using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface ICustomerCusCatRepo
    {
        List<CustomerCusCat> GitAllCustomerCusCat();
        public CustomerCusCat GitCustomerCusCatById(int id);
        bool Create(CustomerCusCat customerCusCat);
        bool Edit(CustomerCusCat customerCusCat);
        public string GetErrors();
    }
}
