using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class CustomersRepo:ICustomersRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public CustomersRepo(DBContext context)
        {
                this.context = context;
        }

        public bool Create(Customers customers)
        {
            try
            {
                if (Test.PhoneNumber(customers.PhoneNumber))
                {
                    if (IsValid(customers)) { return false; }
                    context.Customers.Add(customers);
                    context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public bool Edit(Customers customers)
        {
            try
            {
                if (Test.PhoneNumber(customers.PhoneNumber))
                {
                    if (IsValid(customers)) { return false; }
                    context.Customers.Attach(customers);
                    context.Entry(customers).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false;
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

        public List<Customers> GitAllCustomer()
        {
            var customer = context.Customers.ToList();
            return customer;
        }

        public Customers GitCustomerByID(int id)
        {
            Customers customers = context.Customers.Where(x => x.ID == id).FirstOrDefault();
            return customers;
        }

        public bool IsCustomerExists(string name)
        {
            int ct = context.Customers.Where(x => x.CustomerName == name).Count();
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
        private bool IsValid(Customers customers)
        {
            if (customers.CustomerName.Length < 3 || customers.CustomerName == null)
            {
                _errors = "CustomerName Must be atleast 4 Characters";
                return true;

            }
            return false;

        }
    }
}
