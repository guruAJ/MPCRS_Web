using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MPCRS1.Models;

namespace MPCRS1.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<MPCRS1.Models.ExcelData> ExcelData { get; set; }
        public DbSet<ProcessData> processDatas { get; set; }

        public DbSet<UnitDtl> mProunit { get; set; }

        public DbSet<UploadDtl> UploadDtls { get; set; }

        public DbSet<Upload_dtl> Upload_Dtls { get; set; }
        public DbSet<tbl_offence> tbl_Offences { get; set; }

        //public DbSet<DiscpAnalysis> DiscpANALYSIS_report { get; set; }
        public DbSet<Login> logins { get; set; }

        public DbSet<DispAnarep> EmpVMs { get; set; }

        public DbSet<Contact> ContactUs  { get; set; }

        public DbSet<tbl_Comd> tbl_Comds { get; set; }


    }
}