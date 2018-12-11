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
        private string nom;
        private string ville;
        private string pays;

        public Aeroport() { }

       public Aeroport(int idAeroport, string nom, string ville, string pays)
        {
            this.idAeroport = idAeroport;
            this.nom = nom;
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
            get { return idAeroport + " - " + nom; }
        }


        public string NomProperty
        {
            get { return nom; }
            set { nom = value; }
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

