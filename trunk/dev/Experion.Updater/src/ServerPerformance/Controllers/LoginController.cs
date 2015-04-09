using Experion.TTS.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerPerformance.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult LoadLogin()
        {
            return View();
        }
        public ActionResult LoadServerStatusScreen()
        {
         ADService adservice =new ADService();
         FileStream fs1 = new FileStream(Server.MapPath("~") + "/testfile.txt", FileMode.Create, FileAccess.Write);
         StreamWriter writer = new StreamWriter(fs1);

         string username = Request.Form.Get("UserName").ToString();
         string password = Request.Form.Get("Password").ToString();

         if (username == "" || password == "")
         {
             TempData["InvalidCredentials"] = "Invalidentries";

             return RedirectToAction("LoadLogin");
         }
         else
         {


             dynamic validUser = adservice.Authenticate(username, password, writer);
             
             if (validUser.status)
             {
                 this.Session["Userlogin"] = username;
                 return RedirectToAction("ServerStatus", "Status", null);

             }
             else
             {
                 if (validUser.failurereason.ToString().ToUpper().Trim() == "The user name or password is incorrect.".ToString().ToUpper().Trim())
                 {

                     TempData["InvalidCredentials"] = validUser.failurereason;

                 }
                 else
                 {




                     fs1 = new FileStream(Server.MapPath("~") + "/testfile.txt", FileMode.Append, FileAccess.Write);
                        writer = new StreamWriter(fs1);
                        writer.WriteLine(Environment.NewLine + "---Second Attempt--");
                          dynamic retrylogin=adservice.Authenticate(username, password, writer);
                          if (retrylogin.status != true && retrylogin.failurereason.ToString().ToUpper().Trim() != "The user name or password is incorrect.".ToString().ToUpper().Trim())
                          {
                              TempData["NotOperational"] = validUser.failurereason; 
                          }
                          else if (retrylogin.status)
                          {
                              this.Session["Userlogin"] = username;
                              return RedirectToAction("ServerStatus", "Status", null);
                          }

                       
                     

                 }


                 return RedirectToAction("LoadLogin");
             }
         }
            

            
        }
    }
}
