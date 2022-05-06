using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var enrollees = ReadCSVFile();
            WriteToCSVFile(enrollees);
            Console.ReadLine();
        }
        static List<Enrollee> ReadCSVFile()
        {
            string path =  @"C:\CSVDemo\Lisp question\CSVReader\Input\Enrollee.csv";
            var enrollees = new List<Enrollee>();
            var file = File.ReadAllLines(path);
            for(int i=1; i < file.Length; i++)
            {
                var values = file[i].Split(",");
                var enrollee = new Enrollee()
                {
                    userId = values[0],
                    firstName = values[1],
                    lastName = values[2],
                    version = Convert.ToInt32(values[3]),
                    insuranceCompany = values[4]
                };
                enrollees.Add(enrollee);                
            }
            return enrollees;
        }

        static void WriteToCSVFile(List<Enrollee> enrollees)
        {
            var companies = enrollees.GroupBy(g => g.insuranceCompany)
                .Select(grp => new { Name = grp.Key, insuranceCompanies = 
                grp.OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .GroupBy(user => user.userId)
                .Select(user => new { enrollee = user.Key, user = 
                user.OrderByDescending(x => x.version).FirstOrDefault()})
                }).ToList();
            
            
            foreach(var company in companies)
            {
                string path = @"C:\CSVDemo\Lisp question\CSVReader\Output\" + company.Name + ".csv";
                
                foreach(var user in company.insuranceCompanies)
                {
                    File.AppendAllText(path, user.enrollee + "," + user.user.firstName + "," + user.user.lastName + "," + user.user.version.ToString() + ","+ company.Name + "\n");
                }
            }
        }
    }    
}
