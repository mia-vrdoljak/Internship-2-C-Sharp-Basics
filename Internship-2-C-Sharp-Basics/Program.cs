 using System;
using System.Collections.Generic;

namespace Internship_2_C_Sharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            var playlist = new Dictionary<int, string>()
            {
                {1, "Prava razlika"},
                {2, "Sam protiv svih"},
                {3, "Da se more smiluje"},
                {4, "Nasloni se"},
                {5, "Ima li nade za nas"},
                {6, "Kapetane tribali bi doma"},
                {7, "Šta se smiješ klipane"},
                {8, "Srna i vuk"},
                {9, "Vrijeme"},
                {10, "Deset mlađa"}
            };

            Izbornik(playlist);
            Kraj(playlist);


        }
        static void Izbornik(Dictionary<int, string> playlist)
        {
            Console.WriteLine("Odaberite akciju:\n1 - Ispis cijele liste\n2 - Ispis imena pjesme unosom pripadajućeg rednog broja\n3 - Ispis rednog broja pjesme unosom pripadajućeg imena\n4 - Unos nove pjesme\n5 - Brisanje pjesme po rednom broju\n6 - Brisanje pjesme po imenu\n7 - Brisanje cijele liste\n8 - Uređivanje imena pjesme\n9 - Uređivanje rednog broja pjesme\n0 - Izlaz iz aplikacije");
            var izbor = int.Parse(Console.ReadLine());

            if (izbor == 1)//Ispis cijele liste
            {
                foreach (var pair in playlist)
                {
                    Console.WriteLine(pair.Key + " " + pair.Value);
                }
            }
            else if (izbor == 2)//Ispis imena pjesme unosom pripadajućeg rednog broja
            {
                Console.WriteLine("Pjesmu pod kojim rednim brojem želite ispisati?");
                var broj = int.Parse(Console.ReadLine());
                if (playlist.ContainsKey(broj))
                {
                    Console.WriteLine(playlist[broj]);
                }
                else
                {
                    Console.WriteLine("Ne postoji pjesma pod brojem {0}.\nAko se želite vratiti na početni izbornik upišite DA.", broj);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        Izbornik(playlist);
                    }
                }
            }
            else if (izbor == 3)//Ispis rednog broja pjesme unosom pripadajućeg imena
            {
                Console.WriteLine("Redni broj koje pjesme želite ispisati?");
                var pjesma = Console.ReadLine();
                if (playlist.ContainsValue(pjesma))
                {
                    foreach (var pair in playlist)
                    {
                        if (pair.Value == pjesma)
                        {
                            Console.WriteLine(pair.Key);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ne postoji pjesma {0}.\nAko se želite vratiti na početni izbornik upišite DA.", pjesma);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        Izbornik(playlist);
                    }
                }
            }
            else if (izbor == 4)//Unos nove pjesme
            {
                Console.WriteLine("Unesi novu pjesmu! :D");
                var pjesma = Console.ReadLine();
                if (playlist.ContainsValue(pjesma))
                {
                    Console.WriteLine("Pjesma koju želite unijeti već postoji u listi.");
                }
                else
                {
                    Console.WriteLine("Ako ste sigurni da želite unijeti novu pjesmu ~{0}~ upišite DA.", pjesma);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        playlist.Add(playlist.Count + 1, pjesma);
                    }
                }
            }
            else if (izbor == 5)//Brisanje pjesme po rednom broju
            {
                Console.WriteLine("Pjesmu pod kojim brojem želite izbrisati?");
                var broj = int.Parse(Console.ReadLine());
                if (playlist.ContainsKey(broj))
                {
                    Console.WriteLine("Ako ste sigurni da želite izbrisati pjesmu pod brojem {0} upišite DA.", broj);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        playlist.Remove(broj);
                        for (int i = broj + 1; i < playlist.Count + 2; i++)
                        {
                            playlist[i - 1] = playlist[i];
                            playlist.Remove(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ne postoji pjesma pod brojem {0}.\nAko se želite vratiti na početni izbornik upišite DA.", broj);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        Izbornik(playlist);
                    }
                }
            }
            else if (izbor == 6)//Brisanje pjesme po imenu
            {
                Console.WriteLine("Koju pjesmu želite izbrisati?");
                var pjesma = Console.ReadLine();
                if (playlist.ContainsValue(pjesma))
                {
                    Console.WriteLine("Ako ste sigurni da želite izbrisati pjesmu ~{0}~ upišite DA.", pjesma);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        var key = 0;
                        for (var i = 1; i < playlist.Count; i++)
                        {
                            if (playlist[i] == pjesma)
                            {
                                playlist.Remove(i);
                                key = i;
                                break;
                            }
                        }
                        for (int i = key + 1; i < playlist.Count + 2; i++)
                        {
                            playlist[i - 1] = playlist[i];
                            playlist.Remove(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ne postoji pjesma {0}.\nAko se želite vratiti na početni izbornik upišite DA.", pjesma);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        Izbornik(playlist);
                    }
                }
            }
            else if (izbor == 7)//Brisanje cijele liste
            {
                Console.WriteLine("Ako ste sigurni da želite izbrisati cijelu listu pjesama upišite DA.");
                if (Console.ReadLine().ToUpper() == "DA")
                {
                    foreach (var pair in playlist)
                    {
                        playlist.Remove(pair.Key);
                    }
                }
            }
            else if (izbor == 8)//Uređivanje imena pjesme
            {
                Console.WriteLine("Pjesmi pod kojim brojem želite urediti ime?");
                var broj = int.Parse(Console.ReadLine());
                if (playlist.ContainsKey(broj))
                {
                    Console.WriteLine("Unesite uređeno ime pjesme {0} ~{1}~.", broj, playlist[broj]);
                    var ime = Console.ReadLine();
                    Console.WriteLine("Ako ste sigurni da ime pjesme {0} ~{1}~ želite urediti u ~{2}~ upišite DA.", broj, playlist[broj], ime);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        playlist[broj] = ime;
                    }
                }
                else
                {
                    Console.WriteLine("Ne postoji pjesma pod brojem {0}.\nAko se želite vratiti na početni izbornik upišite DA.", broj);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        Izbornik(playlist);
                    }
                }
            }
            else if (izbor == 9)//Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi
            {
                Console.WriteLine("Pjesmi pod kojim brojem želite promijeniti redni broj?");
                var broj1 = int.Parse(Console.ReadLine());
                if (playlist.ContainsKey(broj1))
                {
                    Console.WriteLine("Pod kojim rednim brojem želite da se nalazi pjesma?");
                    var broj2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ako ste sigurni da želite pjesmu pod brojem {0} premjestiti pod broj {1} upišite DA.", broj1, broj2);
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        if (broj1 < broj2)
                        {
                            var pjesma1 = playlist[broj1];
                            playlist.Remove(broj1);
                            for (int i = broj1 + 1; i < broj2 + 1; i++)
                            {
                                playlist[i - 1] = playlist[i];
                                playlist.Remove(i);
                            }
                            playlist.Add(broj2, pjesma1);
                        }
                        if (broj1 > broj2)
                        {
                            var pjesma1 = playlist[broj1];
                            playlist.Remove(broj1);
                            for (int i = broj1; i > broj2; i--)
                            {
                                playlist[i] = playlist[i - 1];
                                playlist.Remove(i - 1);
                            }
                            playlist.Add(broj2, pjesma1);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ne postoji pjesma pod brojem {0}.\nAko se želite vratiti na početni izbornik upišite DA.");
                    if (Console.ReadLine().ToUpper() == "DA")
                    {
                        Izbornik(playlist);
                    }
                }
            }
            else if (izbor == 0)//Izlaz iz aplikacije
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Čini se da ste nešto pogrešno kliknuli.\nAko se želite vratiti na početni izbornik upišite DA.");
                if (Console.ReadLine().ToUpper() == "DA")
                {
                    Izbornik(playlist);
                }
            }
        }
        
        static void Kraj(Dictionary<int, string> playlist)
        {
            Console.WriteLine("Ako želite ispisati listu pjesama upišite PJESME.");
            if (Console.ReadLine().ToUpper() == "PJESME")
            {
                foreach (var pair in playlist)
                {
                    Console.WriteLine(pair.Key + " " + pair.Value);
                }
            }
            else
            {
                Console.WriteLine("Čini se da ste nešto pogrešno kliknuli.");
                Kraj(playlist);
            }
        }
    }
}