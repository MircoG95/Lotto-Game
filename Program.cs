using System;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gewinnzahl = new int[6];
            int superzahl = 0;
            int[] tipps = new int[6];
            int richtige;

            GewinnZahlenZiehen(gewinnzahl, ref superzahl);
            TippsAbgeben(tipps);
            richtige = RichtigeZaehlen(gewinnzahl, tipps);
            Ausgabe(gewinnzahl, tipps, richtige);
        }
        static void Ausgabe(int[] gewinn, int[] tipp, int richtig)
        {
            Console.WriteLine();
            Console.Write("Ziehung: ");
            foreach (int item in gewinn)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Tipps:   ");
            foreach (int item in tipp)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Richtige: " + richtig);
        }
        static int RichtigeZaehlen(int[] gewinn, int[] tipp)
        {
            int temp = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (gewinn[i] == tipp[j])
                        temp++;
                }
            }
            return temp;
        }
        static void TippsAbgeben(int[] li)
        {
            bool check;

            for (int i = 1; i < 7; i++)
            {
                do
                {
                    Console.Write($"Bitte geben sie Ihren {i}. Tipp ab: ");
                    check = int.TryParse(Console.ReadLine(), out li[i - 1]);
                    if (!check || li[i - 1] < 1 || li[i - 1] > 49)
                    {
                        Console.WriteLine("Fehleingabe! Bitte nur Zahlen zwischen 1-49 eingeben.");
                        check = false;
                    }
                    else
                    {
                        for (int j = 0; j < i - 1; j++)
                        {
                            if (li[i - 1] == li[j])
                            {
                                check = false;
                                Console.WriteLine("Diese Zahl wurde schon getippt, bitte eine andere wählen.");
                            }
                        }
                    }
                } while (!check);
            }
            Array.Sort(li);
        }
        static void GewinnZahlenZiehen(int[] li, ref int super)
        {
            Random rnd = new Random();
            bool check;

            for (int i = 0; i < 6; i++)
            {
                do
                {
                    check = true;
                    li[i] = rnd.Next(1, 50);
                    for (int j = 0; j < i; j++)
                    {
                        if (li[i] == li[j])
                            check = false;
                    }
                } while (!check);
            }
            Array.Sort(li);

            do
            {
                check = true;
                super = rnd.Next(1, 50);
                for (int i = 0; i < 6; i++)
                {
                    if (super == li[i])
                        check = false;
                }
            } while (!check);
        }
    }
}
