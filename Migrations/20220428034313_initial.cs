using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPCRS1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmpVMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comdid = table.Column<int>(type: "int", nullable: false),
                    offence_code = table.Column<int>(type: "int", nullable: false),
                    offence_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maj_offences = table.Column<bool>(type: "bit", nullable: false),
                    offencedt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    occuranceid = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    caseTotal = table.Column<int>(type: "int", nullable: false),
                    case_stat = table.Column<bool>(type: "bit", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpVMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExcelData",
                columns: table => new
                {
                    offenceid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    comdid = table.Column<int>(type: "int", nullable: true),
                    firnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    armyno_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ranks_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    names_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitsid_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fmnid_cmp = table.Column<int>(type: "int", nullable: true),
                    occurance_offence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    station = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    offencedt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    offencetime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icardno_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    milveh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    civveh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatalmilpers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatalcivpers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nonfatalmil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nonfatacivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    armyno_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teleno_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehbano_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehmaketypeid_offen = table.Column<int>(type: "int", nullable: true),    //6
                    fmn_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    briefcase_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidence_sketch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidence_photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidence_video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    docu_att = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    items = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actiontaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    det_occu_repport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    findings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarksof_co_pro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mod_op_facts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    station_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_cmp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nameofCO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    report_type = table.Column<int>(type: "int", nullable: true),
                    veh_colour_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    armyno_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fmn_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    veh_regnno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    make_civ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tactno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmpduty_timeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duty_of_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jcno_cmpjco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank_cmpjco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_cmpjco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_cmpjco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmpduty_timefrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    occuranceid = table.Column<int>(type: "int", nullable: true),
                    speed_offe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overspeed_offe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    speed_exc_offe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehmake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    documents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    case_stat = table.Column<bool>(type: "bit", nullable: true),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelData", x => x.offenceid);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "varchar(200)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mProunit",
                columns: table => new
                {
                    unitid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Command = table.Column<int>(type: "int", nullable: false),
                    unitcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area_loc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fmn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updateddt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mProunit", x => x.unitid);
                });

            migrationBuilder.CreateTable(
                name: "processDatas",
                columns: table => new
                {
                    offenceid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    comdid = table.Column<int>(type: "int", nullable: false),
                    firnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    armyno_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ranks_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    names_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitsid_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fmnid_cmp = table.Column<int>(type: "int", nullable: false),
                    occurance_offence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    station = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    offencedt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    offencetime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icardno_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    milveh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    civveh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatalmilpers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatalcivpers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nonfatalmil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nonfatacivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    armyno_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teleno_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehbano_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehmaketypeid_offen = table.Column<int>(type: "int", nullable: false), //7
                    fmn_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    briefcase_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidence_sketch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidence_photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidence_video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    docu_att = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    items = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actiontaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    det_occu_repport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    findings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarksof_co_pro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mod_op_facts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    station_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_cmp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nameofCO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    report_type = table.Column<int>(type: "int", nullable: false),
                    veh_colour_offen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    armyno_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fmn_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_codvr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    veh_regnno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    make_civ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tactno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmpduty_timeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duty_of_cmp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jcno_cmpjco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank_cmpjco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_cmpjco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_cmpjco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cmpduty_timefrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    occuranceid = table.Column<int>(type: "int", nullable: false),
                    speed_offe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overspeed_offe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    speed_exc_offe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehmake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    documents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    case_stat = table.Column<bool>(type: "bit", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processDatas", x => x.offenceid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Comds",
                columns: table => new
                {
                    comdid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comdName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Comds", x => x.comdid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Offences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offence_code = table.Column<int>(type: "int", nullable: false),
                    offence_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maj_offence = table.Column<bool>(type: "bit", nullable: false),
                    Print_seq = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Offences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Upload_Dtls",
                columns: table => new
                {
                    UploadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uploaddt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessData = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upload_Dtls", x => x.UploadId);
                });

            migrationBuilder.CreateTable(
                name: "UploadDtls",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unitname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uploaddt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    processeddt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalRec = table.Column<int>(type: "int", nullable: false),
                    RejectedRec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadDtls", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "EmpVMs");

            migrationBuilder.DropTable(
                name: "ExcelData");

            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "mProunit");

            migrationBuilder.DropTable(
                name: "processDatas");

            migrationBuilder.DropTable(
                name: "tbl_Comds");

            migrationBuilder.DropTable(
                name: "tbl_Offences");

            migrationBuilder.DropTable(
                name: "Upload_Dtls");

            migrationBuilder.DropTable(
                name: "UploadDtls");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
