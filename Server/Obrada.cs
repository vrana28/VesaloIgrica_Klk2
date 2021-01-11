using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public class Obrada
    {
        private Socket client;
        private NetworkStream stream;
        private BinaryFormatter formatter;
        private Server s;
        public Obrada(Socket client, Server s)
        {
            this.client = client;
            this.s = s;
            stream = new NetworkStream(client);
            formatter = new BinaryFormatter();
            
        }

        public Korisnik Korisnik { get; set; }

        private static List<Korisnik> korisnici { get; set; } = new List<Korisnik>();
        private String Pojam;
        private char[] pojamZaKorisnika;
        public static int brojPokusaja;
        internal void Obradi()
        {
            try
            {
                bool kraj = false;
                while (!kraj)
                {
                    Zahtev z = (Zahtev)formatter.Deserialize(stream);
                    Odgovor o = new Odgovor();
                    switch (z.Operacija)
                    {

                        case Operacija.Login:
                            Korisnik user = z.Korisnik;
                            foreach (Korisnik kor in s.korisnici) {
                                if (kor.Email == user.Email && kor.Sifra == user.Sifra) {
                                    Korisnik = kor;
                                }
                            }
                            if (korisnici.Any(k => k.Email == Korisnik.Email))
                            {
                                o.Signal = Signal.KorisnikVecPostoji;
                            }
                            else if (Korisnik != null)
                            {
                                o.Signal = Signal.Uspesno;
                                korisnici.Add(Korisnik);
                                Server.OnlineKorisnici.Add(Korisnik);
                                o.Pojam = VratiPojam(z.Kategorije);
                                o.BrojPokusaja = o.Pojam.Length + 3;
                                brojPokusaja = o.BrojPokusaja;
                            }
                            else {
                                o.Signal = Signal.Neuspesno;
                            }
                            formatter.Serialize(stream, o);
                            break;
                        case Operacija.VratiKategorije:
                            o.Kategorije = s.kateogorije.Select(k => new Kategorije { KateogrijeId = k.KateogrijeId, Naziv = k.Naziv }).ToList();
                            formatter.Serialize(stream, o);
                            break;
                        case Operacija.ObradiSlovo:
                            if (proveriSlovo(z.Slovo))
                            {
                                o.Pojam = ObradiPojam(z.Slovo);
                                o.Signal = Signal.PostojiSlovo;
                                if (!o.Pojam.Any(p => p == '*')) {
                                    o.Signal = Signal.Pobednik;
                                }
                            }
                            else {
                                o.Signal = Signal.NePostojiSlovo;
                            }
                            brojPokusaja--;
                            o.BrojPokusaja = brojPokusaja;
                            formatter.Serialize(stream, o);
                            break;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                korisnici.Remove(Korisnik);
                Server.OnlineKorisnici.Remove(Korisnik);
            }
            finally {
                client.Close();
            }
        }

        private bool proveriSlovo(char slovo)
        {
            return (Pojam.ToUpper().Contains(char.ToUpper(slovo)));
        }

        private char[] ObradiPojam(char slovo)
        {
            for (int i = 0; i < Pojam.Length; i++) {
                if (char.ToUpper(Pojam[i]) == char.ToUpper(slovo)) {
                    pojamZaKorisnika[i] = Pojam[i];
                }
            }
            return pojamZaKorisnika;
        }

        private char[] VratiPojam(Kategorije kat)
        {
            Kategorije k = s.kateogorije.Single(s => s.KateogrijeId == kat.KateogrijeId);
            Random r = new Random();
            Pojam = k.Pojmovi[r.Next(k.Pojmovi.Count)];
            pojamZaKorisnika = new char[Pojam.Length];
            brojPokusaja = Pojam.Length + 8;
            for (int i = 0; i < Pojam.Length; i++) {
                if (Pojam[i] == ' ')
                {
                    pojamZaKorisnika[i] = ' ';
                }
                else {
                    pojamZaKorisnika[i] = '*';
                }
            }
            return pojamZaKorisnika;
        }
    }
}
