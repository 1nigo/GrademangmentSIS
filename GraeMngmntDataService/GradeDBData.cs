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
                DModels BaseLog = new DModels { subject = "AP", FinalGrade = 25.45};
                

                AddLog(BaseLog);
                
            }
        }

        public void AddLog(DModels gradeLogs)
        {
            var insertStatement = "INSERT INTO TB_BaseTable VALUES (@FinalGrade, @subject)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@FinalGrade", gradeLogs.FinalGrade);
            insertCommand.Parameters.AddWithValue("@subject", gradeLogs.subject);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }


        public List<DModels> GetGradeLogs()
        {
            string selectStatement = "SELECT FinalGrade, subject FROM TB_BaseTable";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var gradeLogs = new List<DModels>();

            while (reader.Read())
            {
                //deserialize

                DModels grdLog = new DModels();
                grdLog.FinalGrade = Convert.ToDouble(reader["FinalGrade"]);
                grdLog.subject = reader["subject"].ToString();


                gradeLogs.Add(grdLog);
            }

            sqlConnection.Close();
            return gradeLogs;
        }

       

       

        public void Update(DModels Glogs)
        {
            
        }

        


        //public void Update(DModels account)
        //{
        //    sqlConnection.Open();

        //    var updateStatement = $"UPDATE TB_BaseTable SET FinalGrade = @FinalGrade, subject = @subject WHERE AccountId = @AccountId";

        //    SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

        //    updateCommand.Parameters.AddWithValue("@Username", account.Username);
        //    updateCommand.Parameters.AddWithValue("@Password", account.Password);
        //    updateCommand.Parameters.AddWithValue("@AccountId", account.AccountId);
        //    updateCommand.ExecuteNonQuery();

        //    sqlConnection.Close();
        //}


    }
}
