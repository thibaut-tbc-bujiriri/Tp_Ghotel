﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_hotel.Classes
{
    internal class ClsReservation
    {
        int id ;
	    int refClient ;
        int refChabre  ;
	    DateTime dateEntree ;
        DateTime DateSortie;

        public int Id { get => id; set => id = value; }
        public int RefClient { get => refClient; set => refClient = value; }
        public int RefChabre { get => refChabre; set => refChabre = value; }
        public DateTime DateEntree { get => dateEntree; set => dateEntree = value; }
        public DateTime DateSortie1 { get => DateSortie; set => DateSortie = value; }
    }
}
