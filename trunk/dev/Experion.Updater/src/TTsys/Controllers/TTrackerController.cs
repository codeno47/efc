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
    public class TTrackerController : Controller
    {
        //
        // GET: /TTracker/

        public ActionResult LoadSearchScreen()
        {
            //PMOService.PMOServiceClient objpmoservice = new PMOService.PMOServiceClient();
            //var employeeleavestatus = await objpmoservice.GetPossibleLeaveEntryAsync(System.DateTime.Today);
            //var employeeleavestatus
            ViewBag.DateValue = System.DateTime.Today;
            List<LeaveTracker> leaveTracklist = new List<LeaveTracker>();

            //foreach (var item in employeeleavestatus)
            //{
            //    string userId = item.Key;
            //    var dt = employeeleavestatus[userId];

            //    leaveTracklist.Add(new LeaveTracker{UserId=userId,UserName=dt.EmployeeName,NetEffort=dt.Effort,Leave=dt.Leave});
            //}
           
            return View(leaveTracklist.OrderBy(m=>m.UserName).AsQueryable());
        }

        public async Task<ActionResult> submit()
        {

            IFormatProvider enUKDateFormat = new CultureInfo("en-GB").DateTimeFormat;

            DateTime testdate = DateTime.ParseExact(Request.Form.Get("datepicker").ToString(), "dd/MM/yyyy", enUKDateFormat);

            //DateTime testdate = DateTime.Today.AddDays(-1);

            //DateTime testdate = DateTime.Parse(receiveddate.ToString("dd/MM/yyyy"));
           
            try
            {
                PMOService.PMOServiceClient objpmoservice = new PMOService.PMOServiceClient();

                var employeeleavestatus = await objpmoservice.GetPossibleLeaveEntryAsync(testdate);

                ViewBag.DateValue = testdate;

                List<LeaveTracker> leaveTracklist = new List<LeaveTracker>();

                foreach (var item in employeeleavestatus)
                {
                    string userId = item.Key;

                    var dt = employeeleavestatus[userId];

                    var logTransaction = objpmoservice.GetLogTransacion(testdate, testdate, int.Parse(userId));

                    var dtLogDetails = logTransaction[testdate];

                    List<logDetails> logdetailslist = new List<logDetails>();

                    foreach (var logitem in dtLogDetails)
                    {
                        logdetailslist.Add(new logDetails { LogTime = logitem.Date, LogType = logitem.Direction });
                    }

                    leaveTracklist.Add(new LeaveTracker { UserId = userId, UserName = dt.EmployeeName, NetEffort = dt.Effort, Leave = dt.Leave, LogDetailsList = logdetailslist });
                }

                TempData["TrackList"] = leaveTracklist;

                return View("LoadSearchScreen", leaveTracklist.OrderBy(m => m.UserName).AsQueryable());
                //return View("LoadSearchScreen", leaveTracklist);
            }
            catch (Exception ex)
            {

                return null;

            }
          

            
        }

        public ActionResult showPopUp(String userId)
        {

            String idtoProcess = (String)userId;

            List<LeaveTracker> leavetrackList = (List<LeaveTracker>)TempData["TrackList"];

            TempData["TrackList"] = leavetrackList;

            TempData.Keep("TrackList");

            //DateTime startdate = (DateTime)TempData["CurrentStartDate"];

            //TempData.Keep("CurrentStartDate");

            var objloglist = (from s in leavetrackList where s.UserId == idtoProcess select s);

            

            List<logDetails> Loglist = new List<logDetails>();



            foreach (var item in objloglist)
            {
                Loglist = item.LogDetailsList;
            }

            if (Loglist.Count > 0)
            {
                return PartialView(Loglist.AsQueryable());
            }
            else
                return null;

           
        }

    }
}
  