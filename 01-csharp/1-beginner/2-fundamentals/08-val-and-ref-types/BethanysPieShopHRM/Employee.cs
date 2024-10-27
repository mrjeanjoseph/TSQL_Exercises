using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM
{
    internal class Employee
    {
        public string firstName;
        public string lastName;
        public string email;

        public int numberOfHoursWorked;
        public double wage;
        public double hourlyRate;
        public EmployeeType employeeType;

        public DateTime birthDay;

        const int minimalHoursWorkedUnit = 1;

        public Employee(string first, string last, string em, DateTime bd, double rate, EmployeeType empType)
        {
            firstName = first;
            lastName = last;
            email = em;
            birthDay = bd;
            hourlyRate = rate;
            employeeType = empType;
        }

        public Employee(string first, string last, string em, DateTime bd) : this(first, last, em, bd, 0, EmployeeType.StoreManager)
        {
        }

        public void PerformWork()
        {
            PerformWork(minimalHoursWorkedUnit);
        }

        public void PerformWork(int numberOfHours)
        {
            numberOfHoursWorked += numberOfHours;

            Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHours} hour(s)!");
        }

        public int CalculateBonus(int bonus)
        {

            if (numberOfHoursWorked > 10)
                bonus *= 2;

            Console.WriteLine($"The employee got a bonus of {bonus}");
            return bonus;
        }

        //public int CalculateBonusAndBonusTax(int bonus, ref int bonusTax)
        //{

        //    if (numberOfHoursWorked > 10)
        //        bonus *= 2;

        //    if (bonus >= 200)
        //    {
        //        bonusTax = bonus / 10;
        //        bonus -= bonusTax;
        //    }

        //    Console.WriteLine($"The employee got a bonus of {bonus} and the tax on the bonus is {bonusTax}");
        //    return bonus;
        //}

        public int CalculateBonusAndBonusTax(int bonus, out int bonusTax)
        {
            bonusTax = 0;
            if (numberOfHoursWorked > 10)
                bonus *= 2;

            if (bonus >= 200)
            {
                bonusTax = bonus / 10;
                bonus -= bonusTax;
            }

            Console.WriteLine($"The employee got a bonus of {bonus} and the tax on the bonus is {bonusTax}");
            return bonus;
        }


        public double ReceiveWage(bool resetHours = true)
        {
            if (employeeType == EmployeeType.Manager)
            {
                Console.WriteLine($"An extra was added to the wage since {firstName} is a manager!");
                wage = numberOfHoursWorked * hourlyRate * 1.25;
            }
            else
            {
                wage = numberOfHoursWorked * hourlyRate;
            }

            Console.WriteLine($"{firstName} {lastName} has received a wage of {wage} for {numberOfHoursWorked} hour(s) of work.");

            if (resetHours)
                numberOfHoursWorked = 0;

            return wage;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t{lastName}\nEmail: \t\t{email}\nBirthday: \t{birthDay.ToShortDateString()}\n");
        }
    }
}
