using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Zahtev
    {
        public  Operacija Operacija { get; set; }
        public Korisnik Korisnik { get; set; }
        public Kategorije Kategorije{ get; set; }
        public char Slovo { get; set; }
        public int BrojPokusaja { get; set; }
    }
    [Serializable]
    public enum Operacija { 
        Login,
        VratiKategorije,
        ObradiSlovo
    }
}
