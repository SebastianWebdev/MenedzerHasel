using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MenedzerHasel
{
    class BazaHasel
    {

    }
    class Interfejs
    {
        private bool znakiSpecjalne, cyfry, duzeLitery, maleLitery=true;
        private string uzytkownik;
        private List<Haslo> ListaHasel = new List<Haslo>();
        public void noweHaslo()
        {
            
            Console.WriteLine("Aktualne ustawienia hasla");
            Console.WriteLine("");
            pokazUstawieniaHasel();
            Console.WriteLine("");
            Console.Write("Jeśli chcesz zmienić ustawienia napsz: tak");
            Console.WriteLine("");
            string czyUstawienia = Console.ReadLine().ToLower();
            if (czyUstawienia=="tak")
            {
                uruhomUstawienia();
            }
            Console.Write("Podaj nazwe dla hasla ");
            string nazwa = Console.ReadLine();
           
            bool dobradlugosc = false;
            byte dlugosc=4;
            while (dobradlugosc!=true)
            {
                Console.Write("Podaj dlugość hasla - liczba całkowita z przedziału Od 4 do 255.");
                Console.WriteLine("");
                byte pobrana = Convert.ToByte(Console.ReadLine());
                if (pobrana >3 )
                {
                    dlugosc = pobrana;
                    dobradlugosc = true;
                }
                else
                {
                    Console.WriteLine("Podana wartość długośći jest błędna. Długość musi być liczbą całkowitą z przedziału 4-255");
                }
              

            }
            

            if (znakiSpecjalne!=true&&cyfry!=true&&duzeLitery!=true&&maleLitery!=true) {
                Console.WriteLine("Hasło musi składać się z przynajmniej jednego typu znaków");
                Console.WriteLine("");
                uruhomUstawienia();
                Console.WriteLine("Wpisz komendę - nowe haslo ");
                Console.WriteLine("");
            }
            else
            {
                Haslo noweHaslo = new Haslo(nazwa, znakiSpecjalne, cyfry, duzeLitery, maleLitery);
                noweHaslo.Generuj(dlugosc);
                ListaHasel.Add(noweHaslo);
                Console.WriteLine("Nazwa: " + nazwa);
                Console.WriteLine("");
                Console.WriteLine("Hasło: " + noweHaslo.WezHaslo());
                Console.WriteLine("");
            }
           

        }
        private void UstawZnakiSpecjalne()
        {
            bool ukonczono = false;
            while (ukonczono != true)
            {
                Console.Write("Znaki Specjalne: TAK/NIE ");
                string Status = Console.ReadLine();
                if (Status.ToLower() == "tak")
                {
                    znakiSpecjalne = true;
                    ukonczono = true;
                }
                else
                if (Status.ToLower() == "nie")
                {
                    znakiSpecjalne = false;
                    ukonczono = true;
                }
                else
                {
                    Console.WriteLine("Podano błędną wartość należy wpisać tak lub nie ");
                    Console.WriteLine("* wielkość liter nie ma znaczenia");
                }
            }
           

        }
        private void UstawCyfry()
        {
            bool ukonczono = false;
            while (ukonczono != true)
            {
                Console.Write("Cyfry: TAK/NIE ");
                string Status = Console.ReadLine();
                Console.WriteLine(Status);
                if (Status.ToLower() == "tak")
                {
                    cyfry = true;
                    ukonczono = true;
                } else
                if (Status.ToLower() == "nie")
                {
                    cyfry = false;
                    ukonczono = true;
                }
                else
                {
                    Console.WriteLine("Podano błędną wartość należy wpisać tak lub nie ");
                    Console.WriteLine("* wielkość liter nie ma znaczenia");
                }
            }

        }
        private void UstawDuzeLitery()
        {
            bool ukonczono = false;
            while (ukonczono != true)
            {
                Console.Write("DuzeLitery: TAK/NIE ");
                string Status = Console.ReadLine();
                if (Status.ToLower() == "tak")
                {
                    duzeLitery = true;
                    ukonczono = true;
                }
                else
                if (Status.ToLower() == "nie")
                {
                    duzeLitery = false;
                    ukonczono = true;
                }
                else
                {
                    Console.WriteLine("Podano błędną wartość należy wpisać tak lub nie ");
                    Console.WriteLine("* wielkość liter nie ma znaczenia");
                }
            }

        }
        private void UstawMaleLitery()
        {
            bool ukonczono = false;
            while (ukonczono != true)
            {
                Console.Write("MaleLitery: TAK/NIE ");
                string Status = Console.ReadLine();
                if (Status.ToLower() == "tak")
                {
                    maleLitery = true;
                    ukonczono = true;
                }
                else
                if (Status.ToLower() == "nie")
                {
                    maleLitery = false;
                    ukonczono = true;
                }
                else
                {
                    Console.WriteLine("Podano błędną wartość należy wpisać tak lub nie ");
                    Console.WriteLine("* wielkość liter nie ma znaczenia");
                }
            }

        }

        private void uruhomUstawienia()
        {
            UstawZnakiSpecjalne();
            UstawCyfry();
            UstawDuzeLitery();
            UstawMaleLitery();
        }
        private void pokazUstawieniaHasel()
        {
            Console.WriteLine("Znaki specjalne: "+ znakiSpecjalne);
            Console.WriteLine("Cyfry: " + cyfry);
            Console.WriteLine("Duże litery: " + duzeLitery);
            Console.WriteLine("Małe litery: " + maleLitery);
        }
        private void pokazHasla()
        {
            if (ListaHasel.Count>0)
            {
                foreach (var item in ListaHasel)
                {
                    Console.WriteLine(item.wezNazwe() + " " + item.WezHaslo());
                }
            }
            else
            {
                Console.WriteLine("Aktualnie lista haseł jest pusta");
                Console.WriteLine("Aby dodać nowe haslo wpisz komende nowe haslo");
            }
          
        }
        private void OpcjeProgramu()
        {
            Console.WriteLine("wyloguj --- Wylogowuje użytkownika");
            Console.WriteLine("uzytkownik --- Uruchamia program tworzenia i edycji użytkownika");
            Console.WriteLine("zamknij --- Zamyka program bez zapisywania zmian");
            Console.WriteLine("zapisz --- Zapisuje Hasła do pliku");
            Console.WriteLine("lista hasel --- Pokazuje listę zapisanych haseł");
            Console.WriteLine("nowe haslo --- Tworzy Nowe Haslo");
            Console.WriteLine("ustawienia --- Pokazuje aktualne ustawienia dla generowanego hasla");
            Console.WriteLine("zmien ustawienia --- Uruchamia program zminy ustawień");

        }
        public void UruchomProgram() {
            bool koniec = false;
            Console.WriteLine("Witaj w menedżerze Haseł");
            Console.WriteLine("Możesz zamknąć program poprzez komendę 'zamknij'");
            Console.WriteLine("Komenda 'opcje' Pokarze możliwe opcje w programie");

            while (koniec!=true)
            {
                
                Console.Write("Podaj komende: ");
                string komenda=Console.ReadLine();

                switch (komenda)
                {
                    case "zamknij":
                        koniec = true;
                        
                        break;
                    case "opcje":
                        Console.WriteLine("---------------DOSTEPNE KOMENDY");
                        Console.WriteLine("");
                        OpcjeProgramu();
                        Console.WriteLine("");
                        break;
                    case "lista hasel":
                        Console.WriteLine("---------------LISTA HASEŁ");
                        Console.WriteLine("");
                        pokazHasla();
                        Console.WriteLine("");
                        break;
                    case "nowe haslo":
                        Console.WriteLine("---------------NOWE HASŁO");
                        Console.WriteLine("");
                        noweHaslo();
                        Console.WriteLine("");
                        break;
                    case "zmien ustawienia":
                        Console.WriteLine("---------------ZMIANA USTAWIEŃ");
                        Console.WriteLine("");
                        uruhomUstawienia();
                        Console.WriteLine("");
                        break;
                    case "ustawienia":
                        Console.WriteLine("---------------AKTUALNE USTAWIENIA HASEŁ");
                        Console.WriteLine("");
                        pokazUstawieniaHasel();
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("---------------BŁĄD");
                        Console.WriteLine("");
                        Console.WriteLine("Nie rozpoznano komendy, aby sprawdzić listę dostępnych komend napisz opcje");
                        Console.WriteLine("");
                        break;
                }
              




            }
        
        
        
        }
       
    }
  
    abstract class Generator
    {
        protected Random losuj = new Random();
        private string[] Znaki;


        public abstract string losujZnak();
       
        
    }
    class GenerujCyfre : Generator
    {
        private string[] Znaki;
        public GenerujCyfre()
        {
            Znaki = new String[10] {"0","1","2", "3", "4", "5", "6", "7", "8", "9" };
        }
        public override string losujZnak() {
            int losowyIndex = losuj.Next(0, Znaki.Length);
            return Znaki[losowyIndex];
        }


    }
    class GenerujZnakSpecjalny : Generator
    {
        private string[] Znaki;
        public GenerujZnakSpecjalny()
        {
            Znaki = new String[20] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "=","-",">","?","/","<","`",":" };
        }
        public override string losujZnak()
        {
            int losowyIndex = losuj.Next(0, Znaki.Length);
            return Znaki[losowyIndex];
        }


    }
    class GenerujLitere : Generator
    {
        private string[] Znaki;
        public GenerujLitere()
        {
            Znaki = new String[26] { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l","z","x","c","v","b","n","m" };
        }
        public override string losujZnak()
        {
            int losowyIndex = losuj.Next(0, Znaki.Length);
            return Znaki[losowyIndex];
        }
        public string losujZnak(Boolean duzaLitera)
        {
            int losowyIndex = losuj.Next(0, Znaki.Length);
            string Znak = Znaki[losowyIndex];

            if (duzaLitera==true)
            {
               
                Znak =Znak.ToUpper();
            }
            
            return Znak;

        }


    }
    class Haslo
    {
        private GenerujCyfre gen = new GenerujCyfre();
        private GenerujZnakSpecjalny gen2 = new GenerujZnakSpecjalny();
        private GenerujLitere gen3 = new GenerujLitere();
        private string haslo="";
        private string nazwa;
        private bool znakiSpecjalne, cyfry, duzeLitery,maleLitery;
        private List<int> Opcje = new List<int>();
        private void utworzOpcje()
        {
            if (maleLitery == true)
            {
                Opcje.Add(0);
            }
            if (znakiSpecjalne == true)
            {
                Opcje.Add(1);
            }
            if (cyfry == true)
            {
                Opcje.Add(2);
            }
            if (duzeLitery == true)
            {
                Opcje.Add(3);
            }
          
        }
        public Haslo(string nazwaDlaHasla)
        {
            nazwa = nazwaDlaHasla;
            znakiSpecjalne = false;
            cyfry = false;
            duzeLitery = false;
            maleLitery = true;
            utworzOpcje();


        }
        public Haslo(string nazwaDlaHasla,bool znaki, bool cyf,bool duze,bool male)
        {
            nazwa = nazwaDlaHasla;
            znakiSpecjalne = znaki;
            cyfry = cyf;
            duzeLitery = duze;
            maleLitery = male;
            utworzOpcje();

        }
       

        public void Generuj(int dlugosc)
        {
             Random losuj = new Random();

            for (int i = 0; i < dlugosc; i++)
            {
                int opcja =Opcje[losuj.Next(0, Opcje.Count)];
                
                string znak="";
                switch (opcja)
                {
                    case 0:
                        znak = gen3.losujZnak();
                        break;
                    case 1:
                        znak = gen2.losujZnak();
                        break;
                    case 2:
                        znak = gen.losujZnak();
                        break;
                    case 3:
                        znak = gen3.losujZnak(true);
                        break;
                }

                haslo += znak;

            }

        }
        public string WezHaslo()
        {
            return haslo;
        }
        public string wezNazwe()
        {
            return nazwa;
        }



}





    class Program
    {

        static void Main(string[] args)
        {
            /* GenerujCyfre gen = new GenerujCyfre();
             GenerujZnakSpecjalny gen2 = new GenerujZnakSpecjalny();
             GenerujLitere gen3 = new GenerujLitere();
             Haslo haslo = new Haslo("Haslo do szafki",true,true,true,true);
             haslo.Generuj(256);*/
            Interfejs Inter = new Interfejs();

            Inter.UruchomProgram();
          


        }
    }
}
