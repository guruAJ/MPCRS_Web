using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;
using System.Globalization;
using System;
using System.Text;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using MPCRS1.Models;
using MPCRS1.Repository;
using System.Diagnostics;
using System.Web;
using MPCRS1.Data;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ProcessDataController : Controller
    {


        private readonly ProcessDataRepo _ProcessDataRepo = null;

        private readonly ApplicationDbContext _context;

        //private object webHostEnvironment;
        private IWebHostEnvironment webHostEnvironment;


        public ProcessDataController(ProcessDataRepo ProcessDataRepo, IWebHostEnvironment _webHostEnvironment, ApplicationDbContext context)
        {
            _ProcessDataRepo = ProcessDataRepo;
            webHostEnvironment = _webHostEnvironment;
            _context = context;
        }
        // GET: ProcessData
        public async Task<ActionResult> ProcessedDatas()
        {
            var aj = (from c in _context.tbl_Offences
                      join d in _context.processDatas
                      on c.offence_code equals d.occuranceid
                      where (d.uploaddt > DateTime.Now.AddDays(-6))
                      select new ProcessData
                      {


                          offenceid = d.offenceid,
                          comdid = d.comdid,

                          firnumber = d.firnumber,
                          armyno_cmp = d.armyno_cmp,
                          ranks_cmp = d.ranks_cmp,
                          names_cmp = d.names_cmp,
                          unitsid_cmp = d.unitsid_cmp,

                          fmnid_cmp = d.fmnid_cmp,
                          occurance_offence = d.occurance_offence,
                          station = d.station,
                          place = d.place,
                          offencedt = d.offencedt,
                          offencetime = d.offencetime,
                          icardno_offen = d.icardno_offen,

                          milveh = d.milveh,

                          civveh = d.civveh,

                          fatalmilpers = d.fatalmilpers,
                          fatalcivpers = d.fatalcivpers,
                          nonfatalmil = d.nonfatalmil,
                          nonfatacivil = d.nonfatacivil,
                          armyno_offen = d.armyno_offen,
                          rank_offen = d.rank_offen,
                          name_offen = d.name_offen,
                          unit_offen = d.unit_offen,

                          address_offen = d.address_offen,
                          teleno_offen = d.teleno_offen,

                          vehbano_offen = d.vehbano_offen,

                          vehmaketypeid_offen = d.vehmaketypeid_offen,   //2

                          fmn_offen = d.fmn_offen,

                          briefcase_offen = d.briefcase_offen,
                          evidence_sketch = d.evidence_sketch,
                          evidence_photo = d.evidence_photo,
                          evidence_video = d.evidence_video,
                          docu_att = d.docu_att,

                          items = d.items,

                          actiontaken = d.actiontaken,
                          det_occu_repport = d.det_occu_repport,

                          findings = d.findings,
                          remarksof_co_pro = d.remarksof_co_pro,
                          mod_op_facts = d.mod_op_facts,

                          station_cmp = d.station_cmp,
                          date_cmp = d.date_cmp,
                          nameofCO = d.nameofCO,
                          remarks = d.remarks,

                          report_type = d.report_type,


                          veh_colour_offen = d.veh_colour_offen,
                          armyno_codvr = d.armyno_codvr,
                          rank_codvr = d.rank_codvr,
                          Name_codvr = d.Name_codvr,
                          unit_codvr = d.unit_codvr,
                          fmn_codvr = d.fmn_codvr,


                          address_codvr = d.address_codvr,
                          veh_regnno = d.veh_regnno,
                          make_civ = d.make_civ,
                          colour = d.colour,
                          tactno = d.tactno,
                          cmpduty_timeto = d.cmpduty_timeto,

                          duty_of_cmp = d.duty_of_cmp,
                          jcno_cmpjco = d.jcno_cmpjco,
                          rank_cmpjco = d.rank_cmpjco,
                          name_cmpjco = d.name_cmpjco,
                          unit_cmpjco = d.unit_cmpjco,
                          cmpduty_timefrom = d.cmpduty_timefrom,
                          occuranceid = d.occuranceid,

                          speed_offe = d.speed_offe,
                          overspeed_offe = d.overspeed_offe,
                          speed_exc_offe = d.speed_exc_offe,

                          vehmake = d.vehmake,
                          evidences = d.evidences,
                          documents = d.documents,
                          case_stat = d.case_stat,

                          offence_desc = c.offence_desc

                      }).OrderByDescending(x => x.offencedt)
                              .ToList();
            TempData["cards"] = aj;







            //var ak = _ProcessDataRepo.GetAll();
            //ViewBag.ak = ak;    

            return View();
        }

        public ActionResult Index()
        {




            return View();
        }
        public async Task<ActionResult> DetailsOfOffenceReport()
        {
            return View();
        }

        // GET: ProcessData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProcessData/Create
        public ActionResult CreateProcessData()
        {
            return View();
        }

        // POST: ProcessData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ProcessData/Edit/5







        [HttpGet]
        public ActionResult ProcessDataCnf(string filename, UnitDtl dj, int Id)


        {
            ViewBag.ExcelFileId = Id;

            var fileName = Path.Combine(this.webHostEnvironment.WebRootPath, "Image" + "\\") + filename;




            //var fileName = "C:/Users/user/source/repos/newmpcrs1/wwwroot/Image/" + filename;




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




            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            //CreateOpenXmlReader



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



            foreach (DataRow data in dt.Rows)
            {





                //if (!offenceid(data[0]))
                //{
                //    LoggingService.LogWarning(emailValidate.ValidationMessage);
                //}

                //string unit =null;

                //if (data[0].ToString()!= null)
                //{

                //    unit = data[0].ToString().Split("-");
                //    DateString = unit[2].Substring(0, 4) + "-" + unit[1] + "-" + unit[0];

                //}
                //if (Db.ToDate != null)
                //{
                //    date = Db.ToDate.ToString().Split("-");
                //    ToDateString = date[2].Substring(0, 4) + "-" + date[1] + "-" + date[0];
                //}






                //int comdid1;
                //if (data[1].ToString() == null || data[1].ToString() == "")
                //    comdid1 = 0;
                //else
                //    comdid1 = Convert.ToInt32(data[1].ToString());

                //int fmnid_cmp1;
                //if(data[8].ToString()==null || data[8].ToString()=="")
                //    fmnid_cmp1 = 0;  
                //else
                //    fmnid_cmp1= Convert.ToInt32(data[8].ToString());

                try
                {
                    Excelist.Add(new ExcelData
                    {


                        offenceid = string.IsNullOrEmpty(data[0].ToString()) ? "" : data[0].ToString(),



                        comdid = string.IsNullOrEmpty(data[1].ToString()) ? 0 : Convert.ToInt32(data[1].ToString()),

                        firnumber = string.IsNullOrEmpty(data[2].ToString()) ? "" : data[2].ToString(),

                        armyno_cmp = string.IsNullOrEmpty(data[3].ToString()) ? "" : data[3].ToString(),

                        ranks_cmp = string.IsNullOrEmpty(data[4].ToString()) ? "" : data[4].ToString(),
                        names_cmp = string.IsNullOrEmpty(data[5].ToString()) ? "" : data[5].ToString(),

                        unitsid_cmp = string.IsNullOrEmpty(data[6].ToString()) ? "" : data[6].ToString(),




                        fmnid_cmp = string.IsNullOrEmpty(data[7].ToString()) ? 0 : Convert.ToInt32(data[7].ToString()),


                        occurance_offence = string.IsNullOrEmpty(data[8].ToString()) ? "" : data[8].ToString(),
                        station = string.IsNullOrEmpty(data[9].ToString()) ? "" : data[9].ToString(),
                        place = string.IsNullOrEmpty(data[10].ToString()) ? "" : data[10].ToString(),
                        offencedt = string.IsNullOrEmpty(data[11].ToString()) ? new DateTime() : Convert.ToDateTime(data[11].ToString()),
                        offencetime = string.IsNullOrEmpty(data[12].ToString()) ? "" : data[12].ToString(),
                        icardno_offen = string.IsNullOrEmpty(data[13].ToString()) ? "" : data[13].ToString(),
                        milveh = string.IsNullOrEmpty(data[14].ToString()) ? "" : data[14].ToString(),

                        civveh = string.IsNullOrEmpty(data[15].ToString()) ? "" : data[15].ToString(),
                        fatalmilpers = string.IsNullOrEmpty(data[16].ToString()) ? "" : data[16].ToString(),
                        fatalcivpers = string.IsNullOrEmpty(data[17].ToString()) ? "" : data[17].ToString(),
                        nonfatalmil = string.IsNullOrEmpty(data[18].ToString()) ? "" : data[18].ToString(),
                        nonfatacivil = string.IsNullOrEmpty(data[19].ToString()) ? "" : data[19].ToString(),
                        armyno_offen = string.IsNullOrEmpty(data[20].ToString()) ? "" : data[20].ToString(),
                        rank_offen = string.IsNullOrEmpty(data[21].ToString()) ? "" : data[21].ToString(),
                        name_offen = string.IsNullOrEmpty(data[22].ToString()) ? "" : data[22].ToString(),

                        unit_offen = string.IsNullOrEmpty(data[23].ToString()) ? "" : data[23].ToString(),
                        address_offen = string.IsNullOrEmpty(data[24].ToString()) ? "" : data[24].ToString(),


                        teleno_offen = string.IsNullOrEmpty(data[25].ToString()) ? "" : data[25].ToString(),
                        vehbano_offen = string.IsNullOrEmpty(data[26].ToString()) ? "" : data[26].ToString(),

                        vehmaketypeid_offen = string.IsNullOrEmpty(data[27].ToString()) ? "" : data[27].ToString(),

                        //vehmaketypeid_offen = string.IsNullOrEmpty(data[27].ToString()) ? 0 : Convert.ToInt32(data[27].ToString()),  //3

                        fmn_offen = string.IsNullOrEmpty(data[28].ToString()) ? "" : data[28].ToString(),
                        briefcase_offen = string.IsNullOrEmpty(data[29].ToString()) ? "" : data[29].ToString(),
                        evidence_sketch = string.IsNullOrEmpty(data[30].ToString()) ? "" : data[30].ToString(),
                        evidence_photo = string.IsNullOrEmpty(data[31].ToString()) ? "" : data[31].ToString(),
                        evidence_video = string.IsNullOrEmpty(data[32].ToString()) ? "" : data[32].ToString(),
                        docu_att = string.IsNullOrEmpty(data[33].ToString()) ? "" : data[33].ToString(),
                        items = string.IsNullOrEmpty(data[34].ToString()) ? "" : data[34].ToString(),
                        actiontaken = string.IsNullOrEmpty(data[35].ToString()) ? "" : data[35].ToString(),
                        det_occu_repport = string.IsNullOrEmpty(data[36].ToString()) ? "" : data[36].ToString(),
                        findings = string.IsNullOrEmpty(data[37].ToString()) ? "" : data[37].ToString(),
                        remarksof_co_pro = string.IsNullOrEmpty(data[38].ToString()) ? "" : data[38].ToString(),
                        mod_op_facts = string.IsNullOrEmpty(data[39].ToString()) ? "" : data[39].ToString(),
                        station_cmp = string.IsNullOrEmpty(data[40].ToString()) ? "" : data[40].ToString(),

                        date_cmp = string.IsNullOrEmpty(data[41].ToString()) ? new DateTime() : Convert.ToDateTime(data[41].ToString()),


                        nameofCO = string.IsNullOrEmpty(data[42].ToString()) ? "" : data[42].ToString(),

                        remarks = string.IsNullOrEmpty(data[43].ToString()) ? "" : data[43].ToString(),

                        report_type = string.IsNullOrEmpty(data[44].ToString()) ? 0 : Convert.ToInt32(data[44].ToString()),

                        veh_colour_offen = string.IsNullOrEmpty(data[45].ToString()) ? "" : data[45].ToString(),
                        armyno_codvr = string.IsNullOrEmpty(data[46].ToString()) ? "" : data[46].ToString(),
                        rank_codvr = string.IsNullOrEmpty(data[47].ToString()) ? "" : data[47].ToString(),
                        Name_codvr = string.IsNullOrEmpty(data[48].ToString()) ? "" : data[48].ToString(),
                        unit_codvr = string.IsNullOrEmpty(data[49].ToString()) ? "" : data[49].ToString(),
                        fmn_codvr = string.IsNullOrEmpty(data[50].ToString()) ? "" : data[50].ToString(),
                        address_codvr = string.IsNullOrEmpty(data[51].ToString()) ? "" : data[51].ToString(),
                        veh_regnno = string.IsNullOrEmpty(data[52].ToString()) ? "" : data[52].ToString(),
                        make_civ = string.IsNullOrEmpty(data[53].ToString()) ? "" : data[53].ToString(),
                        colour = string.IsNullOrEmpty(data[54].ToString()) ? "" : data[54].ToString(),
                        tactno = string.IsNullOrEmpty(data[55].ToString()) ? "" : data[55].ToString(),
                        cmpduty_timeto = string.IsNullOrEmpty(data[56].ToString()) ? "" : data[56].ToString(),
                        duty_of_cmp = string.IsNullOrEmpty(data[57].ToString()) ? "" : data[57].ToString(),
                        jcno_cmpjco = string.IsNullOrEmpty(data[58].ToString()) ? "" : data[58].ToString(),
                        rank_cmpjco = string.IsNullOrEmpty(data[59].ToString()) ? "" : data[59].ToString(),
                        name_cmpjco = string.IsNullOrEmpty(data[60].ToString()) ? "" : data[60].ToString(),
                        unit_cmpjco = string.IsNullOrEmpty(data[61].ToString()) ? "" : data[61].ToString(),




                        cmpduty_timefrom = string.IsNullOrEmpty(data[62].ToString()) ? "" : data[62].ToString(),


                        occuranceid = string.IsNullOrEmpty(data[63].ToString()) ? 0 : Convert.ToInt32(data[63].ToString()),
                        speed_offe = string.IsNullOrEmpty(data[64].ToString()) ? "" : data[64].ToString(),
                        overspeed_offe = string.IsNullOrEmpty(data[65].ToString()) ? "" : data[65].ToString(),
                        speed_exc_offe = string.IsNullOrEmpty(data[66].ToString()) ? "" : data[66].ToString(),
                        vehmake = string.IsNullOrEmpty(data[67].ToString()) ? "" : data[67].ToString(),
                        evidences = string.IsNullOrEmpty(data[68].ToString()) ? "" : data[68].ToString(),
                        documents = string.IsNullOrEmpty(data[69].ToString()) ? "" : data[69].ToString(),


                        case_stat = string.IsNullOrEmpty(data[70].ToString()) ? false : Convert.ToBoolean(data[70].ToString()),


                        unit_cmp = string.IsNullOrEmpty(data[71].ToString()) ? "" : data[71].ToString(),



                        Checked = false,

                        //EmpId = 1

                    });



                    string unit = null;
                    string units = null;




                    if (data[0].ToString() != null)
                    {

                        string[] offenceCode = data[0].ToString().Split("/");
                        unit = offenceCode[0];


                        //List<UnitDtl> unitCodes = new List<UnitDtl>();
                        var unitCodes = (from e in _context.mProunit select e.UnitCode).ToList();
                        //foreach(var item in unitCodes)
                        //{

                        //    units = item.UnitCode;
                        //}


                        //if(dj.UnitCode != null)
                        //{
                        //    string[] UnitCode = dj.UnitCode.Split("/");
                        //    units = UnitCode[0];
                        //} 






                        //if (unit == offenceid)
                        //foreach (string unitId  in unit)
                        //{
                        //    if (unitId.Trim() != "/")
                        //        Console.WriteLine(unitId);
                        //}


                        //string unit =null;

                        //if (data[0].ToString()!= null)
                        //{

                        //    unit = data[0].ToString().Split("-");
                        //    DateString = unit[2].Substring(0, 4) + "-" + unit[1] + "-" + unit[0];

                        //}
                        //if (Db.ToDate != null)
                        //{
                        //    date = Db.ToDate.ToString().Split("-");
                        //    ToDateString = date[2].Substring(0, 4) + "-" + date[1] + "-" + date[0];
                        //}


                        //unit = data[0].ToString().Split("-");
                        //unit = unit[1] + "-" + unit[0];

                    }


                }
                catch (Exception e)
                {

                }


            }



            ExcelDataViewModel viewModel = new ExcelDataViewModel();

            viewModel.ExcelDatas = Excelist;

            return View(viewModel);









        }

        private bool HasFileHandle(string fileName, Process clsProcess)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public string ProcessDataCnf1(string dt, int[] indexs, int id)
        {
            string msg = "";
            List<ExcelData> ExcelDatas = System.Text.Json.JsonSerializer.Deserialize<List<ExcelData>>(dt);
            int c = 0;

            if (indexs.Count() > 0)
            {
                int lasindex = indexs[indexs.Count() - 1];
                if (ExcelDatas != null)
                {

                    for (int i = indexs[0]; i <= lasindex; i++)
                    {
                        ExcelData data = ExcelDatas.ElementAt(i);
                        data.Checked = true;
                        _ProcessDataRepo.ProcessDataCnfCreate(data);
                    }


                    msg = "Data Added/Updated Successfully";
                    Upload_dtl dttt = _context.Upload_Dtls.FirstOrDefault(e => e.Id == id);
                    dttt.ProcessData = true;
                    _context.Update(dttt);
                    _context.SaveChanges();


                }
            }
            else
            {
                msg = "Please select Valid excel file format!";

            }

            //Response.WriteAsJsonAsync("<script>alert('Hello');</script>");
            //return RedirectToAction("DetailsOfOffenceReport");
            return msg;

        }

        public IActionResult ProcessDataCnfCreate()
        {
            return View();
        }




        [HttpPost]
        public ActionResult ProcessDataCnfCreate(ExcelDataViewModel excelDataViewModel)
        {
            foreach (var v in excelDataViewModel.ExcelDatas)
            {
                _ProcessDataRepo.ProcessDataCnfCreate(v);
            }


            return View();





        }




        // POST: ProcessData/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcessData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProcessData/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }






        public async Task<ActionResult> DetailsOfOpenProject()
        {
            var open = (from c in _context.tbl_Offences
                        join d in _context.processDatas
                        on c.offence_code equals d.occuranceid
                        where (d.case_stat == false)
                        select new ProcessData
                        {


                            offenceid = d.offenceid,
                            comdid = d.comdid,

                            firnumber = d.firnumber,
                            armyno_cmp = d.armyno_cmp,
                            ranks_cmp = d.ranks_cmp,
                            names_cmp = d.names_cmp,
                            unitsid_cmp = d.unitsid_cmp,

                            fmnid_cmp = d.fmnid_cmp,
                            occurance_offence = d.occurance_offence,
                            station = d.station,
                            place = d.place,
                            offencedt = d.offencedt,
                            offencetime = d.offencetime,
                            icardno_offen = d.icardno_offen,

                            milveh = d.milveh,

                            civveh = d.civveh,

                            fatalmilpers = d.fatalmilpers,
                            fatalcivpers = d.fatalcivpers,
                            nonfatalmil = d.nonfatalmil,
                            nonfatacivil = d.nonfatacivil,
                            armyno_offen = d.armyno_offen,
                            rank_offen = d.rank_offen,
                            name_offen = d.name_offen,
                            unit_offen = d.unit_offen,

                            address_offen = d.address_offen,
                            teleno_offen = d.teleno_offen,

                            vehbano_offen = d.vehbano_offen,

                            vehmaketypeid_offen = d.vehmaketypeid_offen,  //4




                            fmn_offen = d.fmn_offen,

                            briefcase_offen = d.briefcase_offen,
                            evidence_sketch = d.evidence_sketch,
                            evidence_photo = d.evidence_photo,
                            evidence_video = d.evidence_video,
                            docu_att = d.docu_att,

                            items = d.items,

                            actiontaken = d.actiontaken,
                            det_occu_repport = d.det_occu_repport,

                            findings = d.findings,
                            remarksof_co_pro = d.remarksof_co_pro,
                            mod_op_facts = d.mod_op_facts,

                            station_cmp = d.station_cmp,
                            date_cmp = d.date_cmp,
                            nameofCO = d.nameofCO,
                            remarks = d.remarks,

                            report_type = d.report_type,


                            veh_colour_offen = d.veh_colour_offen,
                            armyno_codvr = d.armyno_codvr,
                            rank_codvr = d.rank_codvr,
                            Name_codvr = d.Name_codvr,
                            unit_codvr = d.unit_codvr,
                            fmn_codvr = d.fmn_codvr,


                            address_codvr = d.address_codvr,
                            veh_regnno = d.veh_regnno,
                            make_civ = d.make_civ,
                            colour = d.colour,
                            tactno = d.tactno,
                            cmpduty_timeto = d.cmpduty_timeto,

                            duty_of_cmp = d.duty_of_cmp,
                            jcno_cmpjco = d.jcno_cmpjco,
                            rank_cmpjco = d.rank_cmpjco,
                            name_cmpjco = d.name_cmpjco,
                            unit_cmpjco = d.unit_cmpjco,
                            cmpduty_timefrom = d.cmpduty_timefrom,
                            occuranceid = d.occuranceid,

                            speed_offe = d.speed_offe,
                            overspeed_offe = d.overspeed_offe,
                            speed_exc_offe = d.speed_exc_offe,

                            vehmake = d.vehmake,
                            evidences = d.evidences,
                            documents = d.documents,
                            unit_cmp = d.unit_cmp,
                            case_stat = d.case_stat,

                            offence_desc = c.offence_desc

                        }).OrderByDescending(x => x.offencedt)
                              .ToList();
            TempData["statusOpen"] = open;







            //var ak = _ProcessDataRepo.GetAll();
            //ViewBag.ak = ak;    

            return View();
        }







        public async Task<ActionResult> DetailsOfCloseProject()
        {
            var close = (from c in _context.tbl_Offences
                         join d in _context.processDatas
                         on c.offence_code equals d.occuranceid
                         where (d.case_stat == true)
                         select new ProcessData
                         {


                             offenceid = d.offenceid,
                             comdid = d.comdid,

                             firnumber = d.firnumber,
                             armyno_cmp = d.armyno_cmp,
                             ranks_cmp = d.ranks_cmp,
                             names_cmp = d.names_cmp,
                             unitsid_cmp = d.unitsid_cmp,

                             fmnid_cmp = d.fmnid_cmp,
                             occurance_offence = d.occurance_offence,
                             station = d.station,
                             place = d.place,
                             offencedt = d.offencedt,
                             offencetime = d.offencetime,
                             icardno_offen = d.icardno_offen,

                             milveh = d.milveh,

                             civveh = d.civveh,

                             fatalmilpers = d.fatalmilpers,
                             fatalcivpers = d.fatalcivpers,
                             nonfatalmil = d.nonfatalmil,
                             nonfatacivil = d.nonfatacivil,
                             armyno_offen = d.armyno_offen,
                             rank_offen = d.rank_offen,
                             name_offen = d.name_offen,
                             unit_offen = d.unit_offen,

                             address_offen = d.address_offen,
                             teleno_offen = d.teleno_offen,

                             vehbano_offen = d.vehbano_offen,

                             vehmaketypeid_offen = d.vehmaketypeid_offen, //5

                             fmn_offen = d.fmn_offen,

                             briefcase_offen = d.briefcase_offen,
                             evidence_sketch = d.evidence_sketch,
                             evidence_photo = d.evidence_photo,
                             evidence_video = d.evidence_video,
                             docu_att = d.docu_att,

                             items = d.items,

                             actiontaken = d.actiontaken,
                             det_occu_repport = d.det_occu_repport,

                             findings = d.findings,
                             remarksof_co_pro = d.remarksof_co_pro,
                             mod_op_facts = d.mod_op_facts,

                             station_cmp = d.station_cmp,
                             date_cmp = d.date_cmp,
                             nameofCO = d.nameofCO,
                             remarks = d.remarks,

                             report_type = d.report_type,


                             veh_colour_offen = d.veh_colour_offen,
                             armyno_codvr = d.armyno_codvr,
                             rank_codvr = d.rank_codvr,
                             Name_codvr = d.Name_codvr,
                             unit_codvr = d.unit_codvr,
                             fmn_codvr = d.fmn_codvr,


                             address_codvr = d.address_codvr,
                             veh_regnno = d.veh_regnno,
                             make_civ = d.make_civ,
                             colour = d.colour,
                             tactno = d.tactno,
                             cmpduty_timeto = d.cmpduty_timeto,

                             duty_of_cmp = d.duty_of_cmp,
                             jcno_cmpjco = d.jcno_cmpjco,
                             rank_cmpjco = d.rank_cmpjco,
                             name_cmpjco = d.name_cmpjco,
                             unit_cmpjco = d.unit_cmpjco,
                             cmpduty_timefrom = d.cmpduty_timefrom,
                             occuranceid = d.occuranceid,

                             speed_offe = d.speed_offe,
                             overspeed_offe = d.overspeed_offe,
                             speed_exc_offe = d.speed_exc_offe,

                             vehmake = d.vehmake,
                             evidences = d.evidences,
                             documents = d.documents,
                             case_stat = d.case_stat,

                             offence_desc = c.offence_desc

                         }).OrderByDescending(x => x.offencedt)
                              .ToList();
            TempData["statusclose"] = close;







            //var ak = _ProcessDataRepo.GetAll();
            //ViewBag.ak = ak;    

            return View();
        }



    }
}



































