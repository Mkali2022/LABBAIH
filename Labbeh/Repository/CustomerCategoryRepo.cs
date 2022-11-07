using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class CustomerCategoryRepo : ICustomerCategoryRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public CustomerCategoryRepo(DBContext context)
        {
                this.context = context;
        }

        public bool Create(CustomerCategory customerCategory)
        {
            try
            {
                
                if (IsValid(customerCategory)) { return false; }
                context.CustomerCategories.Add(customerCategory);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public bool Edit(CustomerCategory customerCategory)
        {
            try
            {
                if (IsValid(customerCategory)) { return false; }
                context.CustomerCategories.Attach(customerCategory);
                context.Entry(customerCategory).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Update Failed - sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public string GetErrors()
        {
            return _errors;
        }

        public List<CustomerCategory> GitAllCustomerCat()
        {
            var item = context.CustomerCategories.ToList();
            return item;
        }

        public CustomerCategory GitCustomerCatByID(int id)
        {
            CustomerCategory customerCategory = context.CustomerCategories.Where(x => x.ID == id).FirstOrDefault();
            return customerCategory;
        }

        public bool IsCustomerCatExists(string name)
        {
            int ct = context.CustomerCategories.Where(x => x.CategoyName == name).Count();
            if (ct > 0)
            {
                _errors = "Name" + name + " Exists Alredy";
                return true;
            }
            else
            {
                return false;
            };
        }
        private bool IsValid(CustomerCategory customerCategory)
        {
            if (customerCategory.CategoyName.Length < 3 || customerCategory.CategoyName == null)
            {
                _errors = "CustomerCategoryName Must be atleast 4 Characters";
                return true;

            }
            return false;

        }
    }
}
