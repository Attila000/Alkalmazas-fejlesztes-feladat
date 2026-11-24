
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace objektum
{
    internal class Program
    {
        class Game
        {
            public string Cim {get; set;}
            public string Mufaj {get; set;}
            public string Platform {get; set;}
            public int Ev {get; set;}
            public string Fejleszto {get; set;}
            public double Ar {get; set;}
            public string Multiplayer {get; set;}
            public string Korhatar {get; set;}

            public Game(string cim, string mufaj, string platform,
                int ev, string fejleszto, double ar,
                string multiplayer, string korhatar)
            {
                Cim = cim;
                Mufaj = mufaj;
                Platform = platform;
                Ev = ev;
                Fejleszto = fejleszto;
                Ar = ar;
                Multiplayer = multiplayer;
                Korhatar = korhatar;
            }

            public void Kiir()
            {
                Console.WriteLine("Jatek: " + Cim);
                Console.WriteLine("Mufaj: " + Mufaj);
                Console.WriteLine("Platfom: " + Platform);
                Console.WriteLine("Ev: " + Ev);
                Console.WriteLine("Fejleszto: " + Fejleszto);
                Console.WriteLine("Ar: " + Ar + " EUR");
                Console.WriteLine("Multiplayer: " + Multiplayer);
                Console.WriteLine("Korhatar: " + Korhatar);
            }
        }

        static void Main(string[] args)
        {
            List<Game> jatekok = new List<Game>();

            string fajlNev = "jatekok.txt";

            string[] sorok = File.ReadAllLines(fajlNev);

            for (int i = 1; i < sorok.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(sorok[i]))
                {
                    continue;
                }

                string[] adatok = sorok[i].Split('|');

                for (int j = 0; j < adatok.Length; j++)
                {
                    adatok[j] = adatok[j].Trim();
                }
                if (!int.TryParse(adatok[3], out int ev))
                {
                    Console.WriteLine("hibas ev: " + adatok[3]);
                    continue;
                }

                double ar;

                bool sikeresAr = double.TryParse(
                    adatok[5],
                    out ar
                );

                Game jatek = new Game(
                    adatok[0],
                    adatok[1],
                    adatok[2],
                    ev,
                    adatok[4],
                    ar,
                    adatok[6],
                    adatok[7]
                );

                jatekok.Add(jatek);
            }

            Console.WriteLine("beolvasott jatekok");
            Console.WriteLine("====================");

            foreach (Game jatek in jatekok)
            {
                jatek.Kiir();
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("Beolvasott jatekok szama: " + jatekok.Count);

            if (jatekok.Count > 0)
            {
                Game legdragabb = jatekok[0];

                foreach (Game jatek in jatekok)
                {
                    if (jatek.Ar > legdragabb.Ar)
                    {
                        legdragabb = jatek;
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Legdragabb jatek: " + legdragabb.Cim);
                Console.WriteLine("ara: " + legdragabb.Ar + " EUR");
            }
            else
            {
                Console.WriteLine("Nincs beolvashato jatek!");
            }

            Console.WriteLine();
            Console.WriteLine("2015 utan megjelent jatekok");
            Console.WriteLine("====================");

            foreach (Game jatek in jatekok)
            {
                if (jatek.Ev > 2015)
                {
                    Console.WriteLine(jatek.Cim);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Multiplayer jatekok");
            Console.WriteLine("====================");

            foreach (Game jatek in jatekok)
            {
                if (jatek.Multiplayer == "igen")
                {
                    Console.WriteLine(jatek.Cim);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Korhataros jatekok");
            Console.WriteLine("====================");

            foreach (Game jatek in jatekok)
            {
                if (jatek.Korhatar == "18+")
                {
                    Console.WriteLine(jatek.Cim);
                }
            }
        }
    }
}
