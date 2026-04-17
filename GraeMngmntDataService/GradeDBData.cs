using GradeMngntModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace GradeMngmntDataService
{
    public class GradeDBData : IGradeMngmntDataService
    {
        private string connStr = "Data Source =localhost\\SQLEXPRESS01; Initial Catalog = StudentGrades; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public GradeDBData()
        {
            sqlConnection = new SqlConnection(connStr);

            addSeeds();
        }

        private void addSeeds()
        {
            var existing = GetGradeLogs();

            if (existing.Count == 0)
            {
                DModels BaseLog = new DModels { logID = Guid.NewGuid(), subject = "AP", FinalGrade = 25.45, studentFullName = "John Doe" };
                

                AddLog(BaseLog);
                
            }
        }

        public void AddLog(DModels gradeLogs)
        {
            var insertStatement = "INSERT INTO TB_BaseTable (LogID, FinalGrade, subject, studentFullname) VALUES (@LogID, @FinalGrade, @subject, @studentFullname)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@LogID", gradeLogs.logID);
            insertCommand.Parameters.AddWithValue("@FinalGrade", gradeLogs.FinalGrade);
            insertCommand.Parameters.AddWithValue("@subject", gradeLogs.subject);
            insertCommand.Parameters.AddWithValue("@studentFullname", gradeLogs.studentFullName);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }


        public List<DModels> GetGradeLogs()
        {
            string selectStatement = "SELECT FinalGrade, subject, studentFullname, LogID FROM TB_BaseTable";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var gradeLogs = new List<DModels>();

            while (reader.Read())
            {

                DModels grdLog = new DModels();
                grdLog.logID = Guid.Parse(reader["LogID"].ToString());
                grdLog.FinalGrade = Convert.ToDouble(reader["FinalGrade"]);
                grdLog.studentFullName = reader["studentFullname"].ToString();
                grdLog.subject = reader["subject"].ToString();


                gradeLogs.Add(grdLog);
            }

            sqlConnection.Close();
            return gradeLogs;
        }

        public void DeleteLog(Guid logToDelete)
        {
            try
            {
                string delStatement = "DELETE FROM TB_BaseTable WHERE LogID = @LogID";

                using (SqlCommand deleteCommand = new SqlCommand(delStatement, sqlConnection))
                {
                    deleteCommand.Parameters.AddWithValue("@LogID", logToDelete);

                    sqlConnection.Open();
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Successfully deleted record with ID: {logToDelete}");
                    }
                    else
                    {
                        Console.WriteLine($"No record found with ID: {logToDelete}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting log: {ex.Message}");
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public void Update(DModels account)
        {
            try
            {
                var updateStatement = "UPDATE TB_BaseTable SET FinalGrade = @FinalGrade, subject = @subject, studentFullname = @studentFullname WHERE LogID = @LogID";

                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@LogID", account.logID);
                updateCommand.Parameters.AddWithValue("@FinalGrade", account.FinalGrade);
                updateCommand.Parameters.AddWithValue("@subject", account.subject);
                updateCommand.Parameters.AddWithValue("@studentFullname", account.studentFullName);

                sqlConnection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Successfully updated record with ID: {account.logID}");
                }
                else
                {
                    Console.WriteLine($"No record found with ID: {account.logID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating record: {ex.Message}");
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }


    }
}
