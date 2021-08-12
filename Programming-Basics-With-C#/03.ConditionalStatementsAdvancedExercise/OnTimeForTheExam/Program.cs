using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int hourOfArrive = int.Parse(Console.ReadLine());
            int minutesOfArrive = int.Parse(Console.ReadLine());

            int examInMinutes = hourOfExam * 60 + minutesOfExam;
            int arriveInMinutes = hourOfArrive * 60 + minutesOfArrive;

            if (arriveInMinutes > examInMinutes)
            {
                Console.WriteLine("Late");

                int lateInMinutes = arriveInMinutes - examInMinutes;
                int lateHours = lateInMinutes / 60;
                int lateMinutes = lateInMinutes % 60;

                if (lateInMinutes >= 60)
                {
                    Console.WriteLine($"{lateHours}:{lateMinutes:d2} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{lateMinutes} minutes after the start");
                }

            }
            else if (arriveInMinutes == examInMinutes || examInMinutes - arriveInMinutes <= 30)
            {
                Console.WriteLine("On time");

                int earlyInMinutes = examInMinutes - arriveInMinutes;
                int earlyMinutes = earlyInMinutes % 60;

                if (earlyInMinutes != 60)
                {
                    Console.WriteLine($"{earlyMinutes} minutes before the start");
                }

            }
            else if (examInMinutes - arriveInMinutes > 30)
            {
                Console.WriteLine("Early");

                int earlyInMinutes = examInMinutes - arriveInMinutes;
                int earlyMinutes = earlyInMinutes % 60;
                int earlyHours = earlyInMinutes / 60;

                if (earlyInMinutes < 60)
                {

                    Console.WriteLine($"{earlyMinutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{earlyHours}:{earlyMinutes:d2} hours before the start");
                }
            }
        }
    }
}
