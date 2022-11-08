using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class CustomerCusCatRepo : ICustomerCusCatRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public CustomerCusCatRepo(DBContext context)
        {
            this.context = context;
        }
        public bool Create(CustomerCusCat customerCusCat)
        {
            try
            {
                context.CustomerCusCats.Add(customerCusCat);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public bool Edit(CustomerCusCat customerCusCat)
        {
            try
            {
                context.CustomerCusCats.Attach(customerCusCat);
                context.Entry(customerCusCat).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Updatej Failed - sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public string GetErrors()
        {
            return _errors;
        }

        public List<CustomerCusCat> GitAllCustomerCusCat()
        {
            var customerCusCat = context.CustomerCusCats.ToList();
            return customerCusCat;
        }

        public CustomerCusCat GitCustomerCusCatById(int id)
        {
            CustomerCusCat customerCusCat = context.CustomerCusCats.Where(x => x.ID == id).FirstOrDefault();
            return customerCusCat;
        }

       
    }
}
