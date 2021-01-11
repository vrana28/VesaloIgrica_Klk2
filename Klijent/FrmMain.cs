using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class FrmMain : Form
    {
        public FrmMain(Odgovor o)
        {
            InitializeComponent();
            odg = o;
            lblPojam.Text = new string(o.Pojam);
            lblPokusaji.Text = o.BrojPokusaja.ToString();
        }

        private Odgovor odg;

        private List<char> koriscenaSlova { get; set; } = new List<char>();
        private char Slovo;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSlovo.Text)) {
                MessageBox.Show("Morate uneti slovo");
                return;
            }
            if (!char.IsLetter(txtSlovo.Text[0])) {
                MessageBox.Show("Morate uneti slovo");
                return;
            }

            if (koriscenaSlova.Any(ks => ks == txtSlovo.Text[0]))
            {
                MessageBox.Show("Vec ste koristili ovo slovo");
                return;
            }
            

            if (odg.BrojPokusaja == 0) {
                MessageBox.Show("Nemate dovoljno pokusaja. Izgubili ste.");
                return;
            }

            Slovo =txtSlovo.Text[0];
            koriscenaSlova.Add(Slovo);
            Odgovor o = Komunikacija.Instance.PosaljiSlovo(Slovo,odg.BrojPokusaja);
            if (o.Signal == Signal.Pobednik) {
                MessageBox.Show("Pobedili ste");
                lblPojam.Text = new string(o.Pojam);
                lblPokusaji.Text = o.BrojPokusaja.ToString();
                button1.Enabled = false;
            }
            if (o.Signal == Signal.NePostojiSlovo)
            {
                lblPokusaji.Text = o.BrojPokusaja.ToString();
            }
            else {
                lblPojam.Text = new string(o.Pojam);
                lblPokusaji.Text = o.BrojPokusaja.ToString();
            }
            odg.BrojPokusaja = o.BrojPokusaja;
            lblPogadnjanaSlova.Text +=" "+Slovo;
            
        }
    }
}
