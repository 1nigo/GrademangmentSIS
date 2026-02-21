namespace GrademangmentSIS
{
    internal class Program
    {
        static double exGrade1, exGrade2, projWork, seatwork1, seatwork2, quiz1, quiz2;
        static string subject;
        static List<string> grades = new List<string>();
        static void Main(string[] args)
        {        

            while (true)
            {
                Console.WriteLine("----------Grade Management System (PUPSIS)----------");
                Console.Write("Enter Subject Name: ");
                string subjectName = Console.ReadLine();
                enterGrades();
                double finalGrade = CalculateFinalGrade(exGrade1, exGrade2, projWork, seatwork1, seatwork2, quiz1, quiz2);
                logGrade(subject, finalGrade);

                Console.WriteLine("Calculate another grade? Y/N");
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    break;
                }
            }
            
        }

        static void enterGrades(){
            
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

        }



    }
}
