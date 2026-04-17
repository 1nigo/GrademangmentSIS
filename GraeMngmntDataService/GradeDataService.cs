using GradeMngntModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace GradeMngmntDataService
{
    public class GradeDataService
    {
        IGradeMngmntDataService _gradeMngmntDataService;
        public GradeDataService(IGradeMngmntDataService gradeDataService) 
        {
            _gradeMngmntDataService = gradeDataService;
        }
        public void Addlog(DModels account)
        {
            _gradeMngmntDataService.AddLog(account);
        }
       
        public List<DModels> GetGradeLogs()
        {
            return _gradeMngmntDataService.GetGradeLogs();
        }

        public void Update(DModels loggedGrades)
        {
            _gradeMngmntDataService.Update(loggedGrades);
        }

        public List<DModels> GetAccounts()
        {
            return _gradeMngmntDataService.GetGradeLogs();
        }

        public void DeleteLog(Guid logToDelete)
        {
            _gradeMngmntDataService.DeleteLog(logToDelete);
        }


    }
}
