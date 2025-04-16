using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FarmersMarketTest.ViewModels
{
    public class FarmersMarketVM : INotifyPropertyChanged
    {
        public ObservableCollection<FarmerStallVM> Items { get; } = new ObservableCollection<FarmerStallVM>();
        public ICommand EnterCommand { get; }
        public ICommand AssignFarmerCommand { get; }
        public ICommand AddProduceCommand { get; }
        public List<Produce> ProduceList { get; }

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
            Items.Clear(); // Reset the stands on each entry
            var rand = new Random(); // Create a single instance of Random
            for (int i = 1; i <= NumberOfStalls; i++)
            {
                Items.Add(new FarmerStallVM
                {
                    Farmer = new Farmer { Name = $"Farmer {i}" },
                    Produce = new List<Produce>
                    {
                        new Produce { Name = "Apple", Amount = rand.Next(1, 11) } // Generate a random integer between 1 and 100
                    }
                });
            }
        }

      
       

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   
    public class Produce
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public override string ToString()
        {
            return $"{Name} (Amount: {Amount})";
        }
    }

    public class Farmer
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} ";
        }
    }
}
