using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Threading;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{
    //public static Thread getServerInfo=null;
    //public static ConcurrentQueue<cpuMetric> cpuinfo = new ConcurrentQueue<cpuMetric>();
    //public static ConcurrentQueue<memMetric> meminfo = new ConcurrentQueue<memMetric>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*if (getServerInfo == null)
            {
                getServerInfo = new Thread(new ParameterizedThreadStart(AddCPUqueue));
                //getServerInfo.Start(cpuinfo);
            }*/
           /* if (Request.RequestType.ToUpper() == "POST")
            { }
            else
            {
                //Response.Write(GetCpuInfo());
                //Response.Clear();             
                Response.Write(GetCpuInfo().ToString());
                // Response.Flush();
                //Response.End();
                //Context.Response.Write(GetCpuInfo());
            }*/
        }

    }

    /*public static void AddCPUqueue(object siqueue)
    {
        ConcurrentQueue<cpuMetric> queue = siqueue as ConcurrentQueue<cpuMetric>;
        ConcurrentQueue<memMetric> mem_queue = meminfo;
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter memCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        while(true)
        {
            long currentTicks = DateTime.Now.Ticks;
            DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long currentMillis = (currentTicks - dtFrom.Ticks)/10000;
            queue.Enqueue(new cpuMetric(cpuCounter.NextValue(), currentMillis.ToString()));
            mem_queue.Enqueue(new memMetric(memCounter.NextValue(), currentMillis.ToString()));
             System.Diagnostics.Debug.WriteLine("添加成功");
             System.Diagnostics.Debug.WriteLine(cpuinfo.Count());
             if (cpuinfo.Count() >= 5)
             {
                 for (int count = 0; count < 5; count++)
                 {
                     cpuMetric temp;
                     memMetric temp2;
                     cpuinfo.TryDequeue(out temp);
                     meminfo.TryDequeue(out temp2);
                 }
                 
                     getServerInfo = null;
                 return;
             }
            Thread.Sleep(5000);
        }
    }

    public static void AddMEMInfo(object siqueue)
    {
        ConcurrentQueue<memMetric> queue = siqueue as ConcurrentQueue<memMetric>;
        PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available MBytes");
        while (true)
        {
            queue.Enqueue(new memMetric(memCounter.NextValue(), DateTime.Now.ToString()));
            Thread.Sleep(1000);
        }
    }

    [WebMethod]
    public static string GetCpuInfo()
    {
        if (getServerInfo == null)
        {
            getServerInfo = new Thread(new ParameterizedThreadStart(AddCPUqueue));
            getServerInfo.Start(cpuinfo);
        }
        string data = "";
        cpuMetric cpu_detail=null;
        System.Diagnostics.Debug.WriteLine("获取的大小:" + _Default.cpuinfo.Count());
        _Default.cpuinfo.TryDequeue(out cpu_detail);
        if (cpu_detail == null)
        {
            return "1|1";
        }
        data =data + cpu_detail.cpu.ToString() + "|";
        data =data + cpu_detail.time.ToString();
        return data;
    }

    [WebMethod]
    public static string GetMemInfo()
    {
        string data = "";
        memMetric mem_detail = null;
        System.Diagnostics.Debug.WriteLine("获取的大小:" + _Default.cpuinfo.Count());
        int repeat = 3;
        while (mem_detail == null && repeat > 0)
        {
            _Default.meminfo.TryDequeue(out mem_detail);
            repeat--;
        }
        if (mem_detail == null)
        {
            return "0|0";
        }
        data = data + mem_detail.mem.ToString() + "|";
        data = data + mem_detail.time.ToString();
        return data;
    }*/

    [WebMethod]
    public static string ReGetCpuInfo() //获取cpu使用率
    {
        PerformanceCounter cpucounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        float cpu = 0;
        while (cpu == 0)
        {
            cpu = cpucounter.NextValue();
            Thread.Sleep(500);
        }
            
        return cpu.ToString();

    }
    [WebMethod]
    public static  string ReGetMemInfo()//获取内存使用率
    {
        PerformanceCounter memCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        memCounter.NextValue();
        return memCounter.NextValue().ToString();
    }
}