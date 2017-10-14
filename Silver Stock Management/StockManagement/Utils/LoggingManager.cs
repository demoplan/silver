using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

public static class LoggingManager
{
    public class FileManager
    {
        public static FileStream FullAccessStream(string sFilename)
        {
            return FullAccessStream(sFilename, 1024, FileOptions.None);
        }

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public static FileStream FullAccessStream(string sFilename, Int32 nBufferSize, FileOptions options)
        {
            SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            NTAccount acct = sid.Translate(typeof(NTAccount)) as NTAccount;
            string sEveryoneAccount = acct.ToString();
            FileSecurity fSecurity = new FileSecurity();
            fSecurity.AddAccessRule(new FileSystemAccessRule(sEveryoneAccount, FileSystemRights.FullControl, AccessControlType.Allow));
            FileStream fs = File.Create(sFilename, nBufferSize, options, fSecurity);
            return fs;
        }
    }
    public static Int32 settingLogLevel;
    public static string logDir = Application.StartupPath + "\\Log";
    // Synchronize this method to prevent threading issues
    [MethodImplAttribute(MethodImplOptions.Synchronized)]
    public static void WriteToLog(Int32 loglevel, string message)
    {
        if (loglevel <= settingLogLevel)
        {
            if ((!Directory.Exists(logDir)))
            {
                Directory.CreateDirectory(logDir);
            }
            if ((message != null) && (logDir != null) && (logDir.Length > 0))
            {
                string filename = logDir + "\\error_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".log";
                // Open today's file and append the error to the end of it. Note that the Append method will create the file if it does not already exist. Need to create the file and grant RW permissions to "Everyone" so that all users are logged.
                if ((!File.Exists(filename)))
                {
                    FileStream fs = FileManager.FullAccessStream(filename);
                    fs.Close();
                }
                TextWriter tw = File.AppendText(filename);
                tw.WriteLine(DateTime.Now.ToShortTimeString().ToString().PadRight(7) + " :: " + message);
                tw.Close();
            }
        }
    }
}