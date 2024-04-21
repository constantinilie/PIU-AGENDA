using NivelStocareDate;
using Obiect;
using Obiect.Enumerari;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda_UI_WindowsForms
{
    public partial class CitireSiAfisare : Form
    {
        AdministrareActivitati_Fisier adminActivitati;
        private Label lblNume;
        private Label lblDescriere;
        private Label lblTip;
        private Label lblDataOra;
        private Label lblOptiuni;

        private TextBox txtNume;
        private TextBox txtDescriere;
        private ComboBox cmbTip;
        private DateTimePicker dtpDataOra;
        private ComboBox cmbOptiuni;


        private Button btnAdauga;
        private Button btnAfiseaza;

        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;
        private const int LATIME_CONTROL = 100;
        private const int LATIME_CONTROL_DESCRIERE = 300;
        private const int LUNGIME_CONTROL_DESCRIERE = 100;
        private const int LATIME_CONTROL_TEXT = 300;
        private const int LATIME_CONTROL_BUTON = 200;
        public CitireSiAfisare()
        {
            InitializeComponent();
            BackColor = Color.Beige;
            string numeFisier = "Activitati.txt";
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminActivitati = new AdministrareActivitati_Fisier(caleCompletaFisier);
            int nrActivitati = 0;
            Activitate[] activitati = adminActivitati.GetActivitati(out nrActivitati);

            this.Size = new Size(1000, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Tahoma", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Agenda de activitati";

            //adaugare control de tip Label pentru Nume;
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.Top = DIMENSIUNE_PAS_Y;
            lblNume.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblNume);

            //adaugare control de tip TextBox pentru Nume;
            txtNume = new TextBox();
            txtNume.Width = LATIME_CONTROL_TEXT;
            txtNume.Left = 2 * DIMENSIUNE_PAS_X;
            txtNume.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtNume);

            //adaugare control de tip Label pentru Descriere;
            lblDescriere = new Label();
            lblDescriere.Width = LATIME_CONTROL;
            lblDescriere.Text = "Descriere";
            lblDescriere.Left = DIMENSIUNE_PAS_X;
            lblDescriere.Top = 2 * DIMENSIUNE_PAS_Y;
            lblDescriere.ForeColor = Color.DarkBlue;

            //adaugare control de tip TextBox pentru Descriere;
            txtDescriere = new TextBox();
            txtDescriere.Width = LATIME_CONTROL_DESCRIERE;
            txtDescriere.Height = LUNGIME_CONTROL_DESCRIERE;
            txtDescriere.Left = 2 * DIMENSIUNE_PAS_X;
            txtDescriere.Top = 2 * DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtDescriere);

            this.Controls.Add(lblDescriere);

            //adaugare control de tip Label pentru Tip;
            lblTip = new Label();
            lblTip.Width = LATIME_CONTROL;
            lblTip.Text = "Tip";
            lblTip.Left = DIMENSIUNE_PAS_X;
            lblTip.Top = 3 * DIMENSIUNE_PAS_Y;
            lblTip.ForeColor = Color.DarkBlue;

            this.Controls.Add(lblTip);

            //adaugare control de tip ComboBox pentru Tip;
            cmbTip = new ComboBox();
            cmbTip.DataSource = Enum.GetValues(typeof(Obiect.Enumerari.TipActivitate));
            cmbTip.FormattingEnabled = true;
            cmbTip.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTip.Width = LATIME_CONTROL_TEXT; ;
            cmbTip.Left = 2 * DIMENSIUNE_PAS_X;
            cmbTip.Top = 3 * DIMENSIUNE_PAS_Y;
            cmbTip.ForeColor = Color.DarkBlue;
            this.Controls.Add((cmbTip));

            //adaugare control de tip Label pentru DataOra;
            lblDataOra = new Label();
            lblDataOra.Width = LATIME_CONTROL;
            lblDataOra.Text = "Data si ora";
            lblDataOra.Left = DIMENSIUNE_PAS_X;
            lblDataOra.Top = 4 * DIMENSIUNE_PAS_Y;
            lblDataOra.ForeColor = Color.DarkBlue;

            this.Controls.Add(lblDataOra);

            //adaugare control de tip DateTimePicker pentru DataOra;

            dtpDataOra = new DateTimePicker();
            dtpDataOra.Width = LATIME_CONTROL_TEXT;
            dtpDataOra.Format = DateTimePickerFormat.Custom;
            dtpDataOra.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            dtpDataOra.Left = 2 * DIMENSIUNE_PAS_X;
            dtpDataOra.Top = 4 * DIMENSIUNE_PAS_Y;
            this.Controls.Add(dtpDataOra);

            //adaugare control de tip Label pentru Optiuni;
            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Left = DIMENSIUNE_PAS_X;
            lblOptiuni.Top = 5 * DIMENSIUNE_PAS_Y;
            lblOptiuni.ForeColor = Color.DarkBlue;

            this.Controls.Add(lblOptiuni);

            //adaugare control de tip ComboBox pentru Optiuni;
            cmbOptiuni = new ComboBox();
            cmbOptiuni.DataSource = Enum.GetValues(typeof(Obiect.Enumerari.OptiuniActivitate));
            cmbOptiuni.FormattingEnabled = true;

            cmbOptiuni.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOptiuni.Width = LATIME_CONTROL_TEXT; ;
            cmbOptiuni.Left = 2 * DIMENSIUNE_PAS_X;
            cmbOptiuni.Top = 5 * DIMENSIUNE_PAS_Y;
            cmbOptiuni.ForeColor = Color.DarkBlue;
            this.Controls.Add((cmbOptiuni));


            //adaugare control de tip Button pentru a adauga o activitate;
            btnAdauga = new Button();
            btnAdauga.BackColor = Color.LightGreen;
            btnAdauga.Width = LATIME_CONTROL_BUTON;
            btnAdauga.Text = "Adauga Activitatea";
            btnAdauga.Left = 4*DIMENSIUNE_PAS_X;
            btnAdauga.Top = 4 * DIMENSIUNE_PAS_Y;
            btnAdauga.Click += OnButtonClicked_Adauga;
            btnAdauga.ForeColor = Color.Black;
            this.Controls.Add(btnAdauga);

            //adaugare control de tip Button pentru a afisa activitatile;

            btnAfiseaza = new Button();
            btnAfiseaza.BackColor = Color.LightYellow;
            btnAfiseaza.Width = LATIME_CONTROL_BUTON;
            btnAfiseaza.Text = "Afiseaza Activitati";
            btnAfiseaza.Left = 4 * DIMENSIUNE_PAS_X;
            btnAfiseaza.Top = 5 * DIMENSIUNE_PAS_Y;
            btnAfiseaza.Click += OnButtonClicked_Afiseaza;
            btnAfiseaza.ForeColor = Color.Black;
            this.Controls.Add(btnAfiseaza);

        }
        private void OnButtonClicked_Afiseaza(object sender, EventArgs e)
        {
            AfiseazaActivitati();
        }

        private void OnButtonClicked_Adauga(object sender, EventArgs e)
        {
            Activitate activitate = CitireActivitate();
            if( activitate != null )
            {
                adminActivitati.AdaugaActivitate(activitate);
            }

            txtNume.Text = string.Empty;
            txtDescriere.Text = string.Empty;
            cmbTip.SelectedIndex = 0;
            cmbOptiuni.SelectedIndex = 0;
           
        }

        private Activitate CitireActivitate()
        {
            bool SUCCES = true;
            if (txtNume.Text == string.Empty)
            {
                MessageBox.Show("Nu ati introdus numele activitatii!");
                lblNume.ForeColor = Color.DarkRed;
                SUCCES = false;
            }
            if(txtDescriere.Text == string.Empty)
            {
                MessageBox.Show("Nu ati introdus descrierea!");
                lblDescriere.ForeColor = Color.DarkRed;
                SUCCES = false;
            }

            if (SUCCES == true)
            {
                lblNume.ForeColor = Color.DarkBlue;
                lblDescriere.ForeColor=Color.DarkBlue;
                string nume = txtNume.Text.Trim();
                string descriere = txtDescriere.Text.Trim();
                string tip = cmbTip.Text;
                DateTime dataora = dtpDataOra.Value;
                string[] optiuni = cmbOptiuni.Text.Split(' ');

                Activitate activitate = new Activitate(nume, descriere, tip, dataora, optiuni);

                return activitate;
            }
            else
            {
                return null;
            }




        }


        private void AfiseazaActivitati() //TEMA LAB6
        {
            Activitate[] activitati = adminActivitati.GetActivitati(out int nrActivitati);
            Label[] lblsNume = new Label[nrActivitati];
            Label[] lblsDescriere = new Label[nrActivitati];
            Label[] lblsTip = new Label[nrActivitati];
            Label[] lblsDataOra = new Label[nrActivitati];
            Label[] lblsOptiuni = new Label[nrActivitati];


            //adaugare control de tip Label pentru Nume;
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.TextAlign = ContentAlignment.MiddleCenter;
            lblNume.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.Top= 7*DIMENSIUNE_PAS_Y;
            lblNume.ForeColor = Color.DarkBlue;
            lblNume.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblNume);

            //adaugare control de tip Label pentru Descriere;
            lblDescriere = new Label();
            lblDescriere.Width = LATIME_CONTROL;
            lblDescriere.Text = "Descriere";
            lblDescriere.TextAlign = ContentAlignment.MiddleCenter;
            lblDescriere.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblDescriere.Left = 5 * DIMENSIUNE_PAS_X;
            lblDescriere.Top = 7 * DIMENSIUNE_PAS_Y;
            lblDescriere.ForeColor = Color.DarkBlue;
            lblDescriere.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblDescriere);

            //adaugare control de tip Label pentru Tip;
            lblTip = new Label();
            lblTip.Width = LATIME_CONTROL;
            lblTip.Text = "Tip";
            lblTip.TextAlign = ContentAlignment.MiddleCenter;
            lblTip.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblTip.Left = 3 * DIMENSIUNE_PAS_X;
            lblTip.Top = 7 * DIMENSIUNE_PAS_Y;
            lblTip.ForeColor = Color.DarkBlue;
            lblTip.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblTip);

            //adaugare control de tip Label pentru DataOra;
            lblDataOra = new Label();
            lblDataOra.Width = LATIME_CONTROL;
            lblDataOra.Text = "Data si ora";
            lblDataOra.TextAlign = ContentAlignment.MiddleCenter;
            lblDataOra.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblDataOra.Left = 4 * DIMENSIUNE_PAS_X;
            lblDataOra.Top = 7 * DIMENSIUNE_PAS_Y;
            lblDataOra.ForeColor = Color.DarkBlue;
            lblDataOra.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblDataOra);


            //adaugare control de tip Label pentru Optiuni;
            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.TextAlign = ContentAlignment.MiddleCenter;
            lblOptiuni.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblOptiuni.Left = 2 * DIMENSIUNE_PAS_X;
            lblOptiuni.Top = 7 * DIMENSIUNE_PAS_Y;
            lblOptiuni.ForeColor = Color.DarkBlue;
            lblOptiuni.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblOptiuni);

            int i = 0;
            foreach (Activitate activitate in activitati)
            {


                //adaugare control de tip Label pentru numele activitatilor;
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = activitate.Nume;
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = (i + 8) * DIMENSIUNE_PAS_Y;
                lblsNume[i].ForeColor = Color.Black;
                this.Controls.Add(lblsNume[i]);

                //adaugare control de tip Label pentru descrierea activitatilor;
                lblsDescriere[i] = new Label();
                lblsDescriere[i].Width = LATIME_CONTROL_DESCRIERE;
                lblsDescriere[i].Text = activitate.Descriere;
                lblsDescriere[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblsDescriere[i].Top = (i + 8) * DIMENSIUNE_PAS_Y;
                lblsDescriere[i].ForeColor = Color.Black;

                this.Controls.Add(lblsDescriere[i]);

                //adaugare control de tip Label pentru Tipul activitatilor;
                lblsTip[i] = new Label();
                lblsTip[i].Width = LATIME_CONTROL;
                lblsTip[i].Text = activitate.Tip;
                lblsTip[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsTip[i].Top = (i + 8) * DIMENSIUNE_PAS_Y;
                lblsTip[i].ForeColor = Color.Black;
                this.Controls.Add(lblsTip[i]);

                //adaugare control de tip Label pentru Data si ora activitatilor;
                lblsDataOra[i] = new Label();
                lblsDataOra[i].Width = LATIME_CONTROL;
                lblsDataOra[i].Text = Convert.ToString(activitate.DataOra);
                lblsDataOra[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsDataOra[i].Top = (i + 8) * DIMENSIUNE_PAS_Y;
                lblsDataOra[i].ForeColor = Color.Black;
                this.Controls.Add(lblsDataOra[i]);

                //adaugare control de tip Label pentru Optiunea activitatilor;
                string optiunistr = string.Join(",", activitate.Optiuni);
                lblsOptiuni[i] = new Label();
                lblsOptiuni[i].Width = LATIME_CONTROL;
                lblsOptiuni[i].Text = Convert.ToString(optiunistr);
                lblsOptiuni[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsOptiuni[i].Top = (i + 8) * DIMENSIUNE_PAS_Y;
                lblsOptiuni[i].ForeColor = Color.Black;
                lblsOptiuni[i].AutoSize = true;

                this.Controls.Add(lblsOptiuni[i]);

                i++;
            }
        }
    }
}
