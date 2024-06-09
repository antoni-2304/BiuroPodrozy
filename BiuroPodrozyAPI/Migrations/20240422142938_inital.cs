using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiuroPodrozyAPI.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountInformation",
                columns: table => new
                {
                    IdAccountInformation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EncodedPassword = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PasswordValidityTime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInformation", x => x.IdAccountInformation);
                });

            migrationBuilder.CreateTable(
                name: "CardType",
                columns: table => new
                {
                    IdCardType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardTypeName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CardTypeDescription = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardType", x => x.IdCardType);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    IdCurrency = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    AbbrCurrency = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.IdCurrency);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    IdLanguage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AbbrLanguageName = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.IdLanguage);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    IdPage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTitle = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PageIndexRelativeURL = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AccessLevel = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IncludeInNavbar = table.Column<bool>(type: "bit", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.IdPage);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.IdServiceType);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    IdSite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.IdSite);
                });

            migrationBuilder.CreateTable(
                name: "TripPhoto",
                columns: table => new
                {
                    IdTripPhoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPhoto", x => x.IdTripPhoto);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IdServiceType = table.Column<int>(type: "int", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ServiceChargingType = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "money", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.IdService);
                    table.ForeignKey(
                        name: "FK_Service_ServiceType_IdServiceType",
                        column: x => x.IdServiceType,
                        principalTable: "ServiceType",
                        principalColumn: "IdServiceType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HomeNr = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ApartmentNr = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(8,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.IdAddress);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    IdAccountInformation = table.Column<int>(type: "int", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Client_AccountInformation_IdAccountInformation",
                        column: x => x.IdAccountInformation,
                        principalTable: "AccountInformation",
                        principalColumn: "IdAccountInformation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    IdAccountInformation = table.Column<int>(type: "int", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employee_AccountInformation_IdAccountInformation",
                        column: x => x.IdAccountInformation,
                        principalTable: "AccountInformation",
                        principalColumn: "IdAccountInformation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    IdHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HotelStars = table.Column<int>(type: "int", nullable: false),
                    HotelRating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    HotelPricePerUnit = table.Column<decimal>(type: "money", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.IdHotel);
                    table.ForeignKey(
                        name: "FK_Hotel_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    IdCard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardTitle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CardDescription = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ThumbnailURL = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCardType = table.Column<int>(type: "int", nullable: false),
                    IdAuthor = table.Column<int>(type: "int", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK_Card_CardType_IdCardType",
                        column: x => x.IdCardType,
                        principalTable: "CardType",
                        principalColumn: "IdCardType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_Employee_IdAuthor",
                        column: x => x.IdAuthor,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelPhoto",
                columns: table => new
                {
                    IdHotelPhoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPhoto", x => x.IdHotelPhoto);
                    table.ForeignKey(
                        name: "FK_HotelPhoto_Hotel_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hotel",
                        principalColumn: "IdHotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    IdCity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.IdCity);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AbbrCountryName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    CountrySize = table.Column<double>(type: "float", nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    IdCurrency = table.Column<int>(type: "int", nullable: false),
                    IdLanguage = table.Column<int>(type: "int", nullable: false),
                    IdCapitalCity = table.Column<int>(type: "int", nullable: true),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.IdCountry);
                    table.ForeignKey(
                        name: "FK_Country_City_IdCapitalCity",
                        column: x => x.IdCapitalCity,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Currency_IdCurrency",
                        column: x => x.IdCurrency,
                        principalTable: "Currency",
                        principalColumn: "IdCurrency",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Country_Language_IdLanguage",
                        column: x => x.IdLanguage,
                        principalTable: "Language",
                        principalColumn: "IdLanguage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    IdFlight = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IdDepartureCity = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdArrivalCity = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    FlightStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightPricePerUnit = table.Column<decimal>(type: "money", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.IdFlight);
                    table.ForeignKey(
                        name: "FK_Flight_City_IdArrivalCity",
                        column: x => x.IdArrivalCity,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_City_IdDepartureCity",
                        column: x => x.IdDepartureCity,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    IdTrip = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripCode = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    TripCostPerAdult = table.Column<decimal>(type: "money", nullable: false),
                    TripCostPerChild = table.Column<decimal>(type: "money", nullable: false),
                    IdDestinationCity = table.Column<int>(type: "int", nullable: false),
                    DestinationCityIdCity = table.Column<int>(type: "int", nullable: true),
                    TripType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TripDescription = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.IdTrip);
                    table.ForeignKey(
                        name: "FK_Trip_City_DestinationCityIdCity",
                        column: x => x.DestinationCityIdCity,
                        principalTable: "City",
                        principalColumn: "IdCity");
                });

            migrationBuilder.CreateTable(
                name: "CountryPhoto",
                columns: table => new
                {
                    IdCountryPhoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryPhoto", x => x.IdCountryPhoto);
                    table.ForeignKey(
                        name: "FK_CountryPhoto_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationCode = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    ReservationType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AttendeeCount = table.Column<int>(type: "int", nullable: false),
                    IdDepartureFlight = table.Column<int>(type: "int", nullable: false),
                    IdArrivalFlight = table.Column<int>(type: "int", nullable: false),
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "money", nullable: false),
                    IdTrip = table.Column<int>(type: "int", nullable: false),
                    CityIdCity = table.Column<int>(type: "int", nullable: true),
                    WhoCreateId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModificationId = table.Column<int>(type: "int", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    AuditDescription = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservation_City_CityIdCity",
                        column: x => x.CityIdCity,
                        principalTable: "City",
                        principalColumn: "IdCity");
                    table.ForeignKey(
                        name: "FK_Reservation_Flight_IdArrivalFlight",
                        column: x => x.IdArrivalFlight,
                        principalTable: "Flight",
                        principalColumn: "IdFlight",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Flight_IdDepartureFlight",
                        column: x => x.IdDepartureFlight,
                        principalTable: "Flight",
                        principalColumn: "IdFlight",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Hotel_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hotel",
                        principalColumn: "IdHotel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Trip_IdTrip",
                        column: x => x.IdTrip,
                        principalTable: "Trip",
                        principalColumn: "IdTrip",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip_TripPhoto",
                columns: table => new
                {
                    IdTrip_TripPhoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTrip = table.Column<int>(type: "int", nullable: false),
                    TripIdTrip = table.Column<int>(type: "int", nullable: false),
                    IdTripPhoto = table.Column<int>(type: "int", nullable: false),
                    TripPhotoIdTripPhoto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip_TripPhoto", x => x.IdTrip_TripPhoto);
                    table.ForeignKey(
                        name: "FK_Trip_TripPhoto_TripPhoto_TripPhotoIdTripPhoto",
                        column: x => x.TripPhotoIdTripPhoto,
                        principalTable: "TripPhoto",
                        principalColumn: "IdTripPhoto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_TripPhoto_Trip_TripIdTrip",
                        column: x => x.TripIdTrip,
                        principalTable: "Trip",
                        principalColumn: "IdTrip",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation_Service",
                columns: table => new
                {
                    IdReservation_Service = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReservation = table.Column<int>(type: "int", nullable: false),
                    ReservationIdReservation = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false),
                    ServiceIdService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation_Service", x => x.IdReservation_Service);
                    table.ForeignKey(
                        name: "FK_Reservation_Service_Reservation_ReservationIdReservation",
                        column: x => x.ReservationIdReservation,
                        principalTable: "Reservation",
                        principalColumn: "IdReservation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Service_Service_ServiceIdService",
                        column: x => x.ServiceIdService,
                        principalTable: "Service",
                        principalColumn: "IdService",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_IdCity",
                table: "Address",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Card_IdAuthor",
                table: "Card",
                column: "IdAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Card_IdCardType",
                table: "Card",
                column: "IdCardType");

            migrationBuilder.CreateIndex(
                name: "IX_City_IdCountry",
                table: "City",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdAccountInformation",
                table: "Client",
                column: "IdAccountInformation");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdAddress",
                table: "Client",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Country_IdCapitalCity",
                table: "Country",
                column: "IdCapitalCity",
                unique: true,
                filter: "[IdCapitalCity] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Country_IdCurrency",
                table: "Country",
                column: "IdCurrency");

            migrationBuilder.CreateIndex(
                name: "IX_Country_IdLanguage",
                table: "Country",
                column: "IdLanguage");

            migrationBuilder.CreateIndex(
                name: "IX_CountryPhoto_IdCountry",
                table: "CountryPhoto",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdAccountInformation",
                table: "Employee",
                column: "IdAccountInformation");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdAddress",
                table: "Employee",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_IdArrivalCity",
                table: "Flight",
                column: "IdArrivalCity");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_IdDepartureCity",
                table: "Flight",
                column: "IdDepartureCity");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_IdAddress",
                table: "Hotel",
                column: "IdAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelPhoto_IdHotel",
                table: "HotelPhoto",
                column: "IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CityIdCity",
                table: "Reservation",
                column: "CityIdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdArrivalFlight",
                table: "Reservation",
                column: "IdArrivalFlight");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdDepartureFlight",
                table: "Reservation",
                column: "IdDepartureFlight");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdHotel",
                table: "Reservation",
                column: "IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdTrip",
                table: "Reservation",
                column: "IdTrip");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Service_ReservationIdReservation",
                table: "Reservation_Service",
                column: "ReservationIdReservation");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Service_ServiceIdService",
                table: "Reservation_Service",
                column: "ServiceIdService");

            migrationBuilder.CreateIndex(
                name: "IX_Service_IdServiceType",
                table: "Service",
                column: "IdServiceType");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_DestinationCityIdCity",
                table: "Trip",
                column: "DestinationCityIdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TripPhoto_TripIdTrip",
                table: "Trip_TripPhoto",
                column: "TripIdTrip");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TripPhoto_TripPhotoIdTripPhoto",
                table: "Trip_TripPhoto",
                column: "TripPhotoIdTripPhoto");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_IdCity",
                table: "Address",
                column: "IdCity",
                principalTable: "City",
                principalColumn: "IdCity",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_IdCountry",
                table: "City",
                column: "IdCountry",
                principalTable: "Country",
                principalColumn: "IdCountry",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_City_IdCapitalCity",
                table: "Country");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CountryPhoto");

            migrationBuilder.DropTable(
                name: "HotelPhoto");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Reservation_Service");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Trip_TripPhoto");

            migrationBuilder.DropTable(
                name: "CardType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "TripPhoto");

            migrationBuilder.DropTable(
                name: "AccountInformation");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
