using System.Reflection;
using GradeMngmntDataService;
using GradeMngntModels;

namespace GradeMngntDataService
{
    public class grdManagementInMemDL : IGradeMngmntDataService
    {


        public List<DModels> gradeList = new List<DModels>();
        public grdManagementInMemDL()
        {
            DModels base1 = new DModels { FinalGrade = 85.5, subject = "Mathematics"};

            gradeList.Add(base1);
        }

        public void AddLog(DModels mdl)
        {
            gradeList.Add(mdl);
        }

        
        public List<DModels> GetGradeLogs()
        {
            return gradeList;
        }

        public void Update(DModels account)
        {
           
        }
    }
}