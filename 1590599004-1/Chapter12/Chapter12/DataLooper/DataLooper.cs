﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter12
{
    class DataLooper
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
               contactname
            from
               customers
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // open connection
                conn.Open();

                // create command
                SqlCommand cmd = new SqlCommand(sql, conn);

                // create data reader
                SqlDataReader rdr = cmd.ExecuteReader();

                // loop through result set
                while (rdr.Read())
                {
                    // print one row at a time
                    Console.WriteLine("{0}", rdr[0]);
                }

                // close data reader
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                //close connection
                conn.Close();
            } 
        }
    }
}

