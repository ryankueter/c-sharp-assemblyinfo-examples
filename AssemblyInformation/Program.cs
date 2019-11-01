/*
 * Author: Ryan Kueter
 * Copyright 2019 Ryan Kueter.
 */
using System;
using System.Reflection;

namespace AssemblyInformation
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// The version number follows the following format:
        /// {Major version}.{Minor version}.{Build Number}.{Revision}
        /// * Major release: new features and braking changes.
        /// * Minor release: smaller changes.
        /// * Build number: allows developers to track the build.
        /// * Revision: patches.
        /// </summary>
        static void GetInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("Full name: {0}", assembly.FullName);
            AssemblyName name = assembly.GetName();
            Console.WriteLine("Major Version: {0}", name.Version.Major);
            Console.WriteLine("Minor Version: {0}", name.Version.Minor);
            Console.WriteLine("In global assembly cache: {0}", assembly.GlobalAssemblyCache);
            foreach (Module assemblyModule in assembly.Modules)
            {
                Console.WriteLine("  Module: {0}", assemblyModule.Name);
                foreach (Type moduleType in assemblyModule.GetTypes())
                {
                    Console.WriteLine("     Type: {0}", moduleType.Name);
                    foreach (MemberInfo member in moduleType.GetMembers())
                    {
                        Console.WriteLine("        Member: {0}", member.Name);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
