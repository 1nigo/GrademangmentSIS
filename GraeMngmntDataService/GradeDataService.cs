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
       

        public void Update(DModels account)
        {
            _gradeMngmntDataService.Update(account);
        }

        public List<DModels> GetAccounts()
        {
            return _gradeMngmntDataService.GetGradeLogs();
        }
    }
}
