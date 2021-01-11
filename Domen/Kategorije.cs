using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Kategorije
    {
        public int KateogrijeId { get; set; }
        public string Naziv { get; set; }
        public List<string> Pojmovi{ get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }

    
}
