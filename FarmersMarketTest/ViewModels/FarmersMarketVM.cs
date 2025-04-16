using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
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
        public ICommand BuyProduceCommand { get; }
        
        public List<Produce> ProduceList { get; }

        private readonly List<string> produceNames; // Declare produceNames as a class-level field

        public FarmersMarketVM()
        {
            EnterCommand = new RelayCommand(Enter);
            //BuyProduceCommand = new RelayCommand(BuyProduce);
            produceNames = new List<string> { "Apple", "Banana", "Carrot", "Orange", "Mango" }; // Initialize produceNames here
        }

        //private void BuyProduce()
        //{
        //    if (Items.Count > 0)
        //    {
        //        var selectedStall = Items[0]; // Assuming the first stall is selected for simplicity
        //        if (selectedStall.Produce != null && selectedStall.Produce.Count > 0)
        //        {
        //            var selectedProduce = selectedStall.Produce[0]; // Assuming the first produce item is selected
        //            if (selectedProduce.Amount > 0)
        //            {
        //                selectedProduce.Amount--; // Decrease the amount of produce
        //                OnPropertyChanged(nameof(Items)); // Notify UI of changes
        //            }
        //        }
        //    }
        //}

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
            Items.Clear(); 
            var rand = new Random(); 
            for (int i = 1; i <= NumberOfStalls; i++)
            {
                Items.Add(new FarmerStallVM
                {
                    Farmer = new Farmer { Name = $"Farmer {i}" },
                    Produce = new List<Produce>
                        {
new Produce
{
    Name = produceNames[rand.Next(produceNames.Count)],
    AppleAmount = 0,
    BananaAmount = 0,
    CarrotAmount = 0,
    OrangeAmount = 0,
    MangoAmount = 0
} // Initialize all amounts to zero
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
        public int AppleAmount { get; set; }
        public int BananaAmount { get; set; }
        public int CarrotAmount { get; set; }
        public int OrangeAmount { get; set; }
        public int MangoAmount { get; set; }

      

        public Produce()
        {
            
        }

       

        public override string ToString()
        {
            return $"{Name} ";
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
