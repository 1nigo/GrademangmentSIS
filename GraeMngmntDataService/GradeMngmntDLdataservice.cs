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
            DModels base1 = new DModels { logID = Guid.NewGuid(), studentFullName = "Inigo Baseleres", FinalGrade = 85.5, subject = "Mathematics" };

            gradeList.Add(base1);
        }

        public void AddLog(DModels mdl)
        {
            gradeList.Add(mdl);
        }


        public void DeleteLog(Guid logToDelete)
        {
            var log = gradeList.FirstOrDefault(x => x.logID == logToDelete);
            if (log != null)
            {
                gradeList.Remove(log);
            }
        }



        public List<DModels> GetGradeLogs()
        {
            return gradeList;
        }

        public void Update(Guid logGID, string studentName, string subject, double finalGrade)
        {
            var currentgradeLogs = gradeList.FirstOrDefault(x => x.logID == logGID);

            if (currentgradeLogs != null)
            {
                currentgradeLogs.studentFullName = studentName;
                currentgradeLogs.subject = subject;
                currentgradeLogs.FinalGrade = finalGrade;
            }
        }

        public void Update(DModels loggedGrades)
        {
            throw new NotImplementedException();
        }
    }
}