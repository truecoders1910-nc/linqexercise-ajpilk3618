using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            var numbers = new List<int>
            { 1,2,3,4,5,6,7,8,9,0};
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            int sum = numbers.Sum();
            Console.WriteLine(sum);

            Console.WriteLine(numbers.Average());


            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("");
            var desc = numbers.OrderByDescending(num => num);
            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }
            var asc = numbers.OrderBy(num => num);
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }



            //Print to the console only the numbers greater than 6
            Console.WriteLine("");
            IEnumerable<int> greaterThan6 = numbers.OrderByDescending(num => num > 6).Take(3); 
            foreach (var num in greaterThan6)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("");
            IEnumerable<int> print4 = numbers.OrderBy(num => num).Take(4);
            foreach (var num in print4)
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("");
            numbers[4] = 24;
            IEnumerable<int> age = numbers.OrderByDescending(num => num);
            foreach (var num in age)
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("");

            var FirstNames = 
            employees.OrderBy(x => x.FirstName).Where(names => employees.Any(name => names.FirstName.StartsWith("S") || names.FirstName.StartsWith("C")));
            
            foreach (var person in FirstNames)
            {
                Console.WriteLine(person.FullName);
            }


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("");

            var NameAge = employees.OrderBy(x => x.Age).ThenBy(x => x.FirstName).Where(ageName => employees.Any(ageNames => ageName.Age > 26));
            foreach (var item in NameAge)
            {
                Console.WriteLine(item.Age + " " + item.FullName);
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("");
            
            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience));
            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience));


            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("");

            var emp = new Employee("AJ", "Pilkerton", 24, 0);
            var newList = employees.Append(emp).ToList();
            foreach (var item in newList)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age} {item.YearsOfExperience}");
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
