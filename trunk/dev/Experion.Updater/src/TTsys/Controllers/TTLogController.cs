using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TTsys.Models;

namespace TTsys.Controllers
{
    public class TTLogController : Controller
    {

        // GET: /TTLog/

        public ActionResult LoadDetails()
        {

            //userid=134

            int startidentifier = (int)System.DateTime.Today.DayOfWeek;

            DateTime fromDate = System.DateTime.Today.AddDays(-1 * (startidentifier - 1));

            DateTime toDate = fromDate.AddDays(6);

            timetrackBO timetrackbo = GetDetailsForDateRange(fromDate, toDate);

            #region Old


            //timetracklistBO timetracklist = new timetracklistBO();
            //timetracklist.Add(new timetrackBO { ProjectName = "TOTAL Hour", Day1 = 10, Day2 = 10, Day3 = 8, Day4 = 8, Day5 = 10, Day1Name = "2013/11/29", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });
            //timetracklist.Add(new timetrackBO { ProjectName = "Project1", Day1 = 1, Day2 = 3, Day3 = 1, Day4 = 1, Day5 = 1, Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });
            //timetracklist.Add(new timetrackBO { ProjectName = "Project2", Day1 = 2, Day2 = 1, Day3 = 2, Day4 = 1, Day5 = 2, Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });
            //timetracklist.Add(new timetrackBO { ProjectName = "Project3", Day1 = 2, Day2 = 4, Day3 = 0, Day4 = 2, Day5 = 2, Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });
            //timetracklist.Add(new timetrackBO { ProjectName = "Project4", Day1 = 2, Day2 = 0, Day3 = 2, Day4 = 0, Day5 = 2, Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });


            //List<timetrackBO> list = new List<timetrackBO>();
            //list.Add(new timetrackBO { ProjectName = "TOTAL Hour", Day1 = 10, Day2 = 10, Day3 = 8, Day4 = 8, Day5 = 10, Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });
            //list.Add(new timetrackBO { ProjectName = "Project1", Day1 = 1, Day2 = 3, Day3 = 1, Day4 = 1, Day5 = 1 ,   Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });
            //list.Add(new timetrackBO { ProjectName = "Project2", Day1 = 2, Day2 = 1, Day3 = 2, Day4 = 1, Day5 = 2,     Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });
            //list.Add(new timetrackBO { ProjectName = "Project3", Day1 = 2, Day2 = 4, Day3 = 0, Day4 = 2, Day5 = 2  ,   Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });
            //list.Add(new timetrackBO { ProjectName = "Project4", Day1 = 2, Day2 = 0, Day3 = 2, Day4 = 0, Day5 = 2   ,  Day1Name = "Mon", Day2Name = "Tue", Day3Name = "Wed", Day4Name = "Thu", Day5Name = "Fri" });

            #endregion

            TempData["CurrentStartDate"] = fromDate;

            TempData["datatem"] = timetrackbo;

            TempData.Keep("datatem");

            TempData.Keep("CurrentStartDate");
            return View(timetrackbo);
            //return View(list.AsQueryable());
        }


        public ActionResult LoadPrev_NextDetails(String Command)
        {
            DateTime CurrentfromDate = (DateTime)TempData["CurrentStartDate"];

            DateTime NewFromDate;

            DateTime NewtoDate;

            if (Command == "<<<")
            {
                NewFromDate = CurrentfromDate.AddDays(-7);

                NewtoDate = CurrentfromDate.AddDays(-1);

            }
            else
            {
                NewFromDate = CurrentfromDate.AddDays(7);

                NewtoDate = CurrentfromDate.AddDays(13);
            }


            timetrackBO timetrackbo = GetDetailsForDateRange(NewFromDate, NewtoDate);

            TempData["CurrentStartDate"] = NewFromDate;

            TempData.Keep("CurrentStartDate");

            TempData["datatem"] = timetrackbo;

            TempData.Keep("datatem");


            return View("LoadDetails", timetrackbo);
        }

        private static timetrackBO GetDetailsForDateRange(DateTime fromDate, DateTime toDate)
        {
            PMOService.PMOServiceClient objpmoservice = new PMOService.PMOServiceClient();

            var logTransaction = objpmoservice.GetLogTransacion(fromDate, toDate, 27);

            var datediff = (toDate - fromDate);

            Dictionary<DateTime, double> effortDictionary = new Dictionary<DateTime, double>();

            for (int i = 0; i <= datediff.Days; i++)
            {
                var netEffort = objpmoservice.GetEffort(fromDate.AddDays(i), 27);

                effortDictionary.Add(fromDate.AddDays(i), netEffort);
            }

            timetrackBO timetrackbo = new Models.timetrackBO();

            timetrackbo.dateEffortlist = new List<dateAndEffort>();

            for (int i = 0; i <= datediff.Days; i++)
            {
                var dt = logTransaction[fromDate.AddDays(i)];

                List<logDetails> logdetailslist = new List<logDetails>();

                foreach (var item in dt)
                {
                    logdetailslist.Add(new logDetails { LogType = item.Direction, LogTime = item.Date });

                }

                timetrackbo.dateEffortlist.Add(new dateAndEffort { effortDate = fromDate.AddDays(i), netEffort = effortDictionary[fromDate.AddDays(i)], LogDetailsList = logdetailslist });
            }


            List<timetrackBO> list = new List<timetrackBO>();

            list.Add(new timetrackBO { ProjectName = "Project1", Day1 = 1, Day2 = 3, Day3 = 1, Day4 = 1, Day5 = 1, Day6 = 1, Day7 = 1 });
            list.Add(new timetrackBO { ProjectName = "Project2", Day1 = 2, Day2 = 1, Day3 = 2, Day4 = 1, Day5 = 2, Day6 = 1, Day7 = 1 });
            list.Add(new timetrackBO { ProjectName = "Project3", Day1 = 2, Day2 = 4, Day3 = 0, Day4 = 2, Day5 = 2, Day6 = 1, Day7 = 1 });
            list.Add(new timetrackBO { ProjectName = "Project4", Day1 = 2, Day2 = 0, Day3 = 2, Day4 = 0, Day5 = 2, Day6 = 1, Day7 = 1 });

            timetrackbo.timetrklist = list;

            //timetrackbo.ProjectName = "Proj1";
            //timetrackbo.Day1 = 1; timetrackbo.Day2 = 3; timetrackbo.Day3 = 1; timetrackbo.Day4 = 1; timetrackbo.Day5 = 1; timetrackbo.Day6 = 1; timetrackbo.Day7 = 1;

            return timetrackbo;
        }


        public ActionResult popupLog(DateTime data)
        {

            DateTime test = (DateTime)data;

            var timetracklist = (timetrackBO)TempData["datatem"];

            TempData["datatem"] = timetracklist;

            TempData.Keep("datatem");

            DateTime startdate = (DateTime)TempData["CurrentStartDate"];

            TempData.Keep("CurrentStartDate");

            var objloglist = (from s in timetracklist.dateEffortlist where s.effortDate == test select s);

            List<logDetails> Loglist = new List<logDetails>();



            foreach (var item in objloglist)
            {
                Loglist = item.LogDetailsList;
            }

            return PartialView(Loglist);
        }


        public ActionResult landingPage()
        {
            return View();
        }


    }

}