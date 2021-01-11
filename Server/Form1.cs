using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Server s;
        
        private void Form1_Load(object sender, EventArgs e)
        {
             s = new Server();
            Thread t = new Thread(s.Pokreni);
            t.Start();
            t.IsBackground = true;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            dgvKorisnici.DataSource = null;
            dgvKorisnici.DataSource = new BindingList<Korisnik>(Server.OnlineKorisnici);
        }
    }
}
