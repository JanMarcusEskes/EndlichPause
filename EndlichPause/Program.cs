using System;


namespace EndlichPause
{
    class Program
    {
        static void Main(string[] args)
        {
            int minute = 0, stunde = 0;
            bool wiederholen = false;

            Console.Title = "Wann ist Pause?";
            do
            {
                Console.Clear();
                Console.WriteLine("Um wie viel Uhr ist die nächste Pause?");
                Console.WriteLine("Bitte geben Sie die Zeit der Pause ein.\nSie muss das Format SS:MM haben.");
                string eingabe = Console.ReadLine();
                try
                {
                    if (int.TryParse(eingabe.Split(':')[0], out stunde) == false || int.TryParse(eingabe.Split(':')[1], out minute) == false || stunde > 23 || stunde < 0 || minute > 59 || minute < 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Es wurde eine falsche Eingabe getätigt!\nWollen Sie die Eingabe wiederholen?   (Any/N)");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (Console.ReadLine().ToUpper() == "N") return;
                        else wiederholen = true;
                    }
                    else wiederholen = false;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Der Eingegebene Wert hatte nicht das richtige Format!\nWollen Sie die Eingabe wiederholen?   (Any/N)");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (Console.ReadLine().ToUpper() == "N") return;
                    else wiederholen = true;

                }
            } while (wiederholen);

            DateTime zeitPause = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, stunde, minute, DateTime.Now.Second);
            TimeSpan zeitraum = zeitPause - DateTime.Now;
            if (Math.Round(zeitraum.TotalMinutes) < 0) { Console.WriteLine("Heute gibt es keine Pause mehr!"); Console.ReadLine(); return; }
            Console.Write("Es dauert noch {0} Minuten", Math.Round(zeitraum.TotalMinutes));
            Console.Read();
        }
    }
}
