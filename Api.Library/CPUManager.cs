using System;
using System.Diagnostics;

public class CPUManager
{
    public TimeSpan GetCPUInfo()
    {
        Process proc = Process.GetCurrentProcess();
        //var mem = proc.WorkingSet64;
        TimeSpan cpu = proc.TotalProcessorTime;
        return cpu;
    }
}