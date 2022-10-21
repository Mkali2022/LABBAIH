using Labbeh.Data;
using Labbeh.Models;

namespace Labbeh.Repository
{
    public class Test
    {
        /*
        private readonly DBContext context;
        private string _errors = "";
        public Test(DBContext context)
        {
            this.context = context;
        }

        public bool List<Create>(T t)
        {
            try
            {
                if (IsDriversCompaniesCatExists(driversCompaniesCat.CompaniesType)) return false;
                //if (IsValid(driversCompaniesCat)) return false;

                context.Add(t);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }
        public bool IsDriversCompaniesCatExists(string id)
        {
            int ct = context.t.Where(x => x.Id == id).Count();
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
        */
        
        public static bool IsValiddd(string name)
        {
            if (name.Length < 4 || name == null)
            {
                
                return false;

            }
            return true;

        }

    }
}
