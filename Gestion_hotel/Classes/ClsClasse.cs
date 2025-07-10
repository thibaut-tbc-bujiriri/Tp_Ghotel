using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_hotel.Classes
{
    internal class ClsClasse
    {
        int id ;
        string designation;
        int refCategorisation;
        double prix;

        public int Id { get => id; set => id = value; }
        public string Designation { get => designation; set => designation = value; }
        public int RefCategorisation { get => refCategorisation; set => refCategorisation = value; }
        public double Prix { get => prix; set => prix = value; }
    }
}
