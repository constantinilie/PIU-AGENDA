using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obiect.Enumerari;

namespace Obiect
{
    public class Activitate   // Am creeat clasa- TEMA LAB 2
    {
        public string Nume { get; set; } // Numele activitatii
        public string Descriere { get; set; } // Descrierea activitatii
        public string Tip { get; set; } // Tipul activitatii (ex: Scoala, munca, recreere)
        public DateTime DataOra { get; set; } // data si ora
        public string[] Optiuni { get; set; }// Optiuni (ex: Notificari, Repetare, Alarme)

        public int nrActivitate { get; set; }



        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        private const int IDACTIVITATE = 0;
        private const int NUME = 1;
        private const int TIP = 2;
        private const int DATA = 3;
        private const int DESCRIERE = 4;
        private const int OPTIUNI = 5;

        
        public Activitate(string nume, string descriere, string tip, DateTime dataOra, string[] optiuni) //Constructor cu parametri
        {
            Nume = nume;
            Descriere = descriere;
            Tip = tip;
            DataOra = dataOra;
            Optiuni = optiuni;
        }
        public Activitate() //Constructor fara parametri
        {
            Nume = Descriere = Tip = string.Empty;
            DataOra = DateTime.MinValue;
        }

        public Activitate(string linieFisier)
        {

            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.nrActivitate = Convert.ToInt32(dateFisier[IDACTIVITATE]);
            this.Nume = dateFisier[NUME];
            this.DataOra = DateTime.Parse(dateFisier[DATA]);
            this.Descriere = dateFisier[DESCRIERE];
            this.Tip = dateFisier[TIP];
            this.Optiuni = dateFisier[OPTIUNI].Split(',');
        }

        public string InfoActivitate()
        {
            string info = $"Nume:{Nume ?? "NECUNOSCUT"}\nDescriere:{Descriere ?? "NECUNOSCUT"}\nTip:{Tip ?? "NECUNOSCUT"}\nData si ora:{DataOra}\n";
            return info;
        }

        public string ConversieLaSir_PentruFisier()
        {
            DateTime dataora;
            if (DateTime.TryParse(DataOra.ToString(), out dataora))
            {
                dataora = DataOra;
            }
            else
            {
                dataora = DateTime.MinValue;
            }
            string optiuniString = string.Join(",", Optiuni);
            string activitatePentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                SEPARATOR_PRINCIPAL_FISIER,
                nrActivitate.ToString(),
                (Nume ?? " NECUNOSCUT "),
                (Tip ?? " NECUNOSCUT "),
                dataora.ToString(),
            (Descriere ?? " NECUNOSCUT "),
            (optiuniString ?? "NECUNOSCUT")
                );

            return activitatePentruFisier;
        }


    }
}
