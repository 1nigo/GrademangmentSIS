using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using GradeMngntModels;

namespace GradeMngmntDataService
{
    public class GradeMngmntJSONdataservice : IGradeMngmntDataService
    {
        private List<DModels> gradeLogs = new List<DModels>();

        private string _jsonFileName;

        public GradeMngmntJSONdataservice()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/GradeData.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (gradeLogs.Count <= 0)
            {
                gradeLogs.Add(new DModels { logID = Guid.NewGuid(), studentFullName = "Inigo Rafael", FinalGrade = 71.82, subject = "Math" });
                

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            try
            {
                var opt = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                };

                string jsonString = JsonSerializer.Serialize(gradeLogs, opt);
                File.WriteAllText(_jsonFileName, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to JSON file: {ex.Message}");
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            try
            {
                if (File.Exists(_jsonFileName))
                {
                    string jsonString = File.ReadAllText(_jsonFileName);

                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        gradeLogs = JsonSerializer.Deserialize<List<DModels>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<DModels>();
                    }
                    else
                    {
                        gradeLogs = new List<DModels>();
                    }
                }
                else
                {
                    gradeLogs = new List<DModels>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from JSON file: {ex.Message}");
                gradeLogs = new List<DModels>();
            }
        }

        public void AddLog(DModels account)
        {
            RetrieveDataFromJsonFile();
            gradeLogs.Add(account);
            SaveDataToJsonFile();
        }

        public List<DModels> GetGradeLogs()
        {
            RetrieveDataFromJsonFile();
            return gradeLogs;
        }

        public void Update(DModels loggedGrades)
        {
            RetrieveDataFromJsonFile();

            var currentgradeLogs = gradeLogs.FirstOrDefault(x => x.logID == loggedGrades.logID);

            if (currentgradeLogs != null)
            {
                currentgradeLogs.studentFullName = loggedGrades.studentFullName;
                currentgradeLogs.subject = loggedGrades.subject;
                currentgradeLogs.FinalGrade = loggedGrades.FinalGrade;

                SaveDataToJsonFile();
            }
            else
            {
                Console.WriteLine($"Log with ID {loggedGrades.logID} not found for update.");
            }
        }

        public DModels? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

       

        public void DeleteLog(Guid logToDelete)
        {
            RetrieveDataFromJsonFile();

            var target = gradeLogs.FirstOrDefault(x => x.logID == logToDelete);
            if (target != null)
            {
                gradeLogs.Remove(target);
                SaveDataToJsonFile();
            }
        }
    }
}
