using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface ICustomersRepo
    {
        List<Customers> GitAllCustomer();
        public Customers GitCustomerByID(int id);
        bool Create(Customers customers);

        //bool Delete(Customers customers);
        public bool IsCustomerExists(string name);
        bool Edit(Customers customers);
        public string GetErrors();
    }
}
