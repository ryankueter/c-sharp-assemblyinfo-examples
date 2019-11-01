/*
 * Author: Ryan Kueter
 * Copyright 2019 Ryan Kueter.
 */
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyInformation
{
    /// <summary>
    /// Managed Extensibility Framework (MEF)
    /// Allows you to search the classes in an assembly and find components that implement particular interfaces.
    /// </summary>
    class MEFExample
    {

        void Run()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            List<Type> AccountTypes = new List<Type>();

            foreach (Type t in thisAssembly.GetTypes())
            {
                if (t.IsInterface)
                    continue;

                if (typeof(IAccount).IsAssignableFrom(t))
                {
                    AccountTypes.Add(t);
                }
            }

            foreach (Type t in AccountTypes)
                Console.WriteLine(t.Name);

            Console.ReadKey();
        }

        void RunLinqExample()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            var AccountTypes = from type in thisAssembly.GetTypes()
                               where typeof(IAccount).IsAssignableFrom(type) && !type.IsInterface
                               select type;

            foreach (Type t in AccountTypes)
                Console.WriteLine(t.Name);

            Console.ReadKey();

        }

        public interface IAccount
        {
            void PayInFunds(decimal amount);
            bool WithdrawFunds(decimal amount);
            decimal GetBalance();
        }

        public class BankAccount : IAccount
        {
            protected decimal balance = 0;

            public virtual bool WithdrawFunds(decimal amount)
            {
                if (balance < amount)
                {
                    return false;
                }
                balance = balance - amount;
                return true;
            }

            void IAccount.PayInFunds(decimal amount)
            {
                balance = balance + amount;
            }

            decimal IAccount.GetBalance()
            {
                return balance;
            }
        }

        public class BabyAccount : BankAccount, IAccount
        {
            public override bool WithdrawFunds(decimal amount)
            {
                if (amount > 10)
                {
                    return false;
                }

                if (balance < amount)
                {
                    return false;
                }
                balance = balance - amount;
                return true;
            }
        }

    }
}
