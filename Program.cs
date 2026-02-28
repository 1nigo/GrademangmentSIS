
using System.Formats.Asn1;

namespace GrademangmentSIS
{
    internal class Program
    {
        static double exGrade1, exGrade2, projWork, seatwork1, seatwork2, quiz1, quiz2;
        static string subject;
        static char action, ans1, ans2, ans3;
        static List<string> grades = new List<string>();
        static void Main(string[] args)
        {
            int iterator = 1;
            Console.WriteLine("Welcome to the PUP grade management system!");
            Console.WriteLine("Please select your action 1-4: ");
            Console.WriteLine("1.) Calculate & save grade");
            Console.WriteLine("2.) Display all grade");
            Console.WriteLine("3.) Edit logged grade");
            Console.WriteLine("4.) Delete logged grade");

            while (true)
            {
                Console.Write("Action: ");
                action = Console.ReadKey().KeyChar;

                switch (action)
                {
                    case '1':
                        while (true)
                        {
                            Console.WriteLine("----------Grade Management System (PUPSIS)----------");
                            Console.Write("Enter Subject Name: ");
                            string subjectName = Console.ReadLine();
                            enterGrades();
                            double finalGrade = CalculateFinalGrade(exGrade1, exGrade2, projWork, seatwork1, seatwork2, quiz1, quiz2);
                            logGrade(subject, finalGrade);

                            Console.WriteLine("Calculate another grade? Y/N");
                            ans1 = Console.ReadKey().KeyChar;
                            Char.ToUpper(ans1);
                            if (ans1 != 'Y')
                            {
                                break;
                            }
                        }
                        break;
                    case '2':
                        foreach (string log in grades)
                        {
                            Console.WriteLine($"{iterator}. " + grades);
                            iterator++;
                        }
                        break;
                    case '3':
                        foreach (string log in grades)
                        {
                            Console.WriteLine($"{iterator}. " + grades);
                            iterator++;
                        }
                        Console.Write("Enter log to edit: ");
                        ans3 = Console.ReadKey().KeyChar;

                        break;
                    case '4':
                        break;
                    default:
                        Console.WriteLine("Please enter a valid action: ");
                        break;
                }
                Console.Write("Re-use system?: ");
                ans2 = Console.ReadKey().KeyChar;
                Char.ToUpper(ans2);
                if (ans1 != 'Y')
                {
                    break;
                }
            }

        }

        static void enterGrades()
        {

            Console.Write("Enter Grade for exam 1:");
            exGrade1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for exam 2:");
            exGrade2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for project work:");
            projWork = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for seatwork 1:");
            seatwork1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for seatwork 2:");
            seatwork2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for quiz 1:");
            quiz1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade for quiz 2:");
            quiz2 = Convert.ToInt32(Console.ReadLine());
        }

        static double CalculateFinalGrade(double exGrade1, double exGrade2, double projWork, double seatwork1, double seatwork2, double quiz1, double quiz2)
        {
            double finalGrade = (exGrade1 * 0.3) + (exGrade2 * 0.3) + (projWork * 0.2) + (seatwork1 * 0.05) + (seatwork2 * 0.05) + (quiz1 * 0.05) + (quiz2 * 0.05);

            return finalGrade;
        }

        static void logGrade(string subject, double finalGrade)
        {

            grades.Add($"Subject: {subject}, Final Grade: {finalGrade}");

            Console.WriteLine($"Subject: {subject}, Final Grade: {finalGrade}");

        }



    }
}
