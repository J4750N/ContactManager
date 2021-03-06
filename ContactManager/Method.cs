﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public sealed class Method
    {
        static string ConString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        Method() { }

        static readonly Method instance = new Method();
       
        public static Method Instance
        {
            get { return instance; }
        }

        public List<Person> GetAllContacts()
        {
            List<Person> listPerson = new List<Person>();

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Contacts", con);

                using (SqlDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Person person = new Person();
                        if (Int32.TryParse(reader["Id"].ToString(), out int id))
                        {
                            person.Id = id;
                        }
                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.Phone = reader["Phone"].ToString();
                        person.Email = reader["Email"].ToString();

                        listPerson.Add(person);
                    }
                }
            }

            return listPerson;
        }
        public string AddContact(Person contact)
        {
           

            using (SqlConnection con = new SqlConnection(ConString))
            {
                
                string query = "INSERT INTO DbContactManager.dbo.Contacts (FirstName, LastName, Phone, Email) VALUES";
                query += $"('{contact.FirstName}', '{contact.LastName}', '{contact.Phone}', '{contact.Email}')";
                con.Open();
                SqlCommand cm = new SqlCommand(query, con);
                try
                {
                    cm.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
                
            }

            return "Contact added";
        }
        public string EditContact(Person contact)
        {


            using (SqlConnection con = new SqlConnection(ConString))
            {

                string query = "UPDATE DbContactManager.dbo.Contacts ";
                query += $"SET FirstName='{contact.FirstName}', LastName='{contact.LastName}', Phone='{contact.Phone}', Email='{contact.Email}' ";
                query += $"where id = { contact.Id }";
                con.Open();
                SqlCommand cm = new SqlCommand(query, con);
                try
                {
                    cm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }

            return "Contact updated";
        }
        public string DeleteContact(Person contact)
        {


            using (SqlConnection con = new SqlConnection(ConString))
            {

                string query = "DELETE From DbContactManager.dbo.Contacts ";
                       query += $"where id = { contact.Id }";
                con.Open();
                SqlCommand cm = new SqlCommand(query, con);
                try
                {
                    cm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }

            return "Contact deleted";
        }

    }
}
