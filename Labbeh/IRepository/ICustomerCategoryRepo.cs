using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface ICustomerCategoryRepo
    {
        List<CustomerCategory> GitAllCustomerCat();
        public CustomerCategory GitCustomerCatByID(int id);
        bool Create(CustomerCategory customerCategory);

        //bool Delete(CustomerCategory customerCategory);
        public bool IsCustomerCatExists(string name);
        bool Edit(CustomerCategory customerCategory);
        public string GetErrors();
    }
}
