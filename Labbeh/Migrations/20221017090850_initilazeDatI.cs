using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labbeh.Migrations
{
    public partial class initilazeDatI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LabbehDB");

            migrationBuilder.CreateTable(
                name: "ContractCategorie",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConractCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCategorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Custome",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatitudeDefault = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongtitudeDefault = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custome", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomersCategory",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DriverCompaniesCat",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CompaniesType = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverCompaniesCat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvaluateDriver",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Questions = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluateDriver", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organizatio",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizeCode = table.Column<int>(type: "int", nullable: false),
                    OrganizeName = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizatio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    PaymentWay = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StaffsType",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffsType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomersCusCat",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CustomerCatID = table.Column<int>(type: "int", nullable: false),
                    CurrentDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersCusCat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomersCusCat_Custome_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "LabbehDB",
                        principalTable: "Custome",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersCusCat_CustomersCategory_CustomerCatID",
                        column: x => x.CustomerCatID,
                        principalSchema: "LabbehDB",
                        principalTable: "CustomersCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriversCompany",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverCompCatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversCompany", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DriversCompany_DriverCompaniesCat_DriverCompCatID",
                        column: x => x.DriverCompCatID,
                        principalSchema: "LabbehDB",
                        principalTable: "DriverCompaniesCat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answers_EvaluateDriver_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "LabbehDB",
                        principalTable: "EvaluateDriver",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrgSub",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgsSubCode = table.Column<int>(type: "int", nullable: false),
                    OrgsSubName = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Latitiude = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Logtitude = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    OrganizationRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgSub", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrgSub_Organizatio_OrganizationRef",
                        column: x => x.OrganizationRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Organizatio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryes",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: true),
                    SubCatName = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    OrganizationRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategoryes_Organizatio_OrganizationRef",
                        column: x => x.OrganizationRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Organizatio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    StaffTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staffs_StaffsType_StaffTypeID",
                        column: x => x.StaffTypeID,
                        principalSchema: "LabbehDB",
                        principalTable: "StaffsType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverCode = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DriverPhone = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    LatitudeDefault = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    LongtitudeDefault = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DriverEmail = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DriverTTypeId = table.Column<int>(type: "int", nullable: false),
                    DriverCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Driver_DriverCompaniesCat_DriverTTypeId",
                        column: x => x.DriverTTypeId,
                        principalSchema: "LabbehDB",
                        principalTable: "DriverCompaniesCat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Driver_DriversCompany_DriverCompanyId",
                        column: x => x.DriverCompanyId,
                        principalSchema: "LabbehDB",
                        principalTable: "DriversCompany",
                        principalColumn: "ID");
                        //principalColumn: "ID",
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriversCompContract",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    OrganizationAddress = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DateFrom = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DateTo = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DriverCompID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversCompContract", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DriversCompContract_DriversCompany_DriverCompID",
                        column: x => x.DriverCompID,
                        principalSchema: "LabbehDB",
                        principalTable: "DriversCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branche",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longtitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgsSubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branche", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branche_OrgSub_OrgsSubID",
                        column: x => x.OrgsSubID,
                        principalSchema: "LabbehDB",
                        principalTable: "OrgSub",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    OrgsSubIdRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contracts_OrgSub_OrgsSubIdRef",
                        column: x => x.OrgsSubIdRef,
                        principalSchema: "LabbehDB",
                        principalTable: "OrgSub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryesOrgsSub",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgSubIDRef = table.Column<int>(type: "int", nullable: false),
                    SubCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryesOrgsSub", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategoryesOrgsSub_OrgSub_OrgSubIDRef",
                        column: x => x.OrgSubIDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "OrgSub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryesOrgsSub_SubCategoryes_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalSchema: "LabbehDB",
                        principalTable: "SubCategoryes",
                        principalColumn: "ID");
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverContract",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    ContractDetaill = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DateFrom = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DateTo = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverContract", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DriverContract_Driver_DriverId",
                        column: x => x.DriverId,
                        principalSchema: "LabbehDB",
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriversTracking",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverCode = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Longtitude = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CurentDTime = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CurrentHour = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DriverID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversTracking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DriversTracking_Driver_DriverID",
                        column: x => x.DriverID,
                        principalSchema: "LabbehDB",
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriversVehicle",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    UsingDate = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversVehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DriversVehicle_Driver_DriverID",
                        column: x => x.DriverID,
                        principalSchema: "LabbehDB",
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversVehicle_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalSchema: "LabbehDB",
                        principalTable: "Vehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralWalets",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FlagID = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    BalanceValue = table.Column<decimal>(type: "decimal(13,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralWalets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GeneralWalets_Driver_UserID",
                        column: x => x.UserID,
                        principalSchema: "LabbehDB",
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralWalets_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "LabbehDB",
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemsCode = table.Column<int>(type: "int", nullable: false),
                    ItemsName = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ItemCost = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    OrgsSubRef = table.Column<int>(type: "int", nullable: false),
                    BranchesIDRef = table.Column<int>(type: "int", nullable: false),
                    FlagType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_Branche_BranchesIDRef",
                        column: x => x.BranchesIDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Branche",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_OrgSub_OrgsSubRef",
                        column: x => x.OrgsSubRef,
                        principalSchema: "LabbehDB",
                        principalTable: "OrgSub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainOrgContacts",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    BranchesContact = table.Column<int>(type: "int", nullable: false),
                    OrgsSubbIDRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainOrgContacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MainOrgContacts_Branche_BranchesContact",
                        column: x => x.BranchesContact,
                        principalSchema: "LabbehDB",
                        principalTable: "Branche",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainOrgContacts_OrgSub_OrgsSubbIDRef",
                        column: x => x.OrgsSubbIDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "OrgSub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OffersCode = table.Column<int>(type: "int", nullable: false),
                    OffersDetails = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    OffersPrice = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    BranchesIDRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offer_Branche_BranchesIDRef",
                        column: x => x.BranchesIDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Branche",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CurrentDate = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Branche_BranchID",
                        column: x => x.BranchID,
                        principalSchema: "LabbehDB",
                        principalTable: "Branche",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Custome_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "LabbehDB",
                        principalTable: "Custome",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchsSubOrgsContract",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OrgsSubID = table.Column<int>(type: "int", nullable: false),
                    ContractID = table.Column<int>(type: "int", nullable: false),
                    GenerationFees = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchsSubOrgsContract", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BranchsSubOrgsContract_Branche_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "LabbehDB",
                        principalTable: "Branche",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchsSubOrgsContract_Contracts_ContractID",
                        column: x => x.ContractID,
                        principalSchema: "LabbehDB",
                        principalTable: "Contracts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchsSubOrgsContract_OrgSub_OrgsSubID",
                        column: x => x.OrgsSubID,
                        principalSchema: "LabbehDB",
                        principalTable: "OrgSub",
                        principalColumn: "ID");
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commisions",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    PaymentWayID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    Commisionamount = table.Column<decimal>(type: "decimal(13,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commisions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Commisions_Contracts_ContactID",
                        column: x => x.ContactID,
                        principalSchema: "LabbehDB",
                        principalTable: "Contracts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commisions_Payments_PaymentWayID",
                        column: x => x.PaymentWayID,
                        principalSchema: "LabbehDB",
                        principalTable: "Payments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractsCCat",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractID = table.Column<int>(type: "int", nullable: false),
                    ContactCatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsCCat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractsCCat_ContractCategorie_ContactCatID",
                        column: x => x.ContactCatID,
                        principalSchema: "LabbehDB",
                        principalTable: "ContractCategorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractsCCat_Contracts_ContractID",
                        column: x => x.ContractID,
                        principalSchema: "LabbehDB",
                        principalTable: "Contracts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriversContractEvaluate",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    DriveContractID = table.Column<int>(type: "int", nullable: false),
                    QEvaluateID = table.Column<int>(type: "int", nullable: false),
                    CurrentDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversContractEvaluate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DriversContractEvaluate_DriverContract_DriveContractID",
                        column: x => x.DriveContractID,
                        principalSchema: "LabbehDB",
                        principalTable: "DriverContract",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversContractEvaluate_EvaluateDriver_QEvaluateID",
                        column: x => x.QEvaluateID,
                        principalSchema: "LabbehDB",
                        principalTable: "EvaluateDriver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluateAnswers",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ECode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    AnsID = table.Column<int>(type: "int", nullable: true),
                    DriverContractId = table.Column<int>(type: "int", nullable: true),
                    CurrentDate = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluateAnswers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvaluateAnswers_Answers_AnsID",
                        column: x => x.AnsID,
                        principalSchema: "LabbehDB",
                        principalTable: "Answers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EvaluateAnswers_DriverContract_DriverContractId",
                        column: x => x.DriverContractId,
                        principalSchema: "LabbehDB",
                        principalTable: "DriverContract",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EvaluateAnswers_EvaluateDriver_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "LabbehDB",
                        principalTable: "EvaluateDriver",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "stochs",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockCode = table.Column<int>(type: "int", nullable: false),
                    StockDetails = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IDRef = table.Column<int>(type: "int", nullable: false),
                    FlagVal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stochs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_stochs_Item_IDRef",
                        column: x => x.IDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferrsItems",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemIDef = table.Column<int>(type: "int", nullable: false),
                    OfferIDRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferrsItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OfferrsItems_Item_ItemIDef",
                        column: x => x.ItemIDef,
                        principalSchema: "LabbehDB",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferrsItems_Offer_OfferIDRef",
                        column: x => x.OfferIDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Offer",
                        principalColumn: "ID");
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriversTrackingOrder",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Longtitude = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DriverTrackingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversTrackingOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DriversTrackingOrder_DriversTracking_DriverTrackingId",
                        column: x => x.DriverTrackingId,
                        principalSchema: "LabbehDB",
                        principalTable: "DriversTracking",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversTrackingOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "LabbehDB",
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsOrderOffer",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemIDRef = table.Column<int>(type: "int", nullable: false),
                    OfferIDRef = table.Column<int>(type: "int", nullable: false),
                    OrderIDRef = table.Column<int>(type: "int", nullable: false),
                    FlagOfferItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsOrderOffer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemsOrderOffer_Item_ItemIDRef",
                        column: x => x.ItemIDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsOrderOffer_Offer_OfferIDRef",
                        column: x => x.OfferIDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Offer",
                        principalColumn: "ID");
                    // onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsOrderOffer_Orders_OrderIDRef",
                        column: x => x.OrderIDRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Orders",
                        principalColumn: "ID");
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LatLongArrived",
                schema: "LabbehDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    LongTitude = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    OrderRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatLongArrived", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LatLongArrived_Orders_OrderRef",
                        column: x => x.OrderRef,
                        principalSchema: "LabbehDB",
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                schema: "LabbehDB",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Branche_OrgsSubID",
                schema: "LabbehDB",
                table: "Branche",
                column: "OrgsSubID");

            migrationBuilder.CreateIndex(
                name: "IX_BranchsSubOrgsContract_BranchId",
                schema: "LabbehDB",
                table: "BranchsSubOrgsContract",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchsSubOrgsContract_ContractID",
                schema: "LabbehDB",
                table: "BranchsSubOrgsContract",
                column: "ContractID");

            migrationBuilder.CreateIndex(
                name: "IX_BranchsSubOrgsContract_OrgsSubID",
                schema: "LabbehDB",
                table: "BranchsSubOrgsContract",
                column: "OrgsSubID");

            migrationBuilder.CreateIndex(
                name: "IX_Commisions_ContactID",
                schema: "LabbehDB",
                table: "Commisions",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Commisions_PaymentWayID",
                schema: "LabbehDB",
                table: "Commisions",
                column: "PaymentWayID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_OrgsSubIdRef",
                schema: "LabbehDB",
                table: "Contracts",
                column: "OrgsSubIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsCCat_ContactCatID",
                schema: "LabbehDB",
                table: "ContractsCCat",
                column: "ContactCatID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsCCat_ContractID",
                schema: "LabbehDB",
                table: "ContractsCCat",
                column: "ContractID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersCusCat_CustomerCatID",
                schema: "LabbehDB",
                table: "CustomersCusCat",
                column: "CustomerCatID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersCusCat_CustomerID",
                schema: "LabbehDB",
                table: "CustomersCusCat",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_DriverCompanyId",
                schema: "LabbehDB",
                table: "Driver",
                column: "DriverCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_DriverTTypeId",
                schema: "LabbehDB",
                table: "Driver",
                column: "DriverTTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverContract_DriverId",
                schema: "LabbehDB",
                table: "DriverContract",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversCompany_DriverCompCatID",
                schema: "LabbehDB",
                table: "DriversCompany",
                column: "DriverCompCatID");

            migrationBuilder.CreateIndex(
                name: "IX_DriversCompContract_DriverCompID",
                schema: "LabbehDB",
                table: "DriversCompContract",
                column: "DriverCompID");

            migrationBuilder.CreateIndex(
                name: "IX_DriversContractEvaluate_DriveContractID",
                schema: "LabbehDB",
                table: "DriversContractEvaluate",
                column: "DriveContractID");

            migrationBuilder.CreateIndex(
                name: "IX_DriversContractEvaluate_QEvaluateID",
                schema: "LabbehDB",
                table: "DriversContractEvaluate",
                column: "QEvaluateID");

            migrationBuilder.CreateIndex(
                name: "IX_DriversTracking_DriverID",
                schema: "LabbehDB",
                table: "DriversTracking",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_DriversTrackingOrder_DriverTrackingId",
                schema: "LabbehDB",
                table: "DriversTrackingOrder",
                column: "DriverTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversTrackingOrder_OrderId",
                schema: "LabbehDB",
                table: "DriversTrackingOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversVehicle_DriverID",
                schema: "LabbehDB",
                table: "DriversVehicle",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_DriversVehicle_VehicleID",
                schema: "LabbehDB",
                table: "DriversVehicle",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateAnswers_AnsID",
                schema: "LabbehDB",
                table: "EvaluateAnswers",
                column: "AnsID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateAnswers_DriverContractId",
                schema: "LabbehDB",
                table: "EvaluateAnswers",
                column: "DriverContractId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateAnswers_QuestionId",
                schema: "LabbehDB",
                table: "EvaluateAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralWalets_StaffId",
                schema: "LabbehDB",
                table: "GeneralWalets",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralWalets_UserID",
                schema: "LabbehDB",
                table: "GeneralWalets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BranchesIDRef",
                schema: "LabbehDB",
                table: "Item",
                column: "BranchesIDRef");

            migrationBuilder.CreateIndex(
                name: "IX_Item_OrgsSubRef",
                schema: "LabbehDB",
                table: "Item",
                column: "OrgsSubRef");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsOrderOffer_ItemIDRef",
                schema: "LabbehDB",
                table: "ItemsOrderOffer",
                column: "ItemIDRef");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsOrderOffer_OfferIDRef",
                schema: "LabbehDB",
                table: "ItemsOrderOffer",
                column: "OfferIDRef");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsOrderOffer_OrderIDRef",
                schema: "LabbehDB",
                table: "ItemsOrderOffer",
                column: "OrderIDRef");

            migrationBuilder.CreateIndex(
                name: "IX_LatLongArrived_OrderRef",
                schema: "LabbehDB",
                table: "LatLongArrived",
                column: "OrderRef");

            migrationBuilder.CreateIndex(
                name: "IX_MainOrgContacts_BranchesContact",
                schema: "LabbehDB",
                table: "MainOrgContacts",
                column: "BranchesContact");

            migrationBuilder.CreateIndex(
                name: "IX_MainOrgContacts_OrgsSubbIDRef",
                schema: "LabbehDB",
                table: "MainOrgContacts",
                column: "OrgsSubbIDRef");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_BranchesIDRef",
                schema: "LabbehDB",
                table: "Offer",
                column: "BranchesIDRef");

            migrationBuilder.CreateIndex(
                name: "IX_OfferrsItems_ItemIDef",
                schema: "LabbehDB",
                table: "OfferrsItems",
                column: "ItemIDef");

            migrationBuilder.CreateIndex(
                name: "IX_OfferrsItems_OfferIDRef",
                schema: "LabbehDB",
                table: "OfferrsItems",
                column: "OfferIDRef");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BranchID",
                schema: "LabbehDB",
                table: "Orders",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                schema: "LabbehDB",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrgSub_OrganizationRef",
                schema: "LabbehDB",
                table: "OrgSub",
                column: "OrganizationRef");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffTypeID",
                schema: "LabbehDB",
                table: "Staffs",
                column: "StaffTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_stochs_IDRef",
                schema: "LabbehDB",
                table: "stochs",
                column: "IDRef");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryes_OrganizationRef",
                schema: "LabbehDB",
                table: "SubCategoryes",
                column: "OrganizationRef");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryesOrgsSub_OrgSubIDRef",
                schema: "LabbehDB",
                table: "SubCategoryesOrgsSub",
                column: "OrgSubIDRef");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryesOrgsSub_SubCategoryID",
                schema: "LabbehDB",
                table: "SubCategoryesOrgsSub",
                column: "SubCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchsSubOrgsContract",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Commisions",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "ContractsCCat",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "CustomersCusCat",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "DriversCompContract",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "DriversContractEvaluate",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "DriversTrackingOrder",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "DriversVehicle",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "EvaluateAnswers",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "GeneralWalets",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "ItemsOrderOffer",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "LatLongArrived",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "MainOrgContacts",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "OfferrsItems",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "stochs",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "SubCategoryesOrgsSub",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "ContractCategorie",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Contracts",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "CustomersCategory",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "DriversTracking",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Vehicle",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Answers",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "DriverContract",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Staffs",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Offer",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "SubCategoryes",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "EvaluateDriver",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Driver",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "StaffsType",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Custome",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Branche",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "DriversCompany",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "OrgSub",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "DriverCompaniesCat",
                schema: "LabbehDB");

            migrationBuilder.DropTable(
                name: "Organizatio",
                schema: "LabbehDB");
        }
    }
}
