using Obiect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Agenda_UI_WindowsForms
{
    public partial class IntroducereNumeForm : Form
    {
        public Utilizator Utilizator { get; private set; }
        public IntroducereNumeForm()
        {
            InitializeComponent();
            this.Size = new Size(615, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Tahoma", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Agenda de activitati";
            this.BackColor = Color.Beige;
            txtNume.KeyPress += ApasaEnter;
            txtPrenume.KeyPress += ApasaEnter;
            this.KeyPress+= ApasaEnter;
        }

        private void ApasaEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Verificăm dacă ambele câmpuri de text sunt completate
                if (!string.IsNullOrEmpty(txtNume.Text) && !string.IsNullOrEmpty(txtPrenume.Text))
                { 
                    Utilizator = new Utilizator(txtNume.Text, txtPrenume.Text);

                    

                    Close();
                }
                
                if(txtNume.Text==string.Empty)
                {
                    label1.Text = "*" + label1.Text;
                    label1.ForeColor = Color.Red;
                }
                if(txtPrenume.Text==string.Empty)
                {
                    label2.Text = "*" + label2.Text;
                    label2.ForeColor = Color.Red;
                }

                   
                    
                

            }
        }

    }
}
