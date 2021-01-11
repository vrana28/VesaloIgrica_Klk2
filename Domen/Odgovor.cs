using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Odgovor
    {
        public Signal Signal{ get; set; }
        public bool Uspesno { get; set; }
        public string Poruka { get; set; }
        public List<Kategorije> Kategorije { get; set; }
        public char[] Pojam { get; set; }
        public int BrojPokusaja { get; set; }
    }
    [Serializable]
    public enum Signal { 
        Uspesno,
        Neuspesno,
        KorisnikVecPostoji,
        NePostojiSlovo,
        PostojiSlovo,
        Pobednik
    }
}
