using AutoMapper;
using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using LinqSharp;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class DriverCompanyRepo : IDriverCompanyRepo
    {
        private readonly DriversCompaniesCat driversCompaniesCat;
        private readonly DBContext context;
        private string _errors = "";
        public DriverCompanyRepo(DBContext context)
        {
            this.context = context;
        }


        public bool Create(DriverCompany driversCompany)
        {
            try
            {

                if (IsDriversCompanyExists(driversCompany.CompanyName)) { return false; }
                if (Test.PhoneNumber(driversCompany.Phone1)&& (Test.PhoneNumber(driversCompany.Phone2)))
                {
                    if (IsValid(driversCompany.CompanyName))
                    {
                        context.driverCompanies.Add(driversCompany);
                        context.SaveChanges();
                        return true;
                    }
                    { 
                        return false; 
                    }
                }
                {
                    _errors = "The PhoneNumber Error";
                    return false;
                }
            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }
        

        /*public bool Delete(DriverCompany driversCompany)
        {
            try
            {
                context.driverCompanies.Attach(driversCompany);
                context.Entry(driversCompany).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Delete Failed - sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }*/

        public bool Edit(DriverCompany driversCompany)
        {
            try
            {
                if (IsDriversCompanyExists(driversCompany.CompanyName)) return false;
                if (Test.PhoneNumber(driversCompany.Phone1) && (Test.PhoneNumber(driversCompany.Phone2)))
                {
                    context.driverCompanies.Attach(driversCompany);
                    context.Entry(driversCompany).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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

        public List<DriverCompany> GitAllDriverCom()
        {
            var driverCom = context.driverCompanies.ToList();
            return driverCom.ToList();
        }

        public DriverCompany GitDriverComByID(int id)
        {
            DriverCompany driverCompany = context.driverCompanies.Where(x => x.ID == id).FirstOrDefault();
            return driverCompany;
        }

        public bool IsDriversCompanyExists(string name)
        {
            int ct = context.driverCompanies.Where(x => x.CompanyName == name).Count();
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
        private bool IsValid(string driversname)
        {

            if (driversname.Length < 4 || driversname.Length == null)
            {
                _errors = "CompaniesName Must be atleast 4 Characters";
                return true;

            }
            return false;

        }
    }
}
