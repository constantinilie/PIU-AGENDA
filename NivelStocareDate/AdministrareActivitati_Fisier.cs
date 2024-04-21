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
    }
}
