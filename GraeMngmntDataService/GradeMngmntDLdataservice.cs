using System.Reflection;
using GradeMngntModels;

namespace GradeMngntDataService
{
    public class grdManagementDL
    {


        public List<DModels> gradeList = new List<DModels>();
        public grdManagementDL()
        {
            DModels base1 = new DModels { FinalGrade = 85.5, subject = "Mathematics" };

            gradeList.Add(base1);
        }

        public void addLog(DModels mdl)
        {
            gradeList.Add(mdl);
        }

    }
}