using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantiqueWPF.Controller
{
    class Client : INotifyPropertyChanged
    {
        private int idClient;
        private string nom;
        private string prenom;
        private string tel;
        private string adresse;
        private string ville;
        private string CP;
        private string Pays;
        private int ptsFidelité;
        private int idLastVol;
        private DateTime dateLastVol;

        public Client() { }

        public Client(int id, string nom, string prenom,string tel, string adresse, string ville, string cp,
            string pays, int fid, int idLastVol, DateTime dateLastVol)
        {
            this.idClient = id;
            this.nom = nom;
            this.prenom = prenom;
            this.tel = tel;
            this.adresse = adresse;
            this.ville = ville;
            this.CP = cp;
            this.Pays = pays;
            this.ptsFidelité = fid;
            this.idLastVol = idLastVol;
            this.dateLastVol = dateLastVol;
        }

        public int idClientProperty
        {
            get { return idClient; }
        }

        public string NomProperty
        {
            get { return nom; }
            set { this.nom = value;  OnPropertyChanged("NomProperty");}
        }

        public string PrenomProperty
        {
            get { return prenom; }
            set { this.prenom = value; OnPropertyChanged("PrenomProperty"); }
        }

        public string TelProperty
        {
            get { return tel; }
            set { this.tel = value; OnPropertyChanged("TelProperty"); }
        }

        public string AdresseProperty
        {
            get { return adresse; }
            set { this.adresse = value; OnPropertyChanged("AdresseProperty"); }
        }

        public string VilleProperty
        {
            get { return ville; }
            set { this.ville = value; OnPropertyChanged("VilleProperty"); }
        }

        public string CpProperty
        {
            get { return CP; }
            set { this.CP = value; OnPropertyChanged("CpProperty"); }
        }

        public string PaysProperty
        {
            get { return Pays; }
            set { this.Pays = value; OnPropertyChanged("PaysProperty"); }
        }

        public int PtsFideliteProperty
        {
            get { return ptsFidelité; }
            set { this.ptsFidelité = value; OnPropertyChanged("PtsFideliteProperty"); }
        }

        public int idLastVolProperty
        {
            get { return idLastVol; }
        }

        public DateTime DateLastVolProperty
        {
            get { return dateLastVol; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                ClientBdd.updateClient(this);
            }
        }
    }
}
