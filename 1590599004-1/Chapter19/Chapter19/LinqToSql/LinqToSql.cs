﻿using System;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Chapter19
{
    [Table]
    public class Customers
    {
        [Column]
        public string customerId;
        [Column]
        public string companyName;
        [Column]
        public string city;
        [Column]
        public string country;
    }

    class LinqToSql
    {
        static void Main(string[] args)
        {
            // connection string
            string connString = @"
            server = .\sqlexpress;
            integrated security = true;
            database = northwind
         ";

            // create data context 
            DataContext db = new DataContext(connString);

            // create typed table 
            Table<Customers> customers = db.GetTable<Customers>();

            // query database
            var custs =
               from c in customers
               where
               c.country == "USA"
               orderby
               c.city
               select
                  c
            ;

            // display customers
            foreach (var c in custs)
                Console.WriteLine(
                   "{0}, {1}, {2}, {3}",
                   c.customerId,
                   c.companyName,
                   c.city,
                   c.country
                );
        }
    }
}
