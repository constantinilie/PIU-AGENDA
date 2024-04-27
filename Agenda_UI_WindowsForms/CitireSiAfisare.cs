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
        private Label lblCauta;

        private Label lblNume2;
        private Label lblDescriere2;
        private Label lblTip2;
        private Label lblDataOra2;
        private Label lblOptiuni2;

        private TextBox txtNume;
        private TextBox txtDescriere;
        private ComboBox cmbTip;
        private DateTimePicker dtpDataOra;
        
        
        private CheckBox checkOptiuni;
        private CheckBox checkOptiuni2;
        private CheckBox checkOptiuni3;

        private ComboBox cmbCautaDupa;
        private TextBox txtCautaDupa;

        private Button btnAdauga;
        private Button btnAfiseaza;
        private Button btnRedimensioneaza;
        private Button btnCauta;

        private Panel panelLinie;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 100;
        private const int DIMENSIUNE_PAS_X_MARE = 155;

        private const int LATIME_CONTROL = 100;
        private const int LATIME_CONTROL_DESCRIERE = 300;
        private const int LUNGIME_CONTROL_DESCRIERE = 100;
        private const int LATIME_CONTROL_TEXT = 300;
        private const int LATIME_CONTROL_BUTON = 200;
        private const int LATIME_CONTROL_CHECKBOX = 100;
        
        public CitireSiAfisare()
        {
            
            BackColor = Color.Beige;
            string numeFisier = "Activitati.txt";
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminActivitati = new AdministrareActivitati_Fisier(caleCompletaFisier);
            
            int nrActivitati = 0;
            Activitate[] activitati = adminActivitati.GetActivitati(out nrActivitati);

            this.Size = new Size(615, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Tahoma", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Agenda de activitati";

            #region Elementele principale
            //am adaugat o linie despartitoare 
            panelLinie = new Panel();
            panelLinie.Location = new Point(600, 0);
            panelLinie.Size = new Size(2, 2000);
            panelLinie.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panelLinie);
            panelLinie=new Panel();
            panelLinie.Location = new Point(0, 6 * DIMENSIUNE_PAS_Y);
            panelLinie.Size = new Size(600, 2);
            panelLinie.BorderStyle= BorderStyle.FixedSingle;
            this.Controls.Add(panelLinie);
            //adaugare control de tip Label pentru Nume;
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL-50;
            lblNume.Text = "Nume";
            lblNume.Left = 0*DIMENSIUNE_PAS_X+10;
            lblNume.Top = DIMENSIUNE_PAS_Y;
            lblNume.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblNume);

            //adaugare control de tip TextBox pentru Nume;
            txtNume = new TextBox();
            txtNume.Width = LATIME_CONTROL_TEXT;
            txtNume.Left = 1 * DIMENSIUNE_PAS_X;
            txtNume.Top = DIMENSIUNE_PAS_Y;
            txtNume.GotFocus += txt_OnFocus;
            txtNume.LostFocus += txt_LostFocus;
            this.Controls.Add(txtNume);

            //adaugare control de tip Label pentru Descriere;
            lblDescriere = new Label();
            lblDescriere.Width = LATIME_CONTROL-15;
            lblDescriere.Text = "Descriere";
            lblDescriere.Left = 0*DIMENSIUNE_PAS_X+10;
            lblDescriere.Top = 2 * DIMENSIUNE_PAS_Y;
            lblDescriere.ForeColor = Color.DarkBlue;

            //adaugare control de tip TextBox pentru Descriere;
            txtDescriere = new TextBox();
            txtDescriere.Width = LATIME_CONTROL_DESCRIERE;
            txtDescriere.Height = LUNGIME_CONTROL_DESCRIERE;
            txtDescriere.Left = 1 * DIMENSIUNE_PAS_X;
            txtDescriere.Top = 2 * DIMENSIUNE_PAS_Y;
            txtDescriere.GotFocus += txt_OnFocus;
            txtDescriere.LostFocus  += txt_LostFocus;
            this.Controls.Add(txtDescriere);

            this.Controls.Add(lblDescriere);

            //adaugare control de tip Label pentru Tip;
            lblTip = new Label();
            lblTip.Width = LATIME_CONTROL - 50;
            lblTip.Text = "Tip";
            lblTip.Left = 0*DIMENSIUNE_PAS_X+10;
            lblTip.Top = 3 * DIMENSIUNE_PAS_Y;
            lblTip.ForeColor = Color.DarkBlue;

            this.Controls.Add(lblTip);

            //adaugare control de tip ComboBox pentru Tip;
            cmbTip = new ComboBox();
            cmbTip.DataSource = Enum.GetValues(typeof(Obiect.Enumerari.TipActivitate));
            cmbTip.FormattingEnabled = true;
            cmbTip.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTip.Width = LATIME_CONTROL_DESCRIERE; ;
            cmbTip.Left = 1 * DIMENSIUNE_PAS_X;
            cmbTip.Top = 3 * DIMENSIUNE_PAS_Y;
            cmbTip.ForeColor = Color.DarkBlue;
            this.Controls.Add((cmbTip));

            //adaugare control de tip Label pentru DataOra;
            lblDataOra = new Label();
            lblDataOra.Width = LATIME_CONTROL-15;
            lblDataOra.Text = "Data si ora";
            lblDataOra.Left = 0*DIMENSIUNE_PAS_X+10;
            lblDataOra.Top = 4 * DIMENSIUNE_PAS_Y;
            lblDataOra.ForeColor = Color.DarkBlue;

            this.Controls.Add(lblDataOra);

            //adaugare control de tip DateTimePicker pentru DataOra;

            dtpDataOra = new DateTimePicker();
            dtpDataOra.Width = LATIME_CONTROL_TEXT;
            dtpDataOra.Format = DateTimePickerFormat.Custom;
            dtpDataOra.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            dtpDataOra.Left = 1 * DIMENSIUNE_PAS_X;
            dtpDataOra.Top = 4 * DIMENSIUNE_PAS_Y;
            this.Controls.Add(dtpDataOra);

            //adaugare control de tip Label pentru Optiuni;
            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Left = 0*DIMENSIUNE_PAS_X+10;
            lblOptiuni.Top = 5 * DIMENSIUNE_PAS_Y;
            lblOptiuni.ForeColor = Color.DarkBlue;

            this.Controls.Add(lblOptiuni);
           


            //adaugare controale de tip CheckBox pentru Optiuni;
            checkOptiuni = new CheckBox();
            checkOptiuni.Appearance = Appearance.Normal;
            checkOptiuni.Text = Convert.ToString(Obiect.Enumerari.OptiuniActivitate.Notificari);
            checkOptiuni.Width = LATIME_CONTROL_CHECKBOX; ;
            checkOptiuni.Left =   DIMENSIUNE_PAS_X+10;
            checkOptiuni.Top = 5 * DIMENSIUNE_PAS_Y;
            checkOptiuni.ForeColor = Color.DarkBlue;
            this.Controls.Add((checkOptiuni));

            checkOptiuni2 = new CheckBox();
            checkOptiuni2.Appearance = Appearance.Normal;
            checkOptiuni2.Text = Convert.ToString(Obiect.Enumerari.OptiuniActivitate.Repetare);
            checkOptiuni2.Width =LATIME_CONTROL_CHECKBOX ;
            checkOptiuni2.Left = 2* (DIMENSIUNE_PAS_X)+10;
            checkOptiuni2.Top = 5 * DIMENSIUNE_PAS_Y;
            checkOptiuni2.ForeColor = Color.DarkBlue;
            this.Controls.Add((checkOptiuni2));

            checkOptiuni3 = new CheckBox();
            checkOptiuni3.Appearance = Appearance.Normal;
            checkOptiuni3.Text = Convert.ToString(Obiect.Enumerari.OptiuniActivitate.Alarme);
            checkOptiuni3.Width = LATIME_CONTROL_CHECKBOX;
            checkOptiuni3.Left = 3 * (DIMENSIUNE_PAS_X)+10;
            checkOptiuni3.Top = 5 * DIMENSIUNE_PAS_Y;
            checkOptiuni3.ForeColor = Color.DarkBlue;
            this.Controls.Add((checkOptiuni3));

            //pentru optiunea de cautare TEMA-LAB8
            lblCauta = new Label();
            lblCauta.Left = 0 * DIMENSIUNE_PAS_X + 10;
            lblCauta.Top = 6 * DIMENSIUNE_PAS_Y+15;
            lblCauta.ForeColor = Color.DarkBlue ;
            lblCauta.Text = "Cauta dupa:";
            lblCauta.Width = LATIME_CONTROL - 10;
            this.Controls.Add(lblCauta);

            //adaugare control de tip ComboBox pentru functia de CAUTARE dupa TIP/NUME-TEMA LAB8;
            cmbCautaDupa = new ComboBox();
            cmbCautaDupa.Items.Add("-");
            cmbCautaDupa.Items.Add("Nume");
            cmbCautaDupa.Items.Add("Tip");
            cmbCautaDupa.SelectedIndex = 0;
            cmbCautaDupa.FormattingEnabled = true;
            cmbCautaDupa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCautaDupa.Width = LATIME_CONTROL; ;
            cmbCautaDupa.Left = 1 * DIMENSIUNE_PAS_X;
            cmbCautaDupa.Top = 6 * DIMENSIUNE_PAS_Y+10;
            cmbCautaDupa.ForeColor = Color.DarkBlue;
            this.Controls.Add((cmbCautaDupa));
            //adaugare buton -//-
            btnCauta=new Button();
            btnCauta.Text = "Cauta";
            btnCauta.BackColor = Color.Bisque;
            btnCauta.Width = LATIME_CONTROL;
            btnCauta.Left = 3 * DIMENSIUNE_PAS_X ;
            btnCauta.Top = 6 * DIMENSIUNE_PAS_Y + 10;
            btnCauta.ForeColor = Color.Black;
            btnCauta.Click += OnButtonClicked_Cauta;
            this.Controls.Add((btnCauta));

            txtCautaDupa = new TextBox();
            txtCautaDupa.Width = LATIME_CONTROL;
            txtCautaDupa.Left = 2 * DIMENSIUNE_PAS_X;
            txtCautaDupa.Top = 6 * DIMENSIUNE_PAS_Y+10;
            txtCautaDupa.GotFocus += txt_OnFocus;
            txtCautaDupa.LostFocus += txt_LostFocus;
            this.Controls.Add(txtCautaDupa);




            #endregion
            #region Butoane
            //adaugare control de tip Button pentru a adauga o activitate;
            btnAdauga = new Button();
            btnAdauga.BackColor = Color.Bisque;
            btnAdauga.Width = LATIME_CONTROL_BUTON;
            btnAdauga.Text = "Adauga Activitatea";
            btnAdauga.Left = 4*DIMENSIUNE_PAS_X;
            btnAdauga.Top = 3 * DIMENSIUNE_PAS_Y;
            btnAdauga.Click += OnButtonClicked_Adauga;
            btnAdauga.ForeColor = Color.Black;
            this.Controls.Add(btnAdauga);

            //adaugare control de tip Button pentru a afisa activitatile;

            btnAfiseaza = new Button();
            btnAfiseaza.BackColor = Color.Bisque;
            btnAfiseaza.Width = LATIME_CONTROL_BUTON;
            btnAfiseaza.Text = "Afiseaza Activitati";
            btnAfiseaza.Left = 4 * DIMENSIUNE_PAS_X;
            btnAfiseaza.Top = 4 * DIMENSIUNE_PAS_Y;
            btnAfiseaza.Click += OnButtonClicked_Afiseaza;
            btnAfiseaza.ForeColor = Color.Black;
       
            this.Controls.Add(btnAfiseaza);

            //adaugare control de tip Button ce va redimensiona fereastra;
            btnRedimensioneaza = new Button();
            btnRedimensioneaza.BackColor = Color.Bisque;
            btnRedimensioneaza.Width = 20;
            btnRedimensioneaza.Text = "<";
            btnRedimensioneaza.Left = 1340;
            btnRedimensioneaza.Top = 8 * DIMENSIUNE_PAS_Y;
            btnRedimensioneaza.Click += OnButtonClicked_Redimensioneaza;
            btnRedimensioneaza.ForeColor = Color.Black;
            this.Controls.Add(btnRedimensioneaza);
            #endregion
        }

        #region FUNCTII CITIRE/AFISARE
        private Activitate CitireActivitate()
        {
            bool SUCCES = true;
            if (txtNume.Text == string.Empty)
            {
                lblNume.Text = lblNume.Text + "*";
                lblNume.ForeColor = Color.DarkRed;
                SUCCES = false;
            }
            if(txtDescriere.Text == string.Empty)
            {
                lblDescriere.Text=lblDescriere.Text + "*";
                lblDescriere.ForeColor = Color.DarkRed;
                SUCCES = false;
            }

            if (SUCCES == true)
            {
                lblDescriere.Text = "Descriere";
                lblNume.Text = "Nume";
                lblNume.ForeColor = Color.DarkBlue;
                lblDescriere.ForeColor=Color.DarkBlue;
                string nume = txtNume.Text.Trim();
                string descriere = txtDescriere.Text.Trim();
                string tip = cmbTip.Text;
                DateTime dataora = dtpDataOra.Value;

                List<string> optiuniList = new List<string>();
                optiuniList.Add(Convert.ToString(Obiect.Enumerari.OptiuniActivitate.Fara));
                if(checkOptiuni.Checked|checkOptiuni2.Checked|checkOptiuni3.Checked)
                {
                    optiuniList.Clear();
                }
                if (checkOptiuni.Checked)
                    optiuniList.Add(checkOptiuni.Text);

                if (checkOptiuni2.Checked)
                    optiuniList.Add(checkOptiuni2.Text);

                if (checkOptiuni3.Checked)
                    optiuniList.Add(checkOptiuni3.Text);

                string[] optiuni = optiuniList.ToArray();


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
            lblNume2 = new Label();
            lblNume2.Width = LATIME_CONTROL;
            lblNume2.Text = "Nume";
            lblNume2.TextAlign = ContentAlignment.MiddleCenter;
            lblNume2.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblNume2.Left =4* DIMENSIUNE_PAS_X_MARE;
            lblNume2.Top= DIMENSIUNE_PAS_Y;
            lblNume2.ForeColor = Color.DarkBlue;
            lblNume2.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblNume2);


            //adaugare control de tip Label pentru Tip;
            lblTip2 = new Label();
            lblTip2.Width = LATIME_CONTROL;
            lblTip2.Text = "Tip";
            lblTip2.TextAlign = ContentAlignment.MiddleCenter;
            lblTip2.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblTip2.Left = 5 * DIMENSIUNE_PAS_X_MARE;
            lblTip2.Top = 1 * DIMENSIUNE_PAS_Y;
            lblTip2.ForeColor = Color.DarkBlue;
            lblTip2.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblTip2);

            //adaugare control de tip Label pentru DataOra;
            lblDataOra2 = new Label();
            lblDataOra2.Width = LATIME_CONTROL;
            lblDataOra2.Text = "Data si ora";
            lblDataOra2.TextAlign = ContentAlignment.MiddleCenter;
            lblDataOra2.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblDataOra2.Left = 6 * DIMENSIUNE_PAS_X_MARE;
            lblDataOra2.Top = 1 * DIMENSIUNE_PAS_Y;
            lblDataOra2.ForeColor = Color.DarkBlue;
            lblDataOra2.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblDataOra2);

            //adaugare control de tip Label pentru Descriere;
            lblDescriere2 = new Label();
            lblDescriere2.Width = LATIME_CONTROL;
            lblDescriere2.Text = "Descriere";
            lblDescriere2.TextAlign = ContentAlignment.MiddleCenter;
            lblDescriere2.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblDescriere2.Left = 7 * DIMENSIUNE_PAS_X_MARE;
            lblDescriere2.Top = 1 * DIMENSIUNE_PAS_Y;
            lblDescriere2.ForeColor = Color.DarkBlue;
            lblDescriere2.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblDescriere2);

            //adaugare control de tip Label pentru Optiuni;
            lblOptiuni2 = new Label();
            lblOptiuni2.Width = LATIME_CONTROL;
            lblOptiuni2.Text = "Optiuni";
            lblOptiuni2.TextAlign = ContentAlignment.MiddleCenter;
            lblOptiuni2.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblOptiuni2.Left = 8 * DIMENSIUNE_PAS_X_MARE;
            lblOptiuni2.Top = 1 * DIMENSIUNE_PAS_Y;
            lblOptiuni2.ForeColor = Color.DarkBlue;
            lblOptiuni2.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lblOptiuni2);

            






            int i = 0;
            foreach (Activitate activitate in activitati)
            {


                //adaugare control de tip Label pentru numele activitatilor;
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = activitate.Nume;
                lblsNume[i].Left = 4*DIMENSIUNE_PAS_X_MARE;
                lblsNume[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblsNume[i].ForeColor = Color.Black;
                this.Controls.Add(lblsNume[i]);

                //adaugare control de tip Label pentru Tipul activitatilor;
                lblsTip[i] = new Label();
                lblsTip[i].Width = LATIME_CONTROL;
                lblsTip[i].Text = activitate.Tip;
                lblsTip[i].Left = 5 * DIMENSIUNE_PAS_X_MARE;
                lblsTip[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblsTip[i].ForeColor = Color.Black;
                this.Controls.Add(lblsTip[i]);

                //adaugare control de tip Label pentru Data si ora activitatilor;
                lblsDataOra[i] = new Label();
                lblsDataOra[i].Width = LATIME_CONTROL;
                lblsDataOra[i].Text = Convert.ToString(activitate.DataOra);
                lblsDataOra[i].Left = 6 * DIMENSIUNE_PAS_X_MARE;
                lblsDataOra[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblsDataOra[i].ForeColor = Color.Black;
                lblsDataOra[i].MouseHover += label_MouseHover;
                this.Controls.Add(lblsDataOra[i]);


                //adaugare control de tip Label pentru descrierea activitatilor;
                lblsDescriere[i] = new Label();
                lblsDescriere[i].Width = LATIME_CONTROL;
                lblsDescriere[i].Text = activitate.Descriere;
                lblsDescriere[i].Left = 7 * DIMENSIUNE_PAS_X_MARE;
                lblsDescriere[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblsDescriere[i].ForeColor = Color.Black;
                lblsDescriere[i].MouseHover += label_MouseHover;
                
                this.Controls.Add(lblsDescriere[i]);
           

                //adaugare control de tip Label pentru Optiunea activitatilor;
                string optiunistr = string.Join(",", activitate.Optiuni);
                lblsOptiuni[i] = new Label();
                lblsOptiuni[i].Width = LATIME_CONTROL;
                lblsOptiuni[i].Text = Convert.ToString(optiunistr);
                lblsOptiuni[i].Left = 8 * DIMENSIUNE_PAS_X_MARE;
                lblsOptiuni[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblsOptiuni[i].ForeColor = Color.Black;
                
                lblsOptiuni[i].MouseHover += label_MouseHover;

                this.Controls.Add(lblsOptiuni[i]);

                
                i++;
            }
            
        }

        private void StergeAfisareActivitatiCautate()
        {
            for(int i = this.Controls.Count - 1; i >= 0; i--)
    {
                Control control = this.Controls[i];
                if (control.Top > 210 && control.Left < 650)
                {
                    this.Controls.Remove(control);
                }
            }

        }
        private void AfiseazaActivitatiCautate(Activitate[] activitati) //TEMA LAB6
        {
            
            if (activitati != null && activitati.Length > 0)
            {
                Label[] lblsNume = new Label[activitati.Length];
                Label[] lblsDescriere = new Label[activitati.Length];
                Label[] lblsTip = new Label[activitati.Length];
                Label[] lblsDataOra = new Label[activitati.Length];
                Label[] lblsOptiuni = new Label[activitati.Length];



                //adaugare control de tip Label pentru Nume;
                lblNume2 = new Label();
                lblNume2.Width = LATIME_CONTROL;
                lblNume2.Text = "Nume";
                lblNume2.TextAlign = ContentAlignment.MiddleCenter;
                lblNume2.Font = new Font("Tahoma", 11, FontStyle.Bold);
                lblNume2.Left = 0 * DIMENSIUNE_PAS_X+15;
                lblNume2.Top = 7*DIMENSIUNE_PAS_Y+10;
                lblNume2.ForeColor = Color.DarkBlue;
                lblNume2.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(lblNume2);


                //adaugare control de tip Label pentru Tip;
                lblTip2 = new Label();
                lblTip2.Width = LATIME_CONTROL;
                lblTip2.Text = "Tip";
                lblTip2.TextAlign = ContentAlignment.MiddleCenter;
                lblTip2.Font = new Font("Tahoma", 11, FontStyle.Bold);
                lblTip2.Left = 1 * DIMENSIUNE_PAS_X+15;
                lblTip2.Top = 7 * DIMENSIUNE_PAS_Y+10;
                lblTip2.ForeColor = Color.DarkBlue;
                lblTip2.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(lblTip2);

                //adaugare control de tip Label pentru DataOra;
                lblDataOra2 = new Label();
                lblDataOra2.Width = LATIME_CONTROL;
                lblDataOra2.Text = "Data si ora";
                lblDataOra2.TextAlign = ContentAlignment.MiddleCenter;
                lblDataOra2.Font = new Font("Tahoma", 11, FontStyle.Bold);
                lblDataOra2.Left = 2 * DIMENSIUNE_PAS_X+15;
                lblDataOra2.Top = 7 * DIMENSIUNE_PAS_Y+10;
                lblDataOra2.ForeColor = Color.DarkBlue;
                lblDataOra2.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(lblDataOra2);

                //adaugare control de tip Label pentru Descriere;
                lblDescriere2 = new Label();
                lblDescriere2.Width = LATIME_CONTROL;
                lblDescriere2.Text = "Descriere";
                lblDescriere2.TextAlign = ContentAlignment.MiddleCenter;
                lblDescriere2.Font = new Font("Tahoma", 11, FontStyle.Bold);
                lblDescriere2.Left = 3 * DIMENSIUNE_PAS_X+15;
                lblDescriere2.Top = 7 * DIMENSIUNE_PAS_Y+10;
                lblDescriere2.ForeColor = Color.DarkBlue;
                lblDescriere2.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(lblDescriere2);

                //adaugare control de tip Label pentru Optiuni;
                lblOptiuni2 = new Label();
                lblOptiuni2.Width = LATIME_CONTROL;
                lblOptiuni2.Text = "Optiuni";
                lblOptiuni2.TextAlign = ContentAlignment.MiddleCenter;
                lblOptiuni2.Font = new Font("Tahoma", 11, FontStyle.Bold);
                lblOptiuni2.Left = 4 * DIMENSIUNE_PAS_X+15;
                lblOptiuni2.Top = 7 * DIMENSIUNE_PAS_Y+10;
                lblOptiuni2.ForeColor = Color.DarkBlue;
                lblOptiuni2.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(lblOptiuni2);








                int i = 0;
                foreach (Activitate activitate in activitati)
                {


                    //adaugare control de tip Label pentru numele activitatilor;
                    lblsNume[i] = new Label();
                    lblsNume[i].Width = LATIME_CONTROL;
                    lblsNume[i].Text = activitate.Nume;
                    lblsNume[i].Left = 0 * DIMENSIUNE_PAS_X+15;
                    lblsNume[i].Top = (i + 8) * DIMENSIUNE_PAS_Y+10;
                    lblsNume[i].ForeColor = Color.Black;
                    this.Controls.Add(lblsNume[i]);

                    //adaugare control de tip Label pentru Tipul activitatilor;
                    lblsTip[i] = new Label();
                    lblsTip[i].Width = LATIME_CONTROL;
                    lblsTip[i].Text = activitate.Tip;
                    lblsTip[i].Left = 1 * DIMENSIUNE_PAS_X+ 15;
                    lblsTip[i].Top = (i + 8) * DIMENSIUNE_PAS_Y+10;
                    lblsTip[i].ForeColor = Color.Black;
                    this.Controls.Add(lblsTip[i]);

                    //adaugare control de tip Label pentru Data si ora activitatilor;
                    lblsDataOra[i] = new Label();
                    lblsDataOra[i].Width = LATIME_CONTROL;
                    lblsDataOra[i].Text = Convert.ToString(activitate.DataOra);
                    lblsDataOra[i].Left = 2 * DIMENSIUNE_PAS_X+ 15;
                    lblsDataOra[i].Top = (i + 8) * DIMENSIUNE_PAS_Y+10;
                    lblsDataOra[i].ForeColor = Color.Black;
                    lblsDataOra[i].MouseHover += label_MouseHover;
                    this.Controls.Add(lblsDataOra[i]);


                    //adaugare control de tip Label pentru descrierea activitatilor;
                    lblsDescriere[i] = new Label();
                    lblsDescriere[i].Width = LATIME_CONTROL;
                    lblsDescriere[i].Text = activitate.Descriere;
                    lblsDescriere[i].Left = 3 * DIMENSIUNE_PAS_X+ 15;
                    lblsDescriere[i].Top = (i + 8) * DIMENSIUNE_PAS_Y+10;
                    lblsDescriere[i].ForeColor = Color.Black;
                    lblsDescriere[i].MouseHover += label_MouseHover;

                    this.Controls.Add(lblsDescriere[i]);


                    //adaugare control de tip Label pentru Optiunea activitatilor;
                    string optiunistr = string.Join(",", activitate.Optiuni);
                    lblsOptiuni[i] = new Label();
                    lblsOptiuni[i].Width = LATIME_CONTROL;
                    lblsOptiuni[i].Text = Convert.ToString(optiunistr);
                    lblsOptiuni[i].Left = 4 * DIMENSIUNE_PAS_X+ 15;
                    lblsOptiuni[i].Top = (i + 8) * DIMENSIUNE_PAS_Y+10;
                    lblsOptiuni[i].ForeColor = Color.Black;

                    lblsOptiuni[i].MouseHover += label_MouseHover;

                    this.Controls.Add(lblsOptiuni[i]);


                    i++;
                }
            }
        }
        #endregion

        #region Functii pentru evenimente
        private void txt_OnFocus(object sender, EventArgs e)
        {

            TextBox textBox = sender as TextBox;
                textBox.BackColor = Color.LightGray;
            
        }

        private void txt_LostFocus(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BackColor = Color.White;
        }

        private void label_MouseHover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(label, label.Text);
            }
        }
        private void TxtNume_GotFocus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnButtonClicked_Afiseaza(object sender, EventArgs e)
        {
            this.Size = new Size(1375, 800);
            AfiseazaActivitati();
        }
        private void OnButtonClicked_Redimensioneaza(object sender, EventArgs e)
        {
            this.Size = new Size(615, 800);
        }

        private void OnButtonClicked_Adauga(object sender, EventArgs e)
        {
            Activitate activitate = CitireActivitate();
            if (activitate != null)
            {
                adminActivitati.AdaugaActivitate(activitate);
            }

            txtNume.Text = string.Empty;
            txtDescriere.Text = string.Empty;
            cmbTip.SelectedIndex = 0;
            checkOptiuni.Checked = false;
            checkOptiuni2.Checked = false;
            checkOptiuni3.Checked = false;

        }

        private void OnButtonClicked_Cauta(object sender, EventArgs e)
        {
            if(cmbCautaDupa.SelectedIndex == 0|txtCautaDupa.Text==string.Empty)
            {
                lblCauta.ForeColor = Color.Red;
                lblCauta.Text = "Cauta dupa*";
                
            }
            StergeAfisareActivitatiCautate();
            if (txtCautaDupa.Text != string.Empty)
            {
                if (cmbCautaDupa.SelectedItem.ToString() == "Nume")
                {

                    Activitate[] activitati = adminActivitati.CautaDupaNume(txtCautaDupa.Text.Trim());
                    if (this.Width < 620)
                    {
                        this.Size = new Size(615, 800);
                    }
                    AfiseazaActivitatiCautate(activitati);
                }
                if (cmbCautaDupa.SelectedItem.ToString() == "Tip")
                {
                    Activitate[] activitati = adminActivitati.CautaDupaTip(txtCautaDupa.Text.Trim());
                    if (this.Width < 620)
                    {
                        this.Size = new Size(615, 800);
                    }
                    AfiseazaActivitatiCautate(activitati);

                }
            }
            if (cmbCautaDupa.SelectedIndex != 0 && txtCautaDupa.Text != string.Empty)
            {
                lblCauta.ForeColor = Color.DarkBlue;
                lblCauta.Text = "Cauta dupa";
            }
            
            cmbCautaDupa.SelectedIndex = 0;
            txtCautaDupa.Text = null;


        }

        #endregion





    }
}
