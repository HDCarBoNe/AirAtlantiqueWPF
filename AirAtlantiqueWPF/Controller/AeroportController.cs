using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirAtlantiqueWPF.Controller
{
   public class Aeroport 
    {
        private int idAeroport;
        private string AITA;
        private string ville;
        private string pays;

        public Aeroport() { }

       public Aeroport(int idAeroport, string aita, string ville, string pays)
        {
            this.idAeroport = idAeroport;
            this.AITA = aita;
            this.ville = ville;
            this.pays = pays;
        }

        public int idAeroportProperty
        {
            get { return idAeroport; }
            set { idAeroport = value; }
        }

        public string AfficheProperty
        {
            get { return idAeroport + " - " + AITA; }
        }


        public string AITAProperty
        {
            get { return AITA; }
            set { AITA = value; }
        }


        public string VilleProperty
        {
            get { return ville; }
            set { ville = value; }
        }

        public string PaysProperty
        {
            get { return pays; }
            set { pays = value; }
        }


    }
}

