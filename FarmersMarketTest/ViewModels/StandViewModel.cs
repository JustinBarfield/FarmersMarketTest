using FarmersMarketTest.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FarmersMarketTest.ViewModels
{
    public class StandViewModel : INotifyPropertyChanged
    {
        public StandViewModel()
        {
            StandCommand = new RelayCommand(OpenStandWindow);
        }

        private void OpenStandWindow()
        {
            StandWindow standWindow = new StandWindow();
            standWindow.Show();
        }

        public ICommand StandCommand { get; }

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

        private Farmer farmer;
        public Farmer Farmer
        {
            get { return farmer; }
            set
            {
                farmer = value;
                OnPropertyChanged();
            }
        }

        private List<Produce> produce;
        public List<Produce> Produce
        {
            get { return produce; }
            set
            {
                produce = value;
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
