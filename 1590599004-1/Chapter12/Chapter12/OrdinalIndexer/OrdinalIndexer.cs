﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter12
{
    class OrdinalIndexer
    {
        static void Main(string[] args)
        {
            // connection string
            string connString = @"
            server = .\sqlexpress;
            integrated security = true;
            database = northwind
         ";

            // query
            string sql = @"
            select
               companyname,
               contactname
            from
               customers
            where
               contactname like 'M%'
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // Open connection
                conn.Open();

                // create command
                SqlCommand cmd = new SqlCommand(sql, conn);

                // create data reader
                SqlDataReader rdr = cmd.ExecuteReader();

                // print headings
                Console.WriteLine("\t{0}   {1}",
                   "Company Name".PadRight(25),
                   "Contact Name".PadRight(20));

                Console.WriteLine("\t{0}   {1}",
                   "============".PadRight(25),
                   "============".PadRight(20));

                // loop through result set
                while (rdr.Read())
                {
                    Console.WriteLine(" {0} | {1}",
                       rdr[0].ToString().PadLeft(25),
                       rdr[1].ToString().PadLeft(20));
                }

                // close reader
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            } 
        }
    }
}



