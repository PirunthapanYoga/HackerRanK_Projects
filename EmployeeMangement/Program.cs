using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Solution
    {

        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, float> dict = new Dictionary<string, float>();
            List<string> Companies = new List<string>();

            employees.ForEach(delegate (Employee e)
            {
                if(Companies.Contains(e.Company)){
                    dict[e.Company]=(dict[e.Company]+e.Age)/2;
                }else{
                    Console.WriteLine(e.Company);
                    Companies.Add(e.Company);
                    dict.Add(e.Company,e.Age);
                }
            });

            Dictionary<string, int> average = new Dictionary<string, int>();
            Companies.ForEach(delegate (string s){
                average.Add(s, (int)dict[s]);
            });
            return average;
        }
        
        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> countforComp= new Dictionary<string, int>();
            List<string> Companies = new List<string>();

            employees.ForEach(delegate (Employee e)
            {
                if(Companies.Contains(e.Company)){
                    countforComp[e.Company]=(countforComp[e.Company]+1);
                }else{
                    Companies.Add(e.Company);
                    countforComp.Add(e.Company,1);
                }
            });
            return countforComp;
        }
        
        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, Employee> oldAge= new Dictionary<string, Employee>();
            List<string> Companies = new List<string>();

            employees.ForEach(delegate (Employee e)
            {
                if(Companies.Contains(e.Company)){
                    if(e.Age>oldAge[e.Company].Age){
                        oldAge[e.Company]=e;
                    }
                }else{
                    Companies.Add(e.Company);
                    oldAge.Add(e.Company,e);
                }
            });
            return oldAge;
        }

        public static void Main()
        {   
            int countOfEmployees = int.Parse(Console.ReadLine());
            
            var employees = new List<Employee>();
            
            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee { 
                    FirstName = strArr[0], 
                    LastName = strArr[1], 
                    Company = strArr[2], 
                    Age = int.Parse(strArr[3]) 
                    });
            }
            
            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }
            
            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }
            
            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }
    
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}   