/*
 * Author: Ryan Kueter
 * Copyright 2019 Ryan Kueter.
 */
using System.Windows.Forms;

namespace AssemblyInformation
{
    public class ApplicationInfo
    {
        public string ExecutablePath { get; set; }
        public string PWD { get; set; }

        public ApplicationInfo()
        {
            ExecutablePath = Application.ExecutablePath;
            PWD = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        }
    }
}
