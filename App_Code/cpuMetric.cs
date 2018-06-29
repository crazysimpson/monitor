using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///cpuMetric 的摘要说明
/// </summary>
public class cpuMetric
{
    public float cpu;
    public string time;
	public cpuMetric(float cpu, string time )
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        this.cpu = cpu;
        this.time = time;
	}
}