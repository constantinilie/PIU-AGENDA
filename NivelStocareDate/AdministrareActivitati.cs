using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Obiect;

namespace NivelStocareDate
{
    public class AdministrareActivitati // Am creeat clasa- TEMA LAB 2
    {
        private const int NR_MAX_ACTIVITATI = 50;
        private Activitate[] activitati;
        private int nrActivitati;


        public AdministrareActivitati()
        {
            activitati = new Activitate[NR_MAX_ACTIVITATI];
            nrActivitati = 0;
        }

        public void AdaugaActivitate(Activitate activitate) //TEMA LAB3 - Salvarea datelor intr-un vector
        {
            activitati[nrActivitati] = activitate;
            nrActivitati++;
        }
        public Activitate[] GetActivitati(out int nrActivitati) //TEMA LAB3- Returneaza un vector pentru afisare
        {
            nrActivitati = this.nrActivitati;
            return activitati;
        }
        public Activitate[] CautaDupaTip(string tipCautat) //TEMA LAB3- Cauta dupa un anumit criteriu: DUPA TIPUL DE ACTIVITATE
        {
            Activitate[] activitatiGasite = new Activitate[NR_MAX_ACTIVITATI];
            int nrActivitateGasita = 0;
            foreach (Activitate activitate in activitati)
            {

                if (activitate != null && activitate.Tip.ToUpper() == tipCautat.ToUpper())
                {
                    activitatiGasite[nrActivitateGasita] = activitate;
                    nrActivitateGasita++;
                }
            }
            Array.Resize(ref activitatiGasite, nrActivitateGasita);
            return activitatiGasite;
        }

        public Activitate[] CautaDupaNume(string numeCautat) //TEMA LAB3- Cauta dupa un anumit criteriu: DUPA NUMELE ACTIVITATII
        {
            Activitate[] activitatiGasite = new Activitate[NR_MAX_ACTIVITATI];
            int nrActivitateGasita = 0;
            foreach (Activitate activitate in activitati)
            {

                if (activitate != null && activitate.Nume.ToUpper() == numeCautat.ToUpper())
                {
                    activitatiGasite[nrActivitateGasita] = activitate;
                    nrActivitateGasita++;
                }
            }
            Array.Resize(ref activitatiGasite, nrActivitateGasita);
            return activitatiGasite;
        }

    }
}
