using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Obiect;
using NivelStocareDate;

namespace Agenda_UI_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareActivitati_Fisier adminActivitati;
        private Label lblNume;
        private Label lblDescriere;
        private Label lblTip;
        private Label lblDataOra;
        private Label lblOptiuni;

        private Label[] lblsNume;
        private Label[] lblsDescriere;
        private Label[] lblsTip;
        private Label[] lblsDataOra;
        private Label[] lblsOptiuni;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;
        public Form1()
        {
            InitializeComponent();
            string numeFisier = "Activitati.txt";
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminActivitati = new AdministrareActivitati_Fisier(caleCompletaFisier);
            int nrActivitati = 0;
            Activitate[] activitati = adminActivitati.GetActivitati(out nrActivitati);

            this.Size = new Size(700, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Tahoma", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Informatii activitati";

            //adaugare control de tip Label pentru Nume;
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.DarkCyan;
            lblNume.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblNume);

            //adaugare control de tip Label pentru Descriere;
            lblDescriere = new Label();
            lblDescriere.Width = LATIME_CONTROL;
            lblDescriere.Text = "Descriere";
            lblDescriere.Left = 2 * DIMENSIUNE_PAS_X;
            lblDescriere.ForeColor = Color.DarkCyan;
            lblDescriere.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblDescriere);

            //adaugare control de tip Label pentru Tip;
            lblTip = new Label();
            lblTip.Width = LATIME_CONTROL;
            lblTip.Text = "Tip";
            lblTip.Left = 3 * DIMENSIUNE_PAS_X;
            lblTip.ForeColor = Color.DarkCyan;
            lblTip.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblTip);

            //adaugare control de tip Label pentru DataOra;
            lblDataOra = new Label();
            lblDataOra.Width = LATIME_CONTROL;
            lblDataOra.Text = "Data si ora";
            lblDataOra.Left = 4 * DIMENSIUNE_PAS_X;
            lblDataOra.ForeColor = Color.DarkCyan;
            lblDataOra.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblDataOra);


            //adaugare control de tip Label pentru Optiuni;
            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Left = 5 * DIMENSIUNE_PAS_X;
            lblOptiuni.ForeColor = Color.DarkCyan;
            lblOptiuni.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblOptiuni);

            AfiseazaActivitati();
        }


        private void AfiseazaActivitati() //TEMA LAB6
        {
            Activitate[] activitati = adminActivitati.GetActivitati(out int nrActivitati);
            lblsNume = new Label[nrActivitati];
            lblsDescriere = new Label[nrActivitati];
            lblsTip = new Label[nrActivitati];
            lblsDataOra = new Label[nrActivitati];
            lblsOptiuni = new Label[nrActivitati];

            int i = 0;
            foreach (Activitate activitate in activitati)
            {


                //adaugare control de tip Label pentru numele activitatilor;
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = activitate.Nume;
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsNume[i].ForeColor = Color.Blue;
                this.Controls.Add(lblsNume[i]);

                //adaugare control de tip Label pentru descrierea activitatilor;
                lblsDescriere[i] = new Label();
                lblsDescriere[i].Width = LATIME_CONTROL;
                lblsDescriere[i].Text = activitate.Descriere;
                lblsDescriere[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsDescriere[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsDescriere[i].ForeColor = Color.BlueViolet;

                this.Controls.Add(lblsDescriere[i]);

                //adaugare control de tip Label pentru Tipul activitatilor;
                lblsTip[i] = new Label();
                lblsTip[i].Width = LATIME_CONTROL;
                lblsTip[i].Text = activitate.Tip;
                lblsTip[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsTip[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsTip[i].ForeColor = Color.Blue;
                this.Controls.Add(lblsTip[i]);

                //adaugare control de tip Label pentru Data si ora activitatilor;
                lblsDataOra[i] = new Label();
                lblsDataOra[i].Width = LATIME_CONTROL;
                lblsDataOra[i].Text = Convert.ToString(activitate.DataOra);
                lblsDataOra[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsDataOra[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsDataOra[i].ForeColor = Color.BlueViolet;
                this.Controls.Add(lblsDataOra[i]);

                //adaugare control de tip Label pentru Optiunea activitatilor;
                string optiunistr = string.Join(",", activitate.Optiuni);
                lblsOptiuni[i] = new Label();
                lblsOptiuni[i].Width = LATIME_CONTROL;
                lblsOptiuni[i].Text = Convert.ToString(optiunistr);
                lblsOptiuni[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblsOptiuni[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsOptiuni[i].ForeColor = Color.Blue;
                lblsOptiuni[i].AutoSize = true;

                this.Controls.Add(lblsOptiuni[i]);

                i++;
            }

        }
    }
}
