using System.Formats.Asn1;
using System.Reflection.Metadata;
using GradeMngntModels;
using GradeMngmntDataService;
using GradeMngmtAppService;

namespace GrademangmentSIS
{
    internal class Program
    {
        //Incoming grade
        static double exGrade1, assignment1, assignment2, projWork, seatwork1, seatwork2, quiz1, quiz2;
        //Incoming grade over
        static double overEx1, overAss1, overAss2, overProj, overSeat1, overSeat2, overQuiz1, overQuiz2;
        static string newName, newSubject;
        static double newGrade;
        static char action, ans1, ans2;
        static double weightExam, weightProject, weightWritten;
        static int ansUpd;

        static grdManagementBl gradeMngtBl = new grdManagementBl();

        static void Main(string[] args)
        {
            int iterator = 1;
            Console.WriteLine("Welcome to the PUP grade management system!");
            var gradeLogs = gradeMngtBl.getGradeLogs();

            while (true)
            {
                try
                {
                    Console.WriteLine("----------Grade Management System (PUPSIS)----------");
                    Console.WriteLine("Please select your action 1-4: ");
                    Console.WriteLine("1.) Calculate & save grade");
                    Console.WriteLine("2.) Display all grades");
                    Console.WriteLine("3.) Edit logged grades");
                    Console.WriteLine("4.) Delete logged grades");
                    Console.WriteLine("5.) View grades of specific student");
                    Console.WriteLine("6.) Delete all logs");
                    Console.Write("Action: ");
                    action = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (action)
                    {

                        case '1':
                            enterGrades();
                            break;
                        case '2':
                            viewGrades();
                            break;
                        case '3':
                            editGrade();
                            break;
                        case '4':
                            deleteSpecificLog();
                            break;
                        case '5':
                            viewSpecificStudentGrades();
                            break;
                        case '6':
                            deleteAllLogs();
                            break;
                        default:
                            Console.WriteLine($"Please enter a valid action (you entered: '{action}')");
                            break;
                    }
                }
                catch (Exception e)
                { 
                Console.WriteLine($"An error occurred: {e.Message}");
                }
                    Console.Write("Re-use system?(Y/N): ");
                ans2 = Console.ReadKey().KeyChar;
                ans2 = Char.ToUpper(ans2);
                Console.WriteLine();
                if (ans2 != 'Y')
                {
                    break;
                }
            }

        }
        static void enterGrades()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("----------Grade Management System (PUPSIS)----------");
                    Console.Write("Enter Subject: ");
                    string subjectName = Console.ReadLine();

                    Console.Write("Enter Student Name: ");
                    string studentName = Console.ReadLine();

                    Console.WriteLine("Please enter the weight of the following fields:");
                    Console.Write("Seatwork: ");
                    weightWritten = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Project: ");
                    weightProject = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Exam: ");
                    weightExam = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("----------Enter Grades----------");
                    Console.Write("Enter Grade for quiz 1: ");
                    quiz1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Over: ");
                    overQuiz1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Grade for quiz 2: ");
                    quiz2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Over: ");
                    overQuiz2 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Grade for seatwork 1: ");
                    seatwork1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Over: ");
                    overSeat1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Grade for seatwork 2: ");
                    seatwork2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Over: ");
                    overSeat2 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Grade for assignment 1: ");
                    assignment1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Over: ");
                    overAss1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Grade for assignment 2: ");
                    assignment2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Over: ");
                    overAss2 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Grade for project work: ");
                    projWork = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Over: ");
                    overProj = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Grade for exam: ");
                    exGrade1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Over: ");
                    overEx1 = Convert.ToInt32(Console.ReadLine());

                
                gradeMngtBl.grdWeights(weightWritten, weightProject, weightExam);
                double finalGrade = gradeMngtBl.CalculateFinalGrade(exGrade1 / overEx1, projWork / overProj, seatwork1 / overSeat1, seatwork2 / overSeat2, assignment1 / overAss1, assignment2 / overAss2, quiz1 / overQuiz1, quiz2 / overQuiz2);
                gradeMngtBl.logGrade(studentName, subjectName, finalGrade);
                Console.WriteLine("Grade Logged!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input format. Please enter numeric values for grades and weights.");
                    continue;
                }

                Console.Write("Calculate another grade? Y/N: ");
                ans1 = Console.ReadKey().KeyChar;
                ans1 = Char.ToUpper(ans1);
                Console.WriteLine();
                if (ans1 != 'Y')
                {
                    break;
                }
            }
        }

        static void viewGrades()
        {
            int z = 1;
            Console.WriteLine("----------Grade Management System (PUPSIS)----------");
            Console.WriteLine("Current logged grades: ");
            List<DModels> gradeLogs = gradeMngtBl.getGradeLogs();
            foreach (DModels log in gradeLogs)
            {
                Console.WriteLine($"{z}.) Student Name: {log.studentFullName} | Subject: {log.subject} | Final Grade: {log.FinalGrade}");
                z++;
            }

        }

        static void editGrade()
        {
            int iterator = 1;
            Console.WriteLine("Current logged grades: ");
            List<DModels> gradeLogs = gradeMngtBl.getGradeLogs();
            foreach (DModels log in gradeLogs)
            {
                Console.WriteLine($"{iterator}. Student Name: {log.studentFullName} | Subject: {log.subject} | Final Grade: {log.FinalGrade}");
                iterator++;
            }
            Console.Write("Enter log to update: ");
            ansUpd = Convert.ToInt32(Console.ReadLine());
            if (ansUpd >= 1 && ansUpd <= gradeLogs.Count)
            {

                DModels logToUpdate = gradeLogs[ansUpd - 1];
                Guid loggedID = logToUpdate.logID;

                Console.WriteLine($"Selected Log - Student Name: {logToUpdate.studentFullName} | Subject: {logToUpdate.subject} | Final Grade: {logToUpdate.FinalGrade}");
                Console.Write("Enter new student name: ");
                newName = Console.ReadLine();
                Console.Write("Enter new subject: ");
                newSubject = Console.ReadLine();
                Console.Write("Enter new final grade: ");
                newGrade = Convert.ToDouble(Console.ReadLine());

                gradeMngtBl.updateLog(loggedID, newName, newSubject, newGrade);
            } else
            {
                Console.WriteLine("Please enter a valid index");
            }
        }

        static void deleteSpecificLog()
        {
            int iterator = 1;
            Console.WriteLine("Current logged grades: ");
            List<DModels> gradeLogs = gradeMngtBl.getGradeLogs();
            foreach (DModels log in gradeLogs)
            {
                Console.WriteLine($"{iterator}. Student Name: {log.studentFullName} | Subject: {log.subject} | Final Grade: {log.FinalGrade}");
                iterator++;
            }
            Console.Write("Enter log to delete: ");
            ansUpd = Convert.ToInt32(Console.ReadLine());
            if (ansUpd >= 1 && ansUpd <= gradeLogs.Count)
            {
                DModels logToDelete = gradeLogs[ansUpd - 1];
                Guid loggedID = logToDelete.logID;
                Console.WriteLine($"Selected Log - Student Name: {logToDelete.studentFullName} | Subject: {logToDelete.subject} | Final Grade: {logToDelete.FinalGrade}");
                Console.Write("Are you sure you want to delete this log? Y/N: ");
                char ansDel = Console.ReadKey().KeyChar;
                ansDel = Char.ToUpper(ansDel);
                Console.WriteLine();
                if (ansDel == 'Y')
                {
                    gradeMngtBl.deleteLog(logToDelete.logID);
                    Console.WriteLine("Log deleted.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid index");
            }
        }

        static void viewSpecificStudentGrades()
        {
            Console.Write("Enter student name to view grades: ");
            string studentName = Console.ReadLine();
            List<DModels> gradeLogs = gradeMngtBl.getGradeLogs();
            var specificStudentGrades = gradeLogs.Where(x => x.studentFullName.Equals(studentName, StringComparison.OrdinalIgnoreCase)).ToList();
            if (specificStudentGrades.Count > 0)
            {
                Console.WriteLine($"Grades for {studentName}:");
                foreach (DModels log in specificStudentGrades)
                {
                    Console.WriteLine($"Subject: {log.subject} | Final Grade: {log.FinalGrade}");
                }
            }
            else
            {
                Console.WriteLine($"No grades found for student: {studentName}");
            }
        }

        static void deleteAllLogs()
        {
            Console.Write("Are you sure you want to delete all logs? Y/N: ");
            char ansDel = Console.ReadKey().KeyChar;
            ansDel = Char.ToUpper(ansDel);
            Console.WriteLine();
            if (ansDel == 'Y')
            {
                List<DModels> gradeLogs = gradeMngtBl.getGradeLogs();
                foreach (DModels log in gradeLogs)
                {
                    gradeMngtBl.deleteLog(log.logID);
                }
                Console.WriteLine("All logs deleted.");
            }
        }
    }

}
