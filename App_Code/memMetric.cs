using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///memMetric 的摘要说明
/// </summary>
public class memMetric
{

    public float mem;
    public string time;
	public memMetric(float mem, string time)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        this.mem = mem;
        this.time = time;
	}
}