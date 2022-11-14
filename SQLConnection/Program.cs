using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            EmployeeModel model = new EmployeeModel();
            while (true)
            {
                Console.WriteLine("1. Cretae Database\n2. Create Table\n3. Insert Record\n4. Delete Record\n5. Retrived Data\n6. Update data");
                int Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        employee.CreateDatabase();
                        break;
                    case 2:
                        employee.CreateTable();
                        break;
                    case 3:
                        Console.WriteLine("Enter Full Name");
                        model.EmpName = Console.ReadLine();
                        Console.WriteLine("Enter Salary");
                        model.Salary = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Age");
                        model.Age = Convert.ToInt32(Console.ReadLine());
                        employee.InsertRecord(model);
                        break;
                    case 4:
                        Console.WriteLine("Enter Full Name");
                        string name1 = Console.ReadLine();
                        employee.DeleteRecord(name1);
                        break;
                    case 5:
                        employee.RetriveData();
                        break;
                    case 6:
                        Console.WriteLine("Enter Full Name");
                        model.EmpName = Console.ReadLine();
                        Console.WriteLine("Enter Salary");
                        model.Salary = Convert.ToDouble(Console.ReadLine());
                        employee.UpdateRecord(model);
                        break;
                }
            }
        }
    }
}
