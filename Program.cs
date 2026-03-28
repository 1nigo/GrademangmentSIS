using System.Formats.Asn1;
using System.Reflection.Metadata;
using GradeMngntModels;
using GradeMngmntDataService;
using GradeMngmtAppService;

namespace GrademangmentSIS{
    internal class Program{
        static double exGrade1, exGrade2, projWork, seatwork1, seatwork2, quiz1, quiz2;
        static char action, ans1, ans2, ans3;
        static int ansUpd, ansRmv;
        static List<string> grades = new List<string>();
        static int grdListSize = grades.Count;

        static grdManagementBl gradeMngtBl = new grdManagementBl();

        static void Main(string[] args){
            int iterator = 1;
            Console.WriteLine("Welcome to the PUP grade management system!");

            while (true){
            
                Console.WriteLine("Please select your action 1-4: ");
                Console.WriteLine("1.) Calculate & save grade");
                Console.WriteLine("2.) Display all grades");
                Console.WriteLine("3.) Edit logged grades");
                Console.WriteLine("4.) Delete logged grades");
                Console.Write("Action: ");
                action = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.ReadLine();

                switch (action){
               
                    case '1':
                        while (true){
                            Console.WriteLine("----------Grade Management System (PUPSIS)----------");
                            Console.Write("Enter Subject Name: ");
                            string subjectName = Console.ReadLine();
                            enterGrades();
                            double finalGrade = gradeMngtBl.CalculateFinalGrade(exGrade1, exGrade2, projWork, seatwork1, seatwork2, quiz1, quiz2);
                            gradeMngtBl.logGrade(subjectName, finalGrade);
                            Console.WriteLine("Grade Logged!");

                            Console.Write("Calculate another grade? Y/N: ");
                            ans1 = Console.ReadKey().KeyChar;
                            ans1 = Char.ToUpper(ans1);
                            Console.WriteLine();
                            if (ans1 != 'Y')
                            {
                                break;
                            }
                        }
                        break;
                    case '2':
                        //display()
                        break;
                    case '3':
                        //Console.WriteLine("Current logged grades: ");
                        //foreach (string log in grades)
                        //{
                        //    Console.WriteLine($"{iterator}. " + log);
                        //    iterator++;
                        //}
                        //Console.Write("Enter log to edit: ");
                        //ansUpd = Convert.ToInt32(Console.ReadLine());

                        //if (ansUpd <= grdListSize - 1){

                        //}

                        //iterator = 0;

                        break;
                    case '4':
                        //while (true) { 
                        //Console.WriteLine("Current logged grades: ");
                        //foreach (string log in grades)
                        //{
                        //    Console.WriteLine($"{iterator}. " + log);
                        //    iterator++;
                        //}
                        //Console.Write("Enter log to remove: ");
                        //ansRmv = Convert.ToInt32(Console.ReadLine());

                        //    if (ansUpd <= grdListSize - 1){
                        //    grades.Remove(grades[ansRmv - 1]);
                        //}

                        //    iterator = 0;
                        //Console.Write("Remove another item? (Y/N): ");
                        //    ans3 = Console.ReadKey().KeyChar;
                        //    ans3 = Char.ToUpper(ans3);
                        //    Console.WriteLine();
                        //    if (ans3 != 'Y')
                        //    {
                        //        break;
                        //    }
                        //}

                        //break;
                    default:
                        Console.WriteLine("Please enter a valid action: ");
                        break;
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

            Console.Write("Enter Grade for exam 1: ");
            exGrade1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for exam 2: ");
            exGrade2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for project work: ");
            projWork = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for seatwork 1: ");
            seatwork1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for seatwork 2: ");
            seatwork2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for quiz 1: ");
            quiz1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for quiz 2: ");
            quiz2 = Convert.ToInt32(Console.ReadLine());
        }



    }
}
