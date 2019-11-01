/*
 * Author: Ryan Kueter
 * Copyright 2019 Ryan Kueter.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;


namespace AssemblyInformation
{
    class AssemblyInformationExample
    {
        // System.Reflection
        static Assembly assembly = Assembly.GetExecutingAssembly();

        // System.Diagnostics
        static FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

        void Run()
        {
            Console.WriteLine(GetFileName2());
            Console.WriteLine(GetFileName());
            Console.WriteLine(GetFileDirectory());
            Console.WriteLine(GetTitle());
            Console.WriteLine(GetProductName());
            Console.WriteLine(GetFileVersion());
            Console.WriteLine(GetLegalCopyright());
            Console.WriteLine(GetCompanyName());
            Console.WriteLine(GetLegalTrademarks());
            Console.WriteLine(GetComments());
            Console.WriteLine(GetCurrentAssemblyVersion());
            CompareVersions();
            Console.ReadKey();
        }


        static string GetFileName2()
        {
            // Assembly.GetExecutingAssembly().Location
            return Path.GetFileNameWithoutExtension(assembly.FullName);
        }
        static string GetFileName()
        {
            // Path.GetDirectoryName(fileInfo.FileName)
            return fileInfo.FileName;
        }
        static string GetFileDirectory()
        {
            return Path.GetDirectoryName(fileInfo.FileName);
        }
        static string GetTitle()
        {
            return fileInfo.FileDescription;
        }
        static string GetProductName()
        {
            return fileInfo.ProductName;
        }
        static string GetFileVersion()
        {
            return fileInfo.FileVersion;
        }
        static string GetLegalCopyright()
        {
            return fileInfo.LegalCopyright;
        }
        static string GetCompanyName()
        {
            return fileInfo.CompanyName;
        }
        static string GetLegalTrademarks()
        {
            return fileInfo.LegalTrademarks;
        }
        static string GetComments()
        {
            return fileInfo.Comments;
        }
        static string GetCurrentAssemblyVersion()
        {
            // Get the version of the current executing assembly. 
            // Assembly.GetExecutingAssembly().GetName().Version

            Assembly assem = Assembly.GetEntryAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;
            return $"Application {assemName.Name}, Version {ver.ToString()}";
        }
        static string GetExternalAssemblyVersion()
        {
            // Get the version of an external executing assembly. 
            string filename = ".\\StringLibrary.dll";
            Assembly assem = Assembly.ReflectionOnlyLoadFrom(filename);
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version;
            return $"Application {assemName.Name}, Version {ver.ToString()}";
        }
        static void CompareVersions()
        {
            Version v1 = new Version(2, 0, 300, 205);
            Version v2 = new Version("2.0.251.1000");

            string msg = null;
            msg += string.Format("Version {0} is ", v1);
            switch (v1.CompareTo(v2))
            {
                case 0:
                    msg += string.Format("the same as");
                    break;
                case 1:
                    msg += string.Format("later than");
                    break;
                case -1:
                    msg += string.Format("earlier than");
                    break;
            }
            msg += string.Format(" Version {0}.", v2);

            Console.WriteLine(msg);
            // The example displays the following output: 
            //       Version 2.0 is earlier than Version 2.1.
        }
    }
}
