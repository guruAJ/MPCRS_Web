﻿// <auto-generated />
using System;
using MPCRS1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MPCRS1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220505100021_uploaddt")]
    partial class uploaddt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MPCRS1.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("MPCRS1.Models.DispAnarep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("caseTotal")
                        .HasColumnType("int");

                    b.Property<bool>("case_stat")
                        .HasColumnType("bit");

                    b.Property<int>("comdid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("maj_offences")
                        .HasColumnType("bit");

                    b.Property<int>("occuranceid")
                        .HasColumnType("int");

                    b.Property<int>("offence_code")
                        .HasColumnType("int");

                    b.Property<string>("offence_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("offencedt")
                        .HasColumnType("datetime2");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmpVMs");
                });

            modelBuilder.Entity("MPCRS1.Models.ExcelData", b =>
                {
                    b.Property<string>("offenceid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<string>("Name_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actiontaken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("armyno_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("armyno_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("armyno_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("briefcase_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("case_stat")
                        .HasColumnType("bit");

                    b.Property<string>("civveh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cmpduty_timefrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cmpduty_timeto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("comdid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date_cmp")
                        .HasColumnType("datetime2");

                    b.Property<string>("det_occu_repport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("docu_att")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("documents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("duty_of_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evidence_photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evidence_sketch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evidence_video")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evidences")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fatalcivpers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fatalmilpers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("findings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fmn_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fmn_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("fmnid_cmp")
                        .HasColumnType("int");

                    b.Property<string>("icardno_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("items")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jcno_cmpjco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("make_civ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("milveh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mod_op_facts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name_cmpjco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameofCO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("names_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nonfatacivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nonfatalmil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("occurance_offence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("occuranceid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("offencedt")
                        .HasColumnType("datetime2");

                    b.Property<string>("offencetime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overspeed_offe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rank_cmpjco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rank_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rank_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ranks_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarksof_co_pro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("report_type")
                        .HasColumnType("int");

                    b.Property<string>("speed_exc_offe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speed_offe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("station")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("station_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tactno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("teleno_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit_cmpjco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitsid_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("veh_colour_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("veh_regnno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vehbano_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vehmake")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("vehmaketypeid_offen")   //10
                        .HasColumnType("int");

                    b.HasKey("offenceid");

                    b.ToTable("ExcelData");
                });

            modelBuilder.Entity("MPCRS1.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("logins");
                });

            modelBuilder.Entity("MPCRS1.Models.ProcessData", b =>
                {
                    b.Property<string>("offenceid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<string>("Name_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actiontaken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("armyno_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("armyno_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("armyno_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("briefcase_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("case_stat")
                        .HasColumnType("bit");

                    b.Property<string>("civveh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cmpduty_timefrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cmpduty_timeto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("comdid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date_cmp")
                        .HasColumnType("datetime2");

                    b.Property<string>("det_occu_repport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("docu_att")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("documents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("duty_of_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evidence_photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evidence_sketch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evidence_video")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evidences")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fatalcivpers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fatalmilpers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("findings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fmn_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fmn_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fmnid_cmp")
                        .HasColumnType("int");

                    b.Property<string>("icardno_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("items")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jcno_cmpjco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("make_civ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("milveh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mod_op_facts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name_cmpjco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameofCO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("names_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nonfatacivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nonfatalmil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("occurance_offence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("occuranceid")
                        .HasColumnType("int");

                    b.Property<DateTime>("offencedt")
                        .HasColumnType("datetime2");

                    b.Property<string>("offencetime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overspeed_offe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rank_cmpjco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rank_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rank_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ranks_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarksof_co_pro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("report_type")
                        .HasColumnType("int");

                    b.Property<string>("speed_exc_offe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speed_offe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("station")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("station_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tactno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("teleno_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit_cmpjco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit_codvr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitsid_cmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("uploaddt")
                        .HasColumnType("datetime2")
                        .HasColumnName("uploaddt");

                    b.Property<string>("veh_colour_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("veh_regnno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vehbano_offen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vehmake")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("vehmaketypeid_offen") //11
                        .HasColumnType("int");

                    b.HasKey("offenceid");

                    b.ToTable("processDatas");
                });

            modelBuilder.Entity("MPCRS1.Models.tbl_Comd", b =>
                {
                    b.Property<int>("comdid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("comdid"), 1L, 1);

                    b.Property<string>("Command")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("comdName");

                    b.HasKey("comdid");

                    b.ToTable("tbl_Comds");
                });

            modelBuilder.Entity("MPCRS1.Models.tbl_offence", b =>
                {
                    b.Property<int>("offnsid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("offnsid"), 1L, 1);

                    b.Property<int>("Print_seq")
                        .HasColumnType("int");

                    b.Property<bool>("maj_offence")
                        .HasColumnType("bit");

                    b.Property<int>("offence_code")
                        .HasColumnType("int");

                    b.Property<string>("offence_desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("offnsid");

                    b.ToTable("tbl_Offences");
                });

            modelBuilder.Entity("MPCRS1.Models.UnitDtl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("unitid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Command")
                        .HasColumnType("int");

                    b.Property<string>("Fmn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fmn");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("area_loc");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("UnitCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("unitcode");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("unitname");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updateddt");

                    b.HasKey("Id");

                    b.ToTable("mProunit");
                });

            modelBuilder.Entity("MPCRS1.Models.Upload_dtl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UploadId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FileName");

                    b.Property<bool>("ProcessData")
                        .HasColumnType("bit");

                    b.Property<string>("UploadedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UploadedBy");

                    b.Property<DateTime>("uploaddt")
                        .HasColumnType("datetime2")
                        .HasColumnName("uploaddt");

                    b.HasKey("Id");

                    b.ToTable("Upload_Dtls");
                });

            modelBuilder.Entity("MPCRS1.Models.UploadDtl", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UnitId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FileName");

                    b.Property<int>("RejectedRecords")
                        .HasColumnType("int")
                        .HasColumnName("RejectedRec");

                    b.Property<int>("TotalRecords")
                        .HasColumnType("int")
                        .HasColumnName("TotalRec");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Unitname");

                    b.Property<DateTime>("processeddt")
                        .HasColumnType("datetime2")
                        .HasColumnName("processeddt");

                    b.Property<DateTime>("uploaddt")
                        .HasColumnType("datetime2")
                        .HasColumnName("uploaddt");

                    b.HasKey("UnitId");

                    b.ToTable("UploadDtls");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
