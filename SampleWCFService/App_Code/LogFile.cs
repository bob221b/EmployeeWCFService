using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LogFile
/// </summary>
public class LogFile
{
    public LogFile()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void WriteToFile(string Message)
    {

        string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
        string changeext;
        FileInfo Fi;

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string filepath1 = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\WCFServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + DateTime.Now.TimeOfDay.TotalSeconds.ToString() + ".txt";
        string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\WCFServiceLog.txt";
        Fi = new FileInfo(filepath);

        if (!File.Exists(filepath))
        {
            // Create a file to write to.   
            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.WriteLine(Message);
            }

        }
        else
        {
            using (StreamWriter sw = File.AppendText(filepath))
            {
                sw.WriteLine(Message);
            }
        }
        if (File.Exists(filepath))
        {
            long length = Fi.Length;
            if (length > 10000000)
            {
                System.IO.File.Move(filepath, filepath1);
            }
        }

    }
}