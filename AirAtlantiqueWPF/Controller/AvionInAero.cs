using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantiqueWPF.Controller
{
    class AvionInAero
    {
        private int idAvion;
        private string modeleAvion;
        private int capacite;
        private int Type;
        private int Etat;
        private int idVols;
        private DateTime arrivereel;

        public AvionInAero() { }

        public AvionInAero(int idAvion, string modeleAvion, int capacite, int Type, int Etat, int idVols, DateTime arrivereel)
        {
            this.idAvion = idAvion;
            this.modeleAvion = modeleAvion;
            this.capacite = capacite;
            this.Type = Type;
            this.Etat = Etat;
            this.idVols = idVols;
            this.arrivereel = arrivereel;
        }

        public int IdAvionProperty
        {
            get { return idAvion; }
        }

        public string modeleAvionProperty
        {
            get { return modeleAvion; }
        }

        public int capaciteProperty
        {
            get { return capacite; }
        }

        public int typeProperty
        {
            get { return Type; }
        }

        public int etatProperty
        {
            get { return Etat; }
        }

        public int idVolsProperty
        {
            get { return idVols; }
        }

        public DateTime arrivereelProperty
        {
            get { return arrivereel; }
        }
    }
}
