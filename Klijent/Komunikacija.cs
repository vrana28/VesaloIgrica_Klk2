using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instance;
        Socket client;
        NetworkStream stream;
        BinaryFormatter formatter;
        public Komunikacija()
        {

        }

        public  int BrojPokusaja { get; set; }
        public char[] Pojam { get; set; }

    

        public static Komunikacija Instance {
            get {
                if (instance == null) instance = new Komunikacija();
                return instance;
            }
        }

        internal bool Povezise()
        {

            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect("127.0.0.1", 9977);
                stream = new NetworkStream(client);
                formatter = new BinaryFormatter();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        internal Odgovor PosaljiSlovo(char slovo, int brojPokusaja)
        {
            Zahtev z = new Zahtev { Operacija = Operacija.ObradiSlovo, Slovo = slovo, BrojPokusaja = brojPokusaja };
            formatter.Serialize(stream, z);
            return (Odgovor)formatter.Deserialize(stream);
        }

        internal Odgovor Prijavi(string email, string sifra, Kategorije kategorija)
        {
            Zahtev z = new Zahtev { Operacija = Operacija.Login, Korisnik = new Korisnik { Email = email, Sifra = sifra }, Kategorije = kategorija };
            formatter.Serialize(stream, z);
            Odgovor o = (Odgovor)formatter.Deserialize(stream);
            Pojam = o.Pojam;
            BrojPokusaja = o.BrojPokusaja;
            return o;
        }

        internal Odgovor VratiSveKategorije()
        {
                Zahtev z = new Zahtev { Operacija = Operacija.VratiKategorije };
                formatter.Serialize(stream, z);
                return (Odgovor)formatter.Deserialize(stream);
        }
    }
}
