using GradeMngntModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeMngmntDataService
{
    public interface IGradeMngmntDataService
    {

        public void AddLog(DModels account);
        public List<DModels> GetGradeLogs();


        public void DeleteLog(Guid logToDelete);

        public void Update(DModels loggedGrades);
        
    }
}
