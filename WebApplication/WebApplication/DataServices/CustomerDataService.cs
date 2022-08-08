using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.DataServices
{
    
    public class CustomerDataService
    {

        SqlConnection _db;
        public CustomerDataService(SqlConnection db)
        {
            _db = db;
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            string query = "select CustomerId, Name, Phone, Discount, Sex, Remarks, Status, case when Sex = 1 then 'Male' else 'Female' end as GenderName  from Customers";
            SqlCommand cmd = new SqlCommand(query, _db);
            _db.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Customer c = new Customer()
                {

                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                    Discount = reader.GetDouble(reader.GetOrdinal("Discount")),
                    Sex = reader.GetInt32(reader.GetOrdinal("Sex")),
                    Remarks = reader.GetString(reader.GetOrdinal("Remarks")),
                    Status = reader.GetBoolean(reader.GetOrdinal("Status")),
                    GenderName = reader.GetString(reader.GetOrdinal("GenderName")),
                };
                customers.Add(c);
            }
            _db.Close();
            return customers;
        }

        public void Update(Customer c)
        {
            string query = $"Update Customers Set  CustomerId ='{c.CustomerId}', Name ='{c.Name}',Phone = '{c.Phone}', Sex = '{c.Sex}', Discount = '{c.Discount}', LandPhone = '{c.LandPhone}', PostOffice ='{c.PostOffice}', PostCode ='{c.PostCode}', Thana ='{c.Thana}', Zilla ='{c.Zilla}', Address ='{c.Address}', PermanentAddress ='{c.PermanentAddress}', Remarks ='{c.Remarks}' where CustomerId = {c.CustomerId} ";
            SqlCommand cmd = new SqlCommand(query, _db);
            _db.Open();
            cmd.ExecuteNonQuery();
            _db.Close();
        }

        public  void UpdateStatus(int id)
        {
            string query = $"Update Customers Set  Status = '{true}' where CustomerId = {id}";
            SqlCommand cmd = new SqlCommand(query, _db);
            _db.Open();
            cmd.ExecuteNonQuery();
            _db.Close();
        }

        public Customer GetById(int id)
        {
            Customer c = null;
            string query = $"select * from Customers Where CustomerId={id}";
            SqlCommand cmd = new SqlCommand(query, _db);
            _db.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                c = new Customer()
                {

                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                    LandPhone = reader.GetString(reader.GetOrdinal("LandPhone")),
                    Sex = reader.GetInt32(reader.GetOrdinal("Sex")),
                    Discount = reader.GetDouble(reader.GetOrdinal("Discount")),
                    PostOffice = reader.GetString(reader.GetOrdinal("PostOffice")),
                    PostCode = reader.GetString(reader.GetOrdinal("PostCode")),
                    Thana = reader.GetString(reader.GetOrdinal("Thana")),
                    Zilla = reader.GetString(reader.GetOrdinal("Zilla")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    PermanentAddress = reader.GetString(reader.GetOrdinal("PermanentAddress")),
                    Remarks = reader.GetString(reader.GetOrdinal("Remarks")),
                    //Status = reader.GetBoolean(reader.GetOrdinal("Status")),

                };
            }
            _db.Close();
            return c;
        }

        public void  Insert(Customer c)
        {
            string query = "Insert into Customers values(@customerId,@name,@discount,@phone,@sex,@landphone,@postOffice,@postCode,@thana,@zilla,@address,@permanentAddress,@remarks, @status)";
            SqlCommand cmd = new SqlCommand(query, _db);
            cmd.Parameters.AddWithValue("@customerId", c.CustomerId);
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@discount", c.Discount);
            cmd.Parameters.AddWithValue("@phone", c.Phone);
            cmd.Parameters.AddWithValue("@sex", c.Sex );
            cmd.Parameters.AddWithValue("@landphone", c.LandPhone);
            cmd.Parameters.AddWithValue("@postOffice", c.PostOffice);
            cmd.Parameters.AddWithValue("@postCode", c.PostCode);
            cmd.Parameters.AddWithValue("@thana", c.Thana);
            cmd.Parameters.AddWithValue("@zilla", c.Zilla);
            cmd.Parameters.AddWithValue("@address", c.Address);
            cmd.Parameters.AddWithValue("@permanentAddress", c.PermanentAddress);
            cmd.Parameters.AddWithValue("@remarks", c.Remarks);
            cmd.Parameters.AddWithValue("@status", false);
            _db.Open();
            cmd.ExecuteNonQuery();
            _db .Close();
        }
    }
}
