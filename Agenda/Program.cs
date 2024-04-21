using System;
using System.IO;
using System.Configuration;
using Obiect;
using NivelStocareDate;
using Obiect.Enumerari;

namespace Agenda
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            string numeFisier = "Activitati.txt";
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            AdministrareActivitati adminActivitati= new AdministrareActivitati();
            AdministrareActivitati_Fisier adminActivitatiFisier = new AdministrareActivitati_Fisier(caleCompletaFisier);
            Activitate activitateNoua = new Activitate();
            Utilizator utilizator= new Utilizator();
            int nrActivitati = 0;
            string optiune;
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("U.Introdu utilizator");
                Console.WriteLine("P.Afiseaza utilizatorul agendei");
                Console.WriteLine("C.Citire informatii activitate de la tastatura");
                Console.WriteLine("I.Afisarea informatiilor despre ultima activitate introdusa");
                Console.WriteLine("A.Afisare activitati din fisier");
                Console.WriteLine("S.Salvare activitate in vector de obiecte si in fisier");
                Console.WriteLine("K.Cauta o activitate dupa tip");
                Console.WriteLine("N.Cauta o activitate dupa nume");
                Console.WriteLine("X.Inchidere program");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Alegeti o optiune:");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "U":
                        utilizator=CitireUtilizatorTastatura();
                        break;
                    case "P":
                        Console.WriteLine(AfisareUtilizator(utilizator));
                        break;
                    case "C":
                        activitateNoua = CitireActivitateTastatura();
                        break;
                    case "I":
                        AfisareActivitate(activitateNoua);
                        break;
                    case "S":
                        adminActivitati.AdaugaActivitate(activitateNoua);
                        adminActivitatiFisier.AdaugaActivitate(activitateNoua);
                        nrActivitati++;
                        
                        break;
                    case "A":
                        Activitate[] activitati = adminActivitati.GetActivitati(out nrActivitati);
                        AfisareActivitati(activitati, nrActivitati);
                        break;
                    case "D":
                        Activitate[] activitatiFisier = adminActivitatiFisier.GetActivitati(out nrActivitati);
                        AfisareActivitati(activitatiFisier, nrActivitati);
                        break;
                    case "K":
                        Console.Write("Introduceti tipul activitatii dorite: ");
                        string tipCautat=Console.ReadLine();
                        Activitate[] activitatiGasite_Tip = adminActivitati.CautaDupaTip(tipCautat);
                        AfisareActivitati(activitatiGasite_Tip, activitatiGasite_Tip.Length);
                        break;
                    case "N":
                        Console.Write("Introduceti numele activitatii dorite: ");
                        string numeCautat = Console.ReadLine();
                        Activitate[] activitatiGasite_Nume = adminActivitati.CautaDupaNume(numeCautat);
                        AfisareActivitati(activitatiGasite_Nume, activitatiGasite_Nume.Length);
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");
        }
        


        public static Activitate CitireActivitateTastatura() // Tema LAB3 - Citire date tastatura
        {
            DateTime dateTime;
            bool k = false;
            Console.Write("Introduceti numele activitatii:");
            string nume = Console.ReadLine();
            Console.Write("Introduceti descrierea activitatii:");
            string descriere= Console.ReadLine();
            int tipInt = 0;
            do
            {
                Console.WriteLine("Introduceti tipul activitatii:");
                Console.WriteLine(" 1 - Scoala \n 2 - Facultate \n 3 - Serviciu\n 4 - Recreere\n 5 - Reminder");
                tipInt = Convert.ToInt32(Console.ReadLine());
                
                
            } while (tipInt > 5 && tipInt < 1);
            string tip = Convert.ToString((TipActivitate)tipInt);

            Console.WriteLine("Lista optiuni:\n 1 - Notificari\n 2 - Repetare\n 4 - Alarme\n");
            Console.Write("Introduceti optiunile[ separate prin spatiu ] ");
            string[] optiuniString=Console.ReadLine().Split(' ');
            OptiuniActivitate optiuni = OptiuniActivitate.Fara;
            string[] Optiuni= new string[0];
            foreach (var optiuneString in optiuniString)
            {   
                if(int.TryParse(optiuneString, out int optiuneInt))
                {
                    optiuni |= (OptiuniActivitate)optiuneInt;
                    Array.Resize(ref Optiuni, Optiuni.Length + 1);
                    Optiuni[Optiuni.Length - 1] = Convert.ToString((OptiuniActivitate)optiuneInt);

                }
            }
            




            do
            {
                Console.WriteLine("Introduceti data si ora ( zz-ll-aaaa hh:mm:ss):");
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out dateTime))
                {
                    k = true;

                }
                else
                {
                    Console.WriteLine("Formatul este incorect, reintroduceti!");
                }
            } while (!k);
            
            Activitate activitate = new Activitate( nume, descriere, tip ,dateTime, Optiuni);
            return activitate;
            
        }

        public static void AfisareActivitate(Activitate activitate)
        {
            string optiuniString = string.Join(",", activitate.Optiuni);
            string infoActivitate = string.Format($"Ultima activitate introdusa:\nNume:{activitate.Nume}\nDescriere:{activitate.Descriere}\n" +
                $"Tip:{activitate.Tip}\nOptiuni: {optiuniString}\nData si ora:{activitate.DataOra}\n");
            Console.WriteLine(infoActivitate);
        } 
        public static void AfisareActivitati(Activitate[] activitati, int nrActivitati ) //TEMA LAB 3- Afisare datelor din vector
        {
            Console.WriteLine("Activitatile sunt:");
            for (int contor=0; contor<nrActivitati; contor++)
            {
                string infoActivitate = activitati[contor].InfoActivitate();
                Console.WriteLine(infoActivitate);
            }
        } 
        public static Utilizator CitireUtilizatorTastatura() //TEMA LAB 4 - Citire date utilizator de la tastatura
        {
            Console.Write("Introduceti numele:");
            string nume = Console.ReadLine();
            Console.Write("Introduceti prenumele:");
            string prenume=Console.ReadLine();
            Utilizator utilizator= new Utilizator(nume,prenume);
            return utilizator;
        }
        public static string AfisareUtilizator(Utilizator utilizator) //TEMA LAB4- Afisare date utilizator
        {
            string infoUtilizator = $"Utilizatorul are numele {utilizator.Nume} si prenumele {utilizator.Prenume}";
            return infoUtilizator;
        }
    }
    
}
