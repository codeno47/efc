using ServerPerformance.EHS;
using ServerPerformance.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace ServerPerformance.Controllers
{
    public class StatusController : Controller
    {

        private static Random random = new Random();

        ServerCollection servercol = new ServerCollection();

        FileStream fs1;

        StreamWriter writer;

        
        
        public ActionResult ServerStatus(ServerCollection servercol)
        {
            using (fs1 = new FileStream(Server.MapPath("~") + "/testfile.txt", FileMode.Append, FileAccess.Write))
            {

                writer = new StreamWriter(fs1);

                if (servercol == null)
                {


                    writer.Write("Started Retrieving performance details at" + DateTime.Now.ToString() + Environment.NewLine);

                    try
                    {

                        servercol = new ServerCollection();
                        try
                        {
                            ServerPerformance.Models.Server serv = LoadDetailsForServer10(writer);
                            serv.ShowServer = true;
                            writer.WriteLine("Current Count of Collection is " + servercol.Count);
                            servercol.Add(serv);
                        }
                        catch (Exception ex)
                        {
                            writer.WriteLine("In Catch section");
                            writer.WriteLine(ex.Message);
                            if (this.Session["Attemptfor10"] == null)
                            {
                                servercol = null;
                                this.Session["Attemptfor10"] = "failed";
                                return RedirectToAction("ServerStatus");
                            }

                        }
                        try
                        {
                            ServerPerformance.Models.Server serv2 = LoadDetailsForServer7(writer);
                            serv2.ShowServer = true;
                            writer.WriteLine("Current Count of Collection is " + servercol.Count);
                            servercol.Add(serv2);
                        }
                        catch (Exception ex)
                        {
                            writer.WriteLine("In Catch section");
                            writer.WriteLine(ex.Message);
                            if (this.Session["Attemptfor7"] == null)
                            {
                                servercol = null;
                                this.Session["Attemptfor7"] = "failed";
                                return RedirectToAction("ServerStatus");
                            }

                        }

                        try
                        {
                            ServerPerformance.Models.Server serv3 = LoadDetailsForServer6(writer);
                            serv3.ShowServer = true;
                            servercol.Add(serv3);

                        }
                        catch (Exception ex)
                        {
                            writer.WriteLine("In Catch section");
                            writer.WriteLine(ex.Message);
                            if (this.Session["Attemptfor6"] == null)
                            {
                                servercol = null;
                                this.Session["Attemptfor6"] = "failed";
                                return RedirectToAction("ServerStatus");
                            }

                        }


                    }
                    catch
                    {

                    }
                    finally
                    {
                        writer.WriteLine("Finiished");
                        writer.Close();

                    }


                }
                else
                {

                    Server serv10 = (from s in servercol where s.Name == "169.254.0.250" select s).FirstOrDefault();
                    var count10 = (from s in servercol where s.Name == "169.254.0.250" && s.ShowServer select s).Count();

                    Server serv7 = (from s in servercol where s.Name == "192.168.1.7" select s).FirstOrDefault();
                    var count7 = (from s in servercol where s.Name == "192.168.1.7" && s.ShowServer select s).Count();


                    Server serv6 = (from s in servercol where s.Name == "192.168.1.6" select s).FirstOrDefault();
                    var count6 = (from s in servercol where s.Name == "192.168.1.6" && s.ShowServer select s).Count();

                    if (count10 == 1)
                    {
                        servercol.Remove(serv10);
                        ServerPerformance.Models.Server serv = LoadDetailsForServer10(writer);
                        serv.ShowServer = true;
                        servercol.Insert(0, serv);
                    }



                    //ViewData["ServerList"] = serverlist;
                    //Second Server





                    if (count7 == 1)
                    {
                        servercol.Remove(serv7);
                        ServerPerformance.Models.Server serv2 = LoadDetailsForServer7(writer);
                        serv2.ShowServer = true;
                        servercol.Insert(1, serv2);
                    }



                    if (count6 == 1)
                    {
                        servercol.Remove(serv6);
                        ServerPerformance.Models.Server serv3 = LoadDetailsForServer6(writer);
                        serv3.ShowServer = true;
                        servercol.Insert(2, serv3);
                    }


                    //serv2.InitialUsage = double.Parse(((machineinfo2.AvailablePhysicalMemory / machineinfo2.TotalMemory) * 100).ToString());

                }
                return View(servercol);

            }
           
        }

        public ActionResult RefreshGaugeForServer10(bool show10,bool show7,bool show6)
        {
            ServerPerformance.Models.Server serv;

            using (fs1 = new FileStream(Server.MapPath("~") + "/testfile.txt", FileMode.Append, FileAccess.Write))
            {

                writer = new StreamWriter(fs1);

                if (show10)
                {
                    //serv = LoadDetailsForServerSecondry10();
                    serv = LoadDetailsForServer10(writer);
                }
                else if (show7)
                {
                    //serv = LoadDetailsForServerSecondry7();
                    serv = LoadDetailsForServer7(writer);
                }
                else if (show6)
                {
                    //serv = LoadDetailsForServerSecondry6();
                    serv = LoadDetailsForServer6(writer);
                }
                else
                { return null; }


                //serv.Usage = double.Parse((((machineinfo.AvailablePhysicalMemory / machineinfo.TotalMemory) * 100) + random.Next(0, 50)).ToString());

                return PartialView("_PartialPage1", serv);
            }
           
          
        }

        public ActionResult RefreshGaugeForServer7(bool show10, bool show7, bool show6)
        {

            using (fs1 = new FileStream(Server.MapPath("~") + "/testfile.txt", FileMode.Append, FileAccess.Write))
            {
                writer = new StreamWriter(fs1);

                ServerPerformance.Models.Server serv2;

                if (show10)
                {
                    if (show7)
                    {
                        //serv2 = LoadDetailsForServerSecondry7();
                        serv2 = LoadDetailsForServer7(writer);
                    }
                    else if (show6)
                    {
                        //serv2 = LoadDetailsForServerSecondry6();
                        serv2 = LoadDetailsForServer6(writer);
                    }
                    else
                    { return null; }

                }
                else
                {
                    if (show6)
                    {
                        //serv2 = LoadDetailsForServerSecondry6();
                        serv2 = LoadDetailsForServer6(writer);
                    }
                    else
                    { return null; }
                }


                //serv.Usage = double.Parse((((machineinfo.AvailablePhysicalMemory / machineinfo.TotalMemory) * 100) + random.Next(0, 50)).ToString());

                return PartialView("_PartialPage2", serv2);
            }
           
        }

        public ActionResult RefreshGaugeForServer6(bool show10, bool show7, bool show6)
        {
            using (fs1 = new FileStream(Server.MapPath("~") + "/testfile.txt", FileMode.Append, FileAccess.Write))
            {

                writer = new StreamWriter(fs1);

                ServerPerformance.Models.Server serv3;

                if (show6)
                {
                    //serv3 = LoadDetailsForServerSecondry6();
                    serv3 = LoadDetailsForServer6(writer);

                    //serv.Usage = double.Parse((((machineinfo.AvailablePhysicalMemory / machineinfo.TotalMemory) * 100) + random.Next(0, 50)).ToString());

                    return PartialView("_PartialPage3", serv3);
                }
                else
                    return null;
            }
        }


        private  Models.Server LoadDetailsForServer7(StreamWriter writer)
        {
           

                writer.Write("Details of Server 7" + Environment.NewLine);
           

            ServerPerformance.EHS_7.HealthServiceClient serviceclient2 = new ServerPerformance.EHS_7.HealthServiceClient();


           
                writer.WriteLine("Getting Usage Details" + Environment.NewLine);
           
            ServerPerformance.EHS_7.MachineMemoryInfo machineinfo2 = serviceclient2.GetMemoryUsage();

           
                writer.WriteLine("Finished Getting Usage details" + Environment.NewLine);

                writer.WriteLine("Getting Individual details" + Environment.NewLine);
          

            ServerPerformance.EHS_7.MachineProcessInfo machineprocessinfo2 = serviceclient2.GetAllMemoryStatics();

          
                writer.WriteLine("Finished Getting individual details" + Environment.NewLine);
         

            ServerPerformance.Models.Server serv2 = new Server();

            serv2.Name = machineinfo2.MachineName;

           

            //ViewData["ServerList"] = machineprocessinfo.ProcessInfos;

            serv2.processinfolist2 = machineprocessinfo2.ProcessInfos.OrderByDescending(x => x.WorkingSet).ToArray();

            var test = machineprocessinfo2.ProcessInfos;

            serv2.procinfolist = new List<ProcInfo>();

            foreach (ServerPerformance.EHS_7.ProcessInfo item in serv2.processinfolist2)
            {
                double usageindouble = ((item.WorkingSet * 9.53674e-7) / double.Parse(machineinfo2.TotalMemory.ToString()));


                string ProcessUsageinPercentage = (usageindouble * 100).ToString("0.00") + " %";

                serv2.procinfolist.Add(new ProcInfo { Name = item.Name, WorkingSet = ProcessUsageinPercentage });
            }

            serv2.Usage = double.Parse((((machineinfo2.TotalMemory - machineinfo2.AvailablePhysicalMemory) / machineinfo2.TotalMemory) * 100).ToString());

          
                writer.WriteLine("Completed Server7" + Environment.NewLine);
           

            return serv2;
        }

        private  Models.Server LoadDetailsForServer10(StreamWriter writer)
        {
         
                writer.Write("Details of Server 10" + Environment.NewLine);
           
            
            ServerPerformance.EHS.HealthServiceClient serviceclient = new ServerPerformance.EHS.HealthServiceClient();

            
                writer.WriteLine("Getting Usage Details" + Environment.NewLine);
           

            ServerPerformance.EHS.MachineMemoryInfo machineinfo = serviceclient.GetMemoryUsage();

            
                writer.WriteLine("Finished Getting Usage details" + Environment.NewLine);

                writer.WriteLine("Getting Individual details" + Environment.NewLine);
          
            ServerPerformance.EHS.MachineProcessInfo machineprocessinfo = serviceclient.GetAllMemoryStatics();

                writer.WriteLine("Finished Getting individual details" + Environment.NewLine);
          
            ServerPerformance.Models.Server serv = new Server();

            serv.Name = machineinfo.MachineName;

          
            //ViewData["ServerList"] = machineprocessinfo.ProcessInfos;

            serv.processinfolist = machineprocessinfo.ProcessInfos.OrderByDescending(x => x.WorkingSet).ToArray();

            var test = machineprocessinfo.ProcessInfos;

            serv.procinfolist = new List<ProcInfo>();

            foreach (ServerPerformance.EHS.ProcessInfo item in serv.processinfolist)
            {
                double usageindouble = ((item.WorkingSet * 9.53674e-7) / double.Parse(machineinfo.TotalMemory.ToString()));


                string ProcessUsageinPercentage = (usageindouble * 100).ToString("0.00") + " %";

                serv.procinfolist.Add(new ProcInfo { Name = item.Name, WorkingSet = ProcessUsageinPercentage });
            }

            serv.Usage = double.Parse((((machineinfo.TotalMemory - machineinfo.AvailablePhysicalMemory) / machineinfo.TotalMemory) * 100).ToString());

          
                writer.WriteLine("Completed Server10" + Environment.NewLine);
           
            return serv;
        }

        private  Models.Server LoadDetailsForServer6(StreamWriter writer)
        {
           
                writer.Write("Details of Server 6" + Environment.NewLine);
            

            ServerPerformance.EHS_6.HealthServiceClient serviceclient = new ServerPerformance.EHS_6.HealthServiceClient();

           
                writer.WriteLine("Getting Usage Details" + Environment.NewLine);

               
                    ServerPerformance.EHS_6.MachineMemoryInfo machineinfo=new EHS_6.MachineMemoryInfo();

                  
                        try 
	                        {	        
		                        machineinfo = serviceclient.GetMemoryUsage();
	                        }
	                        catch (Exception ex)
	                        {
                                writer.WriteLine(ex.Message);
		                       
	                        }

                       
          
                writer.WriteLine("Finished Getting Usage details" + Environment.NewLine);

                writer.WriteLine("Getting Individual details" + Environment.NewLine);
          

            ServerPerformance.EHS_6.MachineProcessInfo machineprocessinfo = serviceclient.GetAllMemoryStatics();

            
                writer.WriteLine("Finished Getting individual details" + Environment.NewLine);
           
            ServerPerformance.Models.Server serv = new Server();

            serv.Name = machineinfo.MachineName;

            

            //ViewData["ServerList"] = machineprocessinfo.ProcessInfos;

            serv.processinfolist3 = machineprocessinfo.ProcessInfos.OrderByDescending(x => x.WorkingSet).ToArray();

            var test = machineprocessinfo.ProcessInfos;

            serv.procinfolist = new List<ProcInfo>();

            foreach (ServerPerformance.EHS_6.ProcessInfo item in serv.processinfolist3)
            {
                double usageindouble = ((item.WorkingSet * 9.53674e-7) / double.Parse(machineinfo.TotalMemory.ToString()));


                string ProcessUsageinPercentage = (usageindouble * 100).ToString("0.00") + " %";

                serv.procinfolist.Add(new ProcInfo { Name = item.Name, WorkingSet = ProcessUsageinPercentage });
            }

            serv.Usage = double.Parse((((machineinfo.TotalMemory - machineinfo.AvailablePhysicalMemory) / machineinfo.TotalMemory) * 100).ToString());

          
           
                writer.WriteLine("Completed Server6" + Environment.NewLine);
            

            return serv;
        }

        //private  Models.Server LoadDetailsForServerSecondry7()
        //{
          

        //    ServerPerformance.EHS_7.HealthServiceClient serviceclient2 = new ServerPerformance.EHS_7.HealthServiceClient();


          

        //    ServerPerformance.EHS_7.MachineMemoryInfo machineinfo2 = serviceclient2.GetMemoryUsage();

            

        //    ServerPerformance.EHS_7.MachineProcessInfo machineprocessinfo2 = serviceclient2.GetAllMemoryStatics();

           

        //    ServerPerformance.Models.Server serv2 = new Server();

        //    serv2.Name = machineinfo2.MachineName;



        //    //ViewData["ServerList"] = machineprocessinfo.ProcessInfos;

        //    serv2.processinfolist2 = machineprocessinfo2.ProcessInfos.OrderByDescending(x => x.WorkingSet).ToArray();

        //    var test = machineprocessinfo2.ProcessInfos;

        //    serv2.procinfolist = new List<ProcInfo>();

        //    foreach (ServerPerformance.EHS_7.ProcessInfo item in serv2.processinfolist2)
        //    {
        //        double usageindouble = ((item.WorkingSet * 9.53674e-7) / double.Parse(machineinfo2.TotalMemory.ToString()));


        //        string ProcessUsageinPercentage = (usageindouble * 100).ToString("0.00") + " %";

        //        serv2.procinfolist.Add(new ProcInfo { Name = item.Name, WorkingSet = ProcessUsageinPercentage });
        //    }

        //    serv2.Usage = double.Parse((((machineinfo2.TotalMemory - machineinfo2.AvailablePhysicalMemory) / machineinfo2.TotalMemory) * 100).ToString());

          

        //    return serv2;
        //}

        //private  Models.Server LoadDetailsForServerSecondry10()
        //{
           

        //    ServerPerformance.EHS.HealthServiceClient serviceclient = new ServerPerformance.EHS.HealthServiceClient();

            

        //    ServerPerformance.EHS.MachineMemoryInfo machineinfo = serviceclient.GetMemoryUsage();

           
        //    ServerPerformance.EHS.MachineProcessInfo machineprocessinfo = serviceclient.GetAllMemoryStatics();

           

        //    ServerPerformance.Models.Server serv = new Server();

        //    serv.Name = machineinfo.MachineName;



        //    //ViewData["ServerList"] = machineprocessinfo.ProcessInfos;

        //    serv.processinfolist = machineprocessinfo.ProcessInfos.OrderByDescending(x => x.WorkingSet).ToArray();

        //    var test = machineprocessinfo.ProcessInfos;

        //    serv.procinfolist = new List<ProcInfo>();

        //    foreach (ServerPerformance.EHS.ProcessInfo item in serv.processinfolist)
        //    {
        //        double usageindouble = ((item.WorkingSet * 9.53674e-7) / double.Parse(machineinfo.TotalMemory.ToString()));


        //        string ProcessUsageinPercentage = (usageindouble * 100).ToString("0.00") + " %";

        //        serv.procinfolist.Add(new ProcInfo { Name = item.Name, WorkingSet = ProcessUsageinPercentage });
        //    }

        //    serv.Usage = double.Parse((((machineinfo.TotalMemory - machineinfo.AvailablePhysicalMemory) / machineinfo.TotalMemory) * 100).ToString());

          
        //    return serv;
        //}

        //private  Models.Server LoadDetailsForServerSecondry6()
        //{
           

        //    ServerPerformance.EHS_6.HealthServiceClient serviceclient = new ServerPerformance.EHS_6.HealthServiceClient();

           

        //    ServerPerformance.EHS_6.MachineMemoryInfo machineinfo = serviceclient.GetMemoryUsage();

          

        //    ServerPerformance.EHS_6.MachineProcessInfo machineprocessinfo = serviceclient.GetAllMemoryStatics();


        //    ServerPerformance.Models.Server serv = new Server();

        //    serv.Name = machineinfo.MachineName;

           

        //    //ViewData["ServerList"] = machineprocessinfo.ProcessInfos;

        //    serv.processinfolist3 = machineprocessinfo.ProcessInfos.OrderByDescending(x => x.WorkingSet).ToArray();

        //    var test = machineprocessinfo.ProcessInfos;

        //    serv.procinfolist = new List<ProcInfo>();

        //    foreach (ServerPerformance.EHS_6.ProcessInfo item in serv.processinfolist3)
        //    {
        //        if (machineinfo.TotalMemory>0)
        //        {
        //            double usageindouble = ((item.WorkingSet * 9.53674e-7) / double.Parse(machineinfo.TotalMemory.ToString()));


        //            string ProcessUsageinPercentage = (usageindouble * 100).ToString("0.00") + " %";

        //            serv.procinfolist.Add(new ProcInfo { Name = item.Name, WorkingSet = ProcessUsageinPercentage });
        //        }
              
        //    }

        //    if (machineinfo.TotalMemory>0)
        //    {
        //        serv.Usage = double.Parse((((machineinfo.TotalMemory - machineinfo.AvailablePhysicalMemory) / machineinfo.TotalMemory) * 100).ToString());
        //    }
        //    else
        //        serv.Usage = 0;
           

          
        //    return serv;
        //}
     

 
    }
}
