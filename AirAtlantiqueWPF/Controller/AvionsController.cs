﻿using System.ComponentModel;



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

        public int idProperty
        {
            set { idProperty = value; }
            get { return idAvion; }
        }

        public string ModelAvionProperty
        {
            get { return ModeleAvion; }
            set
            {
                this.ModeleAvion = value;
                OnPropertyChanged("ModelAvionProperty");

            }
        }
        public string MotorisationProperty
        {
            get { return Motorisation; }
            set
            {
                this.Motorisation = value;
                OnPropertyChanged("MotorisationProperty");

            }
        }
        public int CapaciteProperty
        {
            get { return Capacite; }
            set
            {
                this.Capacite = value;
                OnPropertyChanged("CapaciteProperty");

            }
        }
        public int EtatAvionProperty
        {
            get { return EtatAvion; }
            set
            {
                this.EtatAvion = value;
                OnPropertyChanged("EtatAvionProperty");

            }
        }
        public int NbrPremiumProperty
        {
            get { return NbrPremium; }
            set
            {
                this.NbrPremium = value;
                OnPropertyChanged("NbrPremiumProperty");

            }
        }
        public int NbrBusinessProperty
        {
            get { return NbrBusiness; }
            set
            {
                this.NbrBusiness = value;
                OnPropertyChanged("NbrBusinessProperty");

            }
        }
        public int NbrEcoProperty
        {
            get { return NbrEco; }
            set
            {
                this.NbrEco = value;
                OnPropertyChanged("NbrEcoProperty");

            }
        }
        public int TypeProperty
        {
            get { return Type; }
            set
            {
                this.Type = value;
                OnPropertyChanged("TypeProperty");
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
