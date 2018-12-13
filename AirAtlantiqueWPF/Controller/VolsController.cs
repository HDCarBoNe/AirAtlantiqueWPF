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
        private Aeroport id_dep;
        private Aeroport id_arrive;

        public Vols() { }

        public Vols(int idvols, string departprevu, string departreel, string arriveprevu, string arrivereel, int idavion, Aeroport id_dep, Aeroport id_arrive)
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
            set
            {
                idvols = value;
            }
        }

        public string DepartprevuProperty
        {
            get { return departprevu; }
            set
            {
                departprevu = value;
            }
        }

        public string DepartreelProperty
        {
            get { return departreel; }
            set
            {
                departreel = value;
            }
        }

        public string ArriveprevuProperty
        {
            get { return arriveprevu; }
            set
            {
                arriveprevu = value;
            }
        }

        public string ArrivereelProperty
        {
            get { return arrivereel; }
            set
            {
                arrivereel = value;
            }
        }

        public int IdAvionProperty
        {
            get { return idavion; }
            set
            {
                idavion = value;
            }
        }

        public Aeroport IdDepProperty
        {
            get { return id_dep; }
            set
            {
                id_dep = value;
            }
        }

        public Aeroport IdArriveProperty
        {
            get { return id_arrive; }
            set
            {
                id_arrive = value;
            }
        }

        public void add_flight()
        {


        }

        public void remove_flight()
        {


        }

        public void view_flight()
        {


        }

        public void change_flight()
        {

        }

        public void search_flight()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
