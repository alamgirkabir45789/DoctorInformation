using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DoctorInformation
{
    public class ViewModel : INotifyPropertyChanged
    {
        private List<Doctor> doctors;

        public Command NextDoctor { get; private set; }
        public Command PreviousDoctor { get; private set; }


        private int currentDoctor;
        public ViewModel()
        {

            this.currentDoctor = 0;
            this.IsAtStart = true;
            this.IsAtEnd = false;

            this.NextDoctor = new Command(this.Next, () => this.doctors.Count > 1 && !this.IsAtEnd);

            this.PreviousDoctor = new Command(this.Previous, () => this.doctors.Count > 0 && !this.IsAtStart);



            this.doctors = new List<Doctor>
            {
                new Doctor
                {
                    DoctorID=1,
                    Name="Alamgir",
                    Address="Dinajpur",
                    Phone="0121212111",
                    Email="alam@gmail.com",
                    Specialization="Cardiac"
            
                },

                new Doctor
                {
                    DoctorID=2,
                    Name="Shabana",
                    Address="Chittagong",
                    Phone="0158555",
                    Email="shabana@gmail.com",
                    Specialization="Surgery"

                },

                new Doctor
                {
                    DoctorID=3,
                    Name="Mizan",
                    Address="Pabna",
                    Phone="01255111",
                    Email="mizan@gmail.com",
                    Specialization="Medicine"

                }



            };
        }


        private bool _isAtStart;
        public bool IsAtStart
        {
            get => this._isAtStart;
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged(nameof(IsAtStart));
            }
        }

        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get => this._isAtEnd;
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged(nameof(IsAtEnd));
            }
        }


        public Doctor Current
        {
            get => this.doctors.Count > 0 ? this.doctors[currentDoctor] : null;
        }

        private void Next()
        {
            if (this.doctors.Count - 1 > this.currentDoctor)
            {
                this.currentDoctor++;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtStart = false;
                this.IsAtEnd = (this.doctors.Count - 1 == this.currentDoctor);
            }
        }

        private void Previous()
        {
            if (this.doctors.Count > 0)
            {
                this.currentDoctor--;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentDoctor == 0);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
