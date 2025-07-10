using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_hotel.Classes
{
    internal class ClsChambre
    {
        int id ;
	    int numero;
        string contact;
	    int refClasse;

        public int Id { get => id; set => id = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Contact { get => contact; set => contact = value; }
        public int RefClasse { get => refClasse; set => refClasse = value; }
    }
}
