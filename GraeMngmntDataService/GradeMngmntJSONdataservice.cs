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
                gradeLogs.Add(new DModels { FinalGrade = 71.82, subject = "Math" });
                

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<DModels>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , gradeLogs);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                gradeLogs = JsonSerializer.Deserialize<List<DModels>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void AddLog(DModels account)
        {
            gradeLogs.Add(account);
            SaveDataToJsonFile();
        }

        public List<DModels> GetGradeLogs()
        {
            RetrieveDataFromJsonFile();
            return gradeLogs;
        }

        //public DModels? GetById(Guid id)
        //{
        //    RetrieveDataFromJsonFile();
        //    return gradeLogs.Where(x => x.AccountId == id).FirstOrDefault();
        //}

        //public DModels? GetByUsername(string username)
        //{
        //    RetrieveDataFromJsonFile();
        //    return gradeLogs.Where(x => x.Username == username).FirstOrDefault();
        //}

        public void Update(DModels account)
        {
            RetrieveDataFromJsonFile();

            //var existingAccount = gradeLogs.FirstOrDefault(x => x.AccountId == account.AccountId);

            //if (existingAccount != null)
            //{
            //    existingAccount.Username = account.Username;
            //    existingAccount.Password = account.Password;
            //}

            SaveDataToJsonFile();
        }

        
    }
}
