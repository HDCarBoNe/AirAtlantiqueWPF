using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;
//using System.Windows.Forms;
using MenuItem = System.Windows.Forms.MenuItem;
using MainMenu = System.Windows.Forms.MainMenu;

namespace AirAtlantiqueWPF.Controller
{
    public class Avion : INotifyPropertyChanged
    {
        private int idAvion;
        private string ModeleAvion;
        private string Motorisation;
        private int Capacite;
        private int EtatAvion;
        private int NbrPremium;
        private int NbrBusiness;
        private int NbrEco;
        private int Type;

        public Avion() { }

        public Avion(int id, string model, string moto,  int capa, int prem, int busi, int eco, int etat, int type)
        {
            this.idAvion = id;
            this.ModeleAvion = model;
            this.Motorisation = moto;
            this.Capacite = capa;
            this.EtatAvion = etat;
            this.NbrPremium = prem;
            this.NbrBusiness = busi;
            this.NbrEco = eco;
            this.Type = type;
        }

        public int idAvionProperty
        {
            get { return idAvion; }
        }

        public string ModelAvionProperty
        {
            get { return ModeleAvion; }
            set
            {
                this.ModeleAvion = value;
            }
        }
        public string MotorisationProperty
        {
            get { return Motorisation; }
            set
            {
                this.Motorisation = value;
            }
        }
        public int CapaciteProperty
        {
            get { return Capacite; }
            set
            {
                this.Capacite = value;
            }
        }
        public int EtatAvionProperty
        {
            get { return EtatAvion; }
            set
            {
                this.EtatAvion = value;
            }
        }
        public int NbrPremiumProperty
        {
            get { return NbrPremium; }
            set
            {
                this.NbrPremium = value;
            }
        }
        public int NbrBusinessProperty
        {
            get { return NbrBusiness; }
            set
            {
                this.NbrBusiness = value;
            }
        }
        public int NbrEcoProperty
        {
            get { return NbrEco; }
            set
            {
                this.NbrEco = value;
            }
        }
        public int TypeProperty
        {
            get { return Type; }
            set
            {
                this.Type = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                AvionBdd.updateAvion(this);
            }
        }
    }

}
