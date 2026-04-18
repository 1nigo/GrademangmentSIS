using System.Reflection;
using GradeMngntModels;
using GradeMngmntDataService;

namespace GradeMngmtAppService
{

    public class grdManagementBl
    {
        public double weightWritten, weightProject, weightExam;

        GradeDataService grdManagementDLS = new GradeDataService(new GradeMngmntJSONdataservice());

        public void grdWeights(double weightWritten, double weightProject, double weightExam)
        {
            this.weightWritten = weightWritten / 100;
            this.weightProject = weightProject / 100;
            this.weightExam = weightExam / 100;
        }

        public double CalculateFinalGrade(double exGrade1, double projWork, double seatwork1, double seatwork2, double assignment1, double assignment2, double quiz1, double quiz2)
        {
            double finalExamGrade = (exGrade1 * 100) * weightExam;
            double finalProjectGrade = (projWork * 100) * weightProject;
            double finalWrittenGrade = (((seatwork1 * 100) + (seatwork2 * 100) + (assignment1 * 100) + (assignment2 * 100) + (quiz1 * 100) + (quiz2 * 100)) / 6) * weightWritten;
            double finalGrade = finalExamGrade + finalProjectGrade + finalWrittenGrade;
            return finalGrade;
        }

        public void logGrade(string studentName, string subject, double finalGrade)
        {

            DModels mdl = new DModels
            {
                logID = Guid.NewGuid(),
                studentFullName = studentName,
                FinalGrade = finalGrade,
                subject = subject
            };

            grdManagementDLS.Addlog(mdl);
        }

        public void updateLog(Guid logID, string studentName, string subject, double finalGrade)
        {
            DModels mdl = new DModels
            {
                logID = logID,
                studentFullName = studentName,
                FinalGrade = finalGrade,
                subject = subject
            };

            grdManagementDLS.Update(mdl);
        }

        public List<DModels> getGradeLogs()
        {
            return grdManagementDLS.GetGradeLogs();


        }

        public void deleteLog(Guid logID)
        {
            grdManagementDLS.DeleteLog(logID);
        }
    }
}
