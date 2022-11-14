using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnection
{
    internal class Employee
    {
        public void CreateDatabase()
        {
            try
            {
                //SQL Covvection make a connection with the database
                //datasource-servername
                SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-P69H21L2; Initial Catalog=master; Integrated Security=true");
                connection.Open();
                //SQL command is used to excute the sql statements
                SqlCommand cmd = new SqlCommand("Create database Employee", connection);
                //Executenonquery is used to execute the sql queries
                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee database created successfully");
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-P69H21L2; Initial Catalog=Employee; Integrated Security=true");
        public void CreateTable()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Create table EmployeeData(EmpId int identity(1,1) primary key, EmpName varchar(200), Salary bigint, Age int)", connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee table created successfully");
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void InsertRecord(EmployeeModel emp)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("InsertRecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", emp.EmpName);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record inserted successfully");
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteRecord(string name)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("deleterecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record deleted successfully");
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RetriveData()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("RetriveData", connection);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var id = Convert.ToInt64(sdr["EmpId"]);
                    string name = (string)sdr["EmpName"];
                    var salary = Convert.ToDouble(sdr["Salary"]);
                    var age = Convert.ToInt32(sdr["Age"]);
                    Console.WriteLine("Emp ID = {0} | Emp Name = {1} | Salary = {2} | Age = {3}", id,name,salary,age);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateRecord(EmployeeModel emp)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateRecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", emp.EmpName);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record updated successfully");
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
