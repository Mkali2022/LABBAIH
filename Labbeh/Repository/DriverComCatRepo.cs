using Dapper;
using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Labbeh.Repository
{
    public class DriverComCatRepo : IDriverComCatRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public DriverComCatRepo(DBContext context)
        {
            this.context = context;
        }
        public bool Create(DriversCompaniesCat driversCompaniesCat)
        {
            try
            {
                if (IsDriversCompaniesCatExists(driversCompaniesCat.CompaniesType)) return false;
                if (IsValid(driversCompaniesCat)) return false;


                //if (Test.IsValiddd(driversCompaniesCat.CompaniesType)) return false;
                

                context.DriversCompaniesCats.Add(driversCompaniesCat);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        

        public bool Edit(DriversCompaniesCat driversCompaniesCat)
        {
            try
            {
                if (IsDriversCompaniesCatExists(driversCompaniesCat.CompaniesType)) return false;


                context.DriversCompaniesCats.Attach(driversCompaniesCat);
                context.Entry(driversCompaniesCat).State = EntityState.Modified;
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
        
        public List<DriversCompaniesCat> GitAllDriverComCat()
        {

            var item = context.DriversCompaniesCats.ToList();
            return item.ToList();
        }

        public DriversCompaniesCat GitDriverComCatByID(int id)
        {
            DriversCompaniesCat driversCompaniesCat = context.DriversCompaniesCats.Where(x => x.ID == id).FirstOrDefault();
            return driversCompaniesCat;
        }

        public bool IsDriversCompaniesCatExists(string name)
        {
            int ct = context.DriversCompaniesCats.Where(x => x.CompaniesType == name).Count();
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
        private bool IsValid(DriversCompaniesCat driversCompaniesCat)
        {
            if(driversCompaniesCat.CompaniesType.Length < 4 || driversCompaniesCat.CompaniesType == null)
            {
                _errors = "CompaniesCategoryType Must be atleast 4 Characters";
                return false;

            }
            return true;
                
        }
        /*
        public string InserDriversCompaniesCat(DriversCompaniesCat driversCompaniesCat)
        {


            SqlCommand cmd = new SqlCommand("INSERT INTO [DriversCompaniesCat] (CompaniesType,Code) values(@CompaniesType,@Code)");
            cmd.Parameters.AddWithValue("@CompaniesType", driversCompaniesCat.CompaniesType);
            cmd.Parameters.AddWithValue("@Code", driversCompaniesCat.Code);
            cmd.ExecuteNonQuery();
            return "h";
        }
        */

    }
}
