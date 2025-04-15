using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FarmersMarketTest.ViewModels
{
   public class StandVM : INotifyPropertyChanged
    {
        public StandVM()
        {
            farmerID = "hello world";
        }
        private string farmerID;
        public string FarmerID
        {
            get { return farmerID; }
            set
            {
                farmerID = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
