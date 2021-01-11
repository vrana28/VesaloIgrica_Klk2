using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public class Server
    {
        private Socket listener;
        public List<Korisnik> korisnici;
        public List<Kategorije> kateogorije;
        public static List<Korisnik> OnlineKorisnici { get; set; } = new List<Korisnik>();

        public Server()
        {
            korisnici = new List<Korisnik> {
                new Korisnik{ Email="marko@gmail.com",Sifra="marko1" }
            };
            kateogorije = new List<Kategorije> {
                new Kategorije { KateogrijeId = 1, Naziv = "Gradovi Evrope", Pojmovi = new List<string>{"Beograd","Berlin" } },
                new Kategorije{ KateogrijeId = 2, Naziv = "Naziv predmeta na Fonu", Pojmovi = new List<string>{"MTR","Mata","SISJ" } },
                new Kategorije{ KateogrijeId = 3, Naziv = "Fudbalski timovi",Pojmovi = new List<string>{ "Zvezda","Partizan","Borac"} }
            };
            
        }
    

        public void Pokreni() {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9977));
            listener.Listen(5);
            try
            {
                while (true)
                {
                    Socket client = listener.Accept();
                    Obrada o = new Obrada(client, this);
                    Thread nit = new Thread(o.Obradi);
                    nit.Start();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
