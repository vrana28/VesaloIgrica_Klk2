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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) | string.IsNullOrEmpty(txtSifra.Text)) {
                MessageBox.Show("Morate uneti polja");
                return;
            }

            if (!txtEmail.Text.Contains('@')) {
                MessageBox.Show("Los email");
                return;
            }

            if (!char.IsLetter(txtSifra.Text[0])) {
                MessageBox.Show("Ne pocinje vam sifra velikim slovom");
                return;
            }
            if (!txtSifra.Text.Any(c => char.IsDigit(c))) {
                MessageBox.Show("Nemate broj u sifri");
                return;
            }

            Odgovor o = Komunikacija.Instance.Prijavi(txtEmail.Text, txtSifra.Text, (Kategorije)cmbKatagorije.SelectedItem);
            switch (o.Signal) {
                case Signal.Uspesno:
                    FrmMain frmMain = new FrmMain(o);
                    this.Visible = false;
                    frmMain.ShowDialog();
                    Visible = true;
                    break;
                case Signal.KorisnikVecPostoji:
                    MessageBox.Show("Korisnik vec postoji");
                    break;
                case Signal.Neuspesno:
                    MessageBox.Show("Ne postoji korisnik");
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Komunikacija.Instance.Povezise())
            {
                Odgovor o = Komunikacija.Instance.VratiSveKategorije();
                cmbKatagorije.DataSource = o.Kategorije;
            }
            else {
                MessageBox.Show("Greska prilikom povezivanja");
            }
        }

    }
}
