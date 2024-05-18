using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obiect;
namespace NivelStocareDate
{
    public class AdministrareActivitati_Fisier
    {
        private const int NR_MAX_ACTIVITATI = 50;
        private string numeFisier;

        public AdministrareActivitati_Fisier(string numeFisier)
        {
            this.numeFisier = numeFisier;

            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugaActivitate(Activitate activitate)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(activitate.ConversieLaSir_PentruFisier());
            }
        }

        public Activitate[] GetActivitati(out int nrActivitati)
        {
            Activitate[] studenti = new Activitate[NR_MAX_ACTIVITATI];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrActivitati = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    studenti[nrActivitati++] = new Activitate(linieFisier);
                }
            }

            Array.Resize(ref studenti, nrActivitati);

            return studenti;
        }
        public void StergeActivitate(Activitate activitate)
        {
            string tempFile = Path.GetTempFileName();

            using (StreamReader reader = new StreamReader(numeFisier))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                string linie;
                bool activitateStearsa = false;

                while ((linie = reader.ReadLine()) != null)
                {
                    if (!activitateStearsa && linie.Equals(activitate.ConversieLaSir_PentruFisier()))
                    {
                        activitateStearsa = true;
                        continue; // Sărim peste activitatea de șters
                    }

                    writer.WriteLine(linie);
                }
            }

            File.Delete(numeFisier);
            File.Move(tempFile, numeFisier);
        }
        public Activitate[] CautaDupaTip(string tipCautat)
        {
            Activitate[] activitatiGasite = new Activitate[NR_MAX_ACTIVITATI];
            int nrActivitateGasita = 0;

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Activitate activitate = new Activitate(linieFisier);
                    if (activitate.Tip.ToUpper() == tipCautat.ToUpper())
                    {
                        activitatiGasite[nrActivitateGasita] = activitate;
                        nrActivitateGasita++;
                    }
                }
            }

            Array.Resize(ref activitatiGasite, nrActivitateGasita);
            return activitatiGasite;
        }
        public Activitate[] CautaDupaNume(string numeCautat)
        {
            Activitate[] activitatiGasite = new Activitate[NR_MAX_ACTIVITATI];
            int nrActivitateGasita = 0;

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Activitate activitate = new Activitate(linieFisier);
                    if (activitate.Nume.ToUpper() == numeCautat.ToUpper())
                    {
                        activitatiGasite[nrActivitateGasita] = activitate;
                        nrActivitateGasita++;
                    }
                }
            }

            Array.Resize(ref activitatiGasite, nrActivitateGasita);
            return activitatiGasite;
        }
    }
}
