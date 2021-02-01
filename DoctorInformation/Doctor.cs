using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DoctorInformation
{
    public class Doctor : INotifyPropertyChanged
    {
        public int _doctorID;
        public int DoctorID
        {
            get => this._doctorID;
            set
            {
                this._doctorID = value;
                this.OnPropertyChanged(nameof(DoctorID));
            }
        }

        public string _name;
        public string Name
        {
            get => this._name;
            set
            {
                this._name = value;
                this.OnPropertyChanged(nameof(Name));

            }
        }

        public string _address;
        public string Address
        {
            get => this._address;
            set
            {
                this._address = value;
                this.OnPropertyChanged(nameof(Address));

            }
        }


        public string _phone;
        public string Phone
        {
            get => this._phone;
            set
            {
                this._phone = value;
                this.OnPropertyChanged(nameof(Phone));

            }
        }

        public string _email;
        public string Email
        {
            get => this._email;
            set
            {
                this._email = value;
                this.OnPropertyChanged(nameof(Email));

            }
        }

        public string _specialization;


        public string Specialization
        {
            get => this._specialization;
            set
            {
                this._specialization = value;
                this.OnPropertyChanged(nameof(Specialization));

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
