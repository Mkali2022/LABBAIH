using Labbeh.Models;
using Microsoft.EntityFrameworkCore;
using Labbeh.ViewModel;

namespace Labbeh.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext>option):base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<BranchSubOrgsContract> BranchSubOrgsContracts { get; set; }
        public DbSet<Commision> Commisions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractCategory> ContractCategories { get; set; }

        public DbSet<ContractCCat> ContractCCats { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerCusCat> CustomerCusCats { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }

        public DbSet<DriverCompany> driverCompanies { get; set; }
        public DbSet<DriverCompContract> DriverCompContracts { get; set; }
        public DbSet<DriverContractEvaluate> DriverContractEvaluates { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<DriversCompaniesCat> DriversCompaniesCats { get; set; }
        public DbSet<DriversContract> DriversContracts { get; set; }
        public DbSet<DriverTracking> DriverTrackings { get; set; }
        public DbSet<DriverTrackingOrder> DriverTrackingOrders { get; set; }
        public DbSet<DriverVehicle> DriverVehicles { get; set; }
        public DbSet<EvaluateDrivers> EvaluateDrivers { get; set; }
        public DbSet<GeneralWalet> GeneralWalets { get; set; }
        public DbSet<ItemOrderOffer> ItemOrderOffers { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<LatLongArrived> LatLongArriveds { get; set; }
        public DbSet<MainOrgContact> MainOrgContacts { get; set; }
        public DbSet<OfferrItems> OfferrItems { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Organizations> Organizations { get; set; }
        public DbSet<OrgsSub> OrgsSubs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffType> StaffTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubCategoryOrgsSub> SubCategoryOrgsSubs { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<EvaluateAnswer> EvaluateAnswers { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Labbeh.ViewModel.CompanyCategory> CumpanyCatehoryTest { get; set; }






    }
}
