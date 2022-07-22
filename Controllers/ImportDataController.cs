
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using MPCRS1.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MPCRS1.Data;


using System.Linq;
using MPCRS1.Repository;
using Microsoft.AspNetCore.Authorization;
using ExcelDataReader;
using System.Data;

namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ImportDataController : Controller
    {

        private readonly ApplicationDbContext _context;


        private IWebHostEnvironment webHostEnvironment;
        public ImportDataController(/*UnitDtlsController UnitDtls,*/ IWebHostEnvironment _webHostEnvironment, ApplicationDbContext context/*, UnitDetailRepo UnitDetailRepo*/)
        {
            webHostEnvironment = _webHostEnvironment;
            _context = context;

        }



        public IActionResult Index()
        {

            return View();


        }



        public async Task<IActionResult> uploadFile()
        {
            ViewBag.GetAll = await _context.Upload_Dtls.ToListAsync();

            return View();


        }



        [HttpPost]


        public async Task<IActionResult> uploadFile(CreateUpload_dtl upload)
        {


            if (upload == null)
            {
                return BadRequest();
            }
            string wwwPath = this.webHostEnvironment.WebRootPath;
            string contentPath = this.webHostEnvironment.ContentRootPath;


            //string path = Path.Combine(@"c:\", "Upload");

            string path = Path.Combine(this.webHostEnvironment.WebRootPath, "Image");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            List<string> uploadedFiles = new List<string>();
            string fileName = Path.GetFileName(upload.postedFiles.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, Path.GetFileName(upload.postedFiles.FileName)), FileMode.Create))
            {


                upload.postedFiles.CopyTo(stream);
                uploadedFiles.Add(fileName);

            }
            if (validateExcelFile(fileName))
            {

                

                var uloadDtl = new Upload_dtl()
                {
                    uploaddt = DateTime.Now,
                    FileName = fileName,
                    UploadedBy = "ASDC",
                    ProcessData = false,
                };

                string ftype = Path.GetExtension(upload.postedFiles.FileName);

                if (ftype == ".xls" || ftype == ".xlsx")
                {
                    _context.Upload_Dtls.Add(uloadDtl);
                    await _context.SaveChangesAsync();

                    TempData["message"] = "The Excel is Uploaded Successfully!";
                }
                else
                {
                    TempData["message"] = "This file formate is not supported !";
                }
            }
            else
            {
                TempData["message"] = "Please excel upload again, Mpro unit not matched !";
            }
            return RedirectToAction(nameof(uploadFile));
        }






        public bool validateExcelFile(string filename)
        {

            var fileName = Path.Combine(this.webHostEnvironment.WebRootPath, "Image" + "\\") + filename;

            FileStream stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string ftype = Path.GetExtension(filename);
            IExcelDataReader excelReader;
            if (ftype == ".xls")
            {
                // Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else
            {
                // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }

            var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()

            {

                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                {

                    UseHeaderRow = true
                }
            });
            stream.Close();
            List<ExcelData> Excelist = new List<ExcelData>();
            var dt = result.Tables[0];

            var list = (from a in _context.mProunit
                        join b in _context.tbl_Comds
                        on a.Command equals b.comdid

                        select new UnitDtl
                        {
                            Id = a.Id,
                            UnitName = a.UnitName,
                            Command = a.Command,
                            UnitCode = a.UnitCode,
                            Location = a.Location,
                            Fmn = a.Fmn,
                            Status = a.Status,
                            UpdatedBy = a.UpdatedBy,
                            UpdatedDate = a.UpdatedDate,
                            CommandName = b.Command
                        }
                        ).ToList();
            bool final_st = false;
            foreach (DataRow data in dt.Rows)
            {

                try
                {
                    
                    string unit=string.IsNullOrEmpty(data[0].ToString()) ? "" : data[0].ToString();
                    
                    if (!string.IsNullOrEmpty(unit))
                    {
                        unit = unit.Split("/")[0];
                        bool temp_st = false;

                        foreach (UnitDtl item in list)
                        {
                            string unitC = item.UnitCode.ToUpper().Split("/")[0];
                            if (unitC.Equals(unit.ToUpper()))
                            {
                                temp_st = true;
                                break;
                            }
                        }
                        final_st = temp_st;
                    }
                    if(final_st==false)
                    {
                        return final_st;
                    }
                }
                catch (Exception e)
                {

                }

            }           

            return final_st;
        }







        [HttpPost]

        public async Task<IActionResult> Delete(int? id)
        {
            var Upload_dtl = await _context.Upload_Dtls.FindAsync(id);
            _context.Upload_Dtls.Remove(Upload_dtl);
            await _context.SaveChangesAsync();
            return RedirectToAction("uploadFile");
        }


    }
}









































//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using System.IO;
//using MPCRS1.Models;
//using System.IO;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;


//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using MPCRS1.Data;



//namespace MPCRS1.Controllers
//{
//    public class ImportDataController : Controller
//    {

//        private readonly ApplicationDbContext _context;



//        private IWebHostEnvironment webHostEnvironment;
//        public ImportDataController(IWebHostEnvironment _webHostEnvironment, ApplicationDbContext context)
//        {
//            webHostEnvironment = _webHostEnvironment;
//            _context = context;
//        }

//        //public async Task<IActionResult> Index()
//        //{
//        //    var com = await _context.Upload_Dtls.Include(nameof(UnitDtl)).ToListAsync();
//        //    return View(com);
//        //}

//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Upload_Dtls.ToListAsync());
//        }


//        public async Task<IActionResult> uploadFile()
//        {
//            return View();

//        }







//        [HttpPost]


//        public async Task<IActionResult> uploadFile(CreateUpload_dtl upload)
//        {



//            if (upload == null)
//            {
//                return BadRequest();
//            }
//            string wwwPath = this.webHostEnvironment.WebRootPath;
//            string contentPath = this.webHostEnvironment.ContentRootPath;

//            string path = Path.Combine(this.webHostEnvironment.WebRootPath, "Image");
//            if (!Directory.Exists(path))
//            {
//                Directory.CreateDirectory(path);
//            }


//            List<string> uploadedFiles = new List<string>();

//            string fileName = Path.GetFileName(upload.postedFiles.FileName);
//            using (FileStream stream = new FileStream(Path.Combine(path, Path.GetFileName(upload.postedFiles.FileName)), FileMode.Create))
//            {
//                upload.postedFiles.CopyTo(stream);
//                uploadedFiles.Add(fileName);


//                // ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
//            }
//            var uloadDtl = new Upload_dtl()
//            {
//                uploaddt = DateTime.Now,
//                FileName = fileName,
//                UploadedBy = "ankit"
//            };

//            _context.Upload_Dtls.Add(uloadDtl);

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));





//            return View(uloadDtl);
//        }




//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var Upload_dtl = await _context.Upload_Dtls
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (Upload_dtl == null)
//            {
//                return NotFound();
//            }

//            return View(Upload_dtl);
//        }

//        // POST: UnitDtls/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var Upload_dtl = await _context.Upload_Dtls.FindAsync(id);
//            _context.Upload_Dtls.Remove(Upload_dtl);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));

//        }






//    }


//}



