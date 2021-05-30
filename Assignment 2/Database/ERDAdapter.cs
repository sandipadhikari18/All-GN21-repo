using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using Assignment_2.Research;

namespace Assignment_2.Database
{
    abstract class ERDAdapter
    {

        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        private static bool reportingErrors = true;

        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        // TAKEN DIRECTLY FROM TUTORIAL 8/9 CODE
        //Part of step 2.3.3 in Week 9 tutorial. This method is a gift to you because .NET's approach to converting strings to enums is so horribly broken
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static List<Researcher> FetchBasicResearcherDetails()
        {
            // name, title, current employment level
            // Implemented like agency class in Tutorial 8
            List<Researcher> researchers = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select given_name, family_name, title, level, type from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Researcher object, to be added to the list
                    Console.WriteLine("Reading");
                    Researcher res;
                    res = new Researcher
                    {
                        GivenName = rdr.GetString(0),
                        FamilyName = rdr.GetString(1),
                        Title = rdr.GetString(2),
                        ResearcherPosition = new Position { Start = rdr.GetDateTime(4), level = EmploymentLevel.Student }
                    };
                    // Check to see if Student or Staff
                    // Manuallt set level to "student" for students as mysql table doesnt have "student" in level enum
                    //if (rdr.GetString(4) == "Student")
                    //{
                    //    res = new Student
                    //    {
                    //        GivenName = rdr.GetString(0),
                    //        FamilyName = rdr.GetString(1),
                    //        Title = rdr.GetString(2),
                    //        ResearcherPosition = new Position { Start = rdr.GetDateTime(4), level = EmploymentLevel.Student }
                    //    };
                    //} 
                    //else // Must be staff instead
                    //{
                    //    res = new Staff
                    //    {
                    //        GivenName = rdr.GetString(0),
                    //        FamilyName = rdr.GetString(1),
                    //        Title = rdr.GetString(2),
                    //        ResearcherPosition = new Position { Start = rdr.GetDateTime(4), level = ParseEnum<EmploymentLevel>(rdr.GetString(3)) }
                    //    };
                    //}
                    // Add the researcher object to the list
                    researchers.Add(res);
                }
            }
            catch (MySqlException e)
            {
                //Console.WriteLine("Error connecting to database: " + e);
                ReportError("loading staff", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return researchers;
        }
        private static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //public static Researcher fetchFullResearcherDetails(int id)
        //{

        //}

        //public static Researcher completeResearcherDetails(Researcher r)
        //{

        //}

        //public static Publication fetchBasicPublicationDetails(Researcher r)
        //{

        //}
        //public static Publication fetchFullPublicationDetails(Publication p)
        //{

        //}

        //public static Publication completePublicationDetails(Publication p)
        //{

        //}

        //public static int[] fetchPublicationCounts(DateTime from, DateTime to)
        //{

        //}


    }
}
