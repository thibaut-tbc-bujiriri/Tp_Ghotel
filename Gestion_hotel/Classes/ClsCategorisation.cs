using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_hotel.Classes
{
    internal class ClsCategorisation
    {
        int id ;
	    string desgnation;

        public int Id { get => id; set => id = value; }
        public string Desgnation { get => desgnation; set => desgnation = value; }
    }
}
