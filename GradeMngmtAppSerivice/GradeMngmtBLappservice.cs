using System.Reflection;
using GradeMngntModels;
using GradeMngntDataService;

namespace GradeMngmntDataService
{

    public class grdManagementBl
    {
        grdManagementDL grdManagementDLS = new grdManagementDL();
        public double CalculateFinalGrade(double exGrade1, double exGrade2, double projWork, double seatwork1, double seatwork2, double quiz1, double quiz2)
        {
            double finalGrade = (exGrade1 * 0.3) + (exGrade2 * 0.3) + (projWork * 0.2) + (seatwork1 * 0.05) + (seatwork2 * 0.05) + (quiz1 * 0.05) + (quiz2 * 0.05);

            return finalGrade;
        }

        public void logGrade(string subject, double finalGrade)
        {

            DModels mdl = new DModels { FinalGrade = finalGrade, subject = subject };

            grdManagementDLS.addLog(mdl);
        }


    }
}
