using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VPNDetector
{
    public class ProcessFinder
    {
        public bool found = false;
        public ProcessFinder(string procName)
        {
            Process[] procs = Process.GetProcesses();

            procs = Process.GetProcesses();
            if (procName != "")
            {
                foreach (Process proc in procs)
                {
                    if (proc.ProcessName == procName)
                    {
                        found = true; // found the process.
                    }
                    else
                    {
                    }
                }
            }
        }

        public string[] GetProcList()
        {
            List<string> strs = new List<string>();

            Process[] procs = Process.GetProcesses();
            procs = Process.GetProcesses();
            foreach (Process proc in procs)
            {
                strs.Add(proc.ProcessName);
            }

            return strs.ToArray();
        }
    }
}
