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

        public static List<Researcher> fetchBasicResearcherDetails()
        {
            // name, title, current employment level
            // Implemented like agency class in Tutorial 8
            List<Researcher> researchers = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT given_name, family_name, title, level, current_start, type, id FROM researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Researcher object, to be added to the list
                    //Console.WriteLine("Reading");
                    Researcher res;
                    //res = new Researcher
                    //{
                    //    GivenName = rdr.GetString(0),
                    //    FamilyName = rdr.GetString(1),
                    //    Title = rdr.GetString(2),
                    //    ResearcherPosition = new Position { Start = rdr.GetDateTime(4), level = EmploymentLevel.Student }
                    //};
                    // Check to see if Student or Staff
                    // Manuallt set level to "student" for students as mysql table doesnt have "student" in level enum
                    if (rdr.GetString(5) == "Student")
                    {
                        res = new Student
                        {
                            GivenName = rdr.GetString(0),
                            FamilyName = rdr.GetString(1),
                            Title = rdr.GetString(2),
                            ResearcherPosition = new Position { Start = rdr.GetDateTime(4), level = EmploymentLevel.Student },
                            id = rdr.GetInt32(6),
                        };
                    }
                    else // Must be staff instead
                    {
                        res = new Staff
                        {
                            GivenName = rdr.GetString(0),
                            FamilyName = rdr.GetString(1),
                            Title = rdr.GetString(2),
                            ResearcherPosition = new Position { Start = rdr.GetDateTime(4), level = ParseEnum<EmploymentLevel>(rdr.GetString(3)) },
                            id = rdr.GetInt32(6),
                        };
                    }
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

        // Was simpler to pass in old res and update instead of just id and making a new one
        public static Researcher fetchFullResearcherDetails(Researcher res)
        {
           
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT type, unit, campus, email, photo, degree, supervisor_id, level, utas_start, current_start FROM researcher WHERE id =?researcherID", conn);
                cmd.Parameters.AddWithValue("researcherID", res.id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // If student else staff
                    if (rdr.GetString(1) == "Student")
                    {
                        // Already have given_name, family_name, id, title and position

                        res.School = rdr.GetString(1); // unit
                        res.Campus = rdr.GetString(2); // campus
                        res.Email = rdr.GetString(3); // Email
                        res.Photo = rdr.GetString(4); // Photo URL
                        (res as Student).Degree = rdr.GetString(5); // Student Only
                        (res as Student).SupervisorID = rdr.GetInt32(4); // Student Only
                        res.EarliestStartDate = rdr.GetDateTime(8);
                    }
                    else // Must be staff instead
                    {
                        res.School = rdr.GetString(1);
                        res.Campus = rdr.GetString(2);
                        res.Email = rdr.GetString(3);
                        res.Photo = rdr.GetString(4);
                        res.EarliestStartDate = rdr.GetDateTime(8);
                        
                    }
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

            return res;
        }

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
