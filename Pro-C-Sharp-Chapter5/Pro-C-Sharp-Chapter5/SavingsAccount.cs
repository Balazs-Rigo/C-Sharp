using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter5
{
    // A simple savings account class.
    class SavingsAccount
    {
        // Instance-level data.
        public double currBalance;
        // A static point of data.
        public static double currInterestRate = 0.04;

        // A static constructor!
        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            currInterestRate = 0.04;
        }

        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }
        // Static members to get/set interest rate.
        public static void SetInterestRate(double newRate) =>
         currInterestRate = newRate;
        public static double GetInterestRate() 
        {  return currInterestRate; }
    }
}
