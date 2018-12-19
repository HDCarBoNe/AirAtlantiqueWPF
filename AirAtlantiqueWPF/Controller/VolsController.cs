using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace AirAtlantiqueWPF.Controller
{

    public class Vols : INotifyPropertyChanged

    {
        private int idvols;
        private string departprevu;
        private string departreel;
        private string arriveprevu;
        private string arrivereel;
        private int idavion;
        private int id_dep;
        private int id_arrive;

        public Vols() { }

        public Vols(int idvols, string departprevu, string departreel, string arriveprevu, string arrivereel, int idavion, int id_dep, int id_arrive)
        {
            this.idvols = idvols;
            this.departprevu = departprevu;
            this.departreel = departreel;
            this.arriveprevu = arriveprevu;
            this.arrivereel = arrivereel;
            this.idavion = idavion;
            this.id_dep = id_dep;
            this.id_arrive = id_arrive;
        }

        public int idVolsProperty
        {
            get { return idvols; }
            
        }

        public string DepartprevuProperty
        {
            get {
                
               DateTime dateValue = DateTime.Parse(departprevu);
               departprevu = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
              
                return departprevu;
            }
            set
            {
                departprevu = value;
                OnPropertyChanged("depart_prevu");
            }
        }

        public string DepartreelProperty
        {
            get {
                if (departreel != "NULL")
                {
                    DateTime dateValue = DateTime.Parse(departreel);
                    departreel = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return departreel;
            }
            set
            {
                departreel = value;
                OnPropertyChanged("depart_reel");
            }
        }

        public string ArriveprevuProperty
        {
            get {
                DateTime dateValue = DateTime.Parse(arriveprevu);
                arriveprevu = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                return arriveprevu;
            }
            set
            {
                arriveprevu = value;
                OnPropertyChanged("arrive_prevu");
            }
        }

        public string ArrivereelProperty
        {
            get {

                if (arrivereel != "NULL")
                {
                    DateTime dateValue = DateTime.Parse(arrivereel);
                    arrivereel = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return arrivereel;
            }
            set
            {
                arrivereel = value;
                OnPropertyChanged("arrive_reel");
            }
        }

        public int IdAvionProperty
        {
            get { return idavion; }
            set
            {
                idavion = value;
                OnPropertyChanged("id_avion");
            }
        }

        public string NomDepProperty
        {
            get
            {
                Aeroport a = new AeroportBdd().ChooseAeroport(id_dep);
                return a.AITAProperty;
            }
        }

        public int IdDepProperty
        {
            get { return id_dep; }
            set
            {
                id_dep = value;
                OnPropertyChanged("id_dep");
            }
        }

        public string NomArrProperty
        {
            get
            {
                Aeroport a = new AeroportBdd().ChooseAeroport(id_arrive);
                return a.AITAProperty;
            }
        }

        public int IdArriveProperty
        {
            get { return id_arrive; }
            set
            {
                id_arrive = value;
                OnPropertyChanged("id_arrive");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                VolsBdd.updateVol(this);
            }
        }

    }
}
