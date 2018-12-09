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
        private DateTime departprevu;
        private DateTime departreel;
        private DateTime arriveprevu;
        private DateTime arrivereel;
        private int idavion;
        private int id_dep;
        private int id_arrive;

        public Vols() { }

        public Vols(int idvols, DateTime departprevu, DateTime departreel, DateTime arriveprevu, DateTime arrivereel, int idavion, int id_dep, int id_arrive)
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

        public DateTime DepartprevuProperty
        {
            get { return departprevu; }
            set
            {
                departprevu = value;
            }
        }

        public DateTime DepartreelProperty
        {
            get { return departreel; }
            set
            {
                departreel = value;
            }
        }

        public DateTime ArriveprevuProperty
        {
            get { return arriveprevu; }
            set
            {
                arriveprevu = value;
            }
        }

        public DateTime ArrivereelProperty
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

        public int IdDepProperty
        {
            get { return id_dep; }
            set
            {
                id_dep = value;
            }
        }

        public int IdArriveProperty
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
