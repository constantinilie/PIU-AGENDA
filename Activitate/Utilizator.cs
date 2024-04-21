using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiect
{
    public class Utilizator  // TEMA LAB4- Am creat clasa utilizator 
    {
        public string Nume { get; set; } // Numele utilizatorului
        public string Prenume { get; set; } //Prenumele utilizatorului

        public Utilizator() //Constructor implicit
        {
            this.Nume = string.Empty;
            this.Prenume = string.Empty;
        }
        public Utilizator(string nume, string prenume) //Constructor
        {
            this.Nume = nume;
            this.Prenume = prenume;
        }

        public string InfoUtilizator()
        {
            string info = $"Nume:{Nume} , Prenume:{Prenume}";
            return info;
        }
    }
}
