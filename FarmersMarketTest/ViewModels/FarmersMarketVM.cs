using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FarmersMarketTest.ViewModels
{
    class FarmersMarketVM : INotifyPropertyChanged
    {
        public ObservableCollection<StandVM> Items { get; } = new ObservableCollection<StandVM>();
        public ICommand EnterCommand { get; }
        public FarmersMarketVM()
        {
            EnterCommand = new RelayCommand(Enter);
        }
        private int numberOfStalls;
        public int NumberOfStalls
        {
            get { return numberOfStalls; }
            set
            {
                numberOfStalls = value;
                OnPropertyChanged();
            }
        }
        private void Enter()
        {
            Items.Clear(); // reset on each entry
            for (int i = 1; i <= NumberOfStalls; i++)
            {
                Items.Add(new StandVM { FarmerID = $"Stall {i}" });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
