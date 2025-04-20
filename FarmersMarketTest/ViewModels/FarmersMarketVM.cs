using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FarmersMarketTest.ViewModels
{
    public class FarmersMarketVM : INotifyPropertyChanged
    {
        public ObservableCollection<FarmerStallVM> Items { get; } = new ObservableCollection<FarmerStallVM>();
        public ICommand EnterCommand { get; }
        public ICommand BuyProduceCommand { get; }

        private string appleAmount;
        public string AppleAmount
        {
            get { return appleAmount; }
            set
            {
                appleAmount = value;
                OnPropertyChanged();
            }
        }

        public List<Produce> ProduceList { get; }
        public List<Produce> MarketList { get; }

        private readonly List<string> produceNames;

        public FarmersMarketVM()
        {
            MarketList = new List<Produce>();
            EnterCommand = new RelayCommand(Enter);
            produceNames = new List<string> { "Apple", "Banana", "Carrot", "Orange", "Mango" };
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
                                Name = "Stall "+i.ToString(),
                                AppleAmount = rand.Next(1, 10),
                                BananaAmount = rand.Next(1, 10),
                                CarrotAmount = rand.Next(1, 10),
                                OrangeAmount = rand.Next(1, 10),
                                MangoAmount = rand.Next(1, 10)
                            }
                        }
                });
            }
        }

        public void PrintMarketList()
        {
            if (MarketList == null || !MarketList.Any())
            {
                Console.WriteLine("MarketList is empty.");
                return;
            }

            int totalApples = 0, totalBananas = 0, totalCarrots = 0, totalOranges = 0, totalMangoes = 0;

            foreach (var produce in MarketList)
            {
                Console.WriteLine($"Name: {produce.Name}, AppleAmount: {produce.AppleAmount}, BananaAmount: {produce.BananaAmount}, CarrotAmount: {produce.CarrotAmount}, OrangeAmount: {produce.OrangeAmount}, MangoAmount: {produce.MangoAmount}");
                totalApples += produce.AppleAmount;
                totalBananas += produce.BananaAmount;
                totalCarrots += produce.CarrotAmount;
                totalOranges += produce.OrangeAmount;
                totalMangoes += produce.MangoAmount;
            }

            Console.WriteLine("\nTotal Produce:");
            Console.WriteLine($"Total Apples: {totalApples}");
            Console.WriteLine($"Total Bananas: {totalBananas}");
            Console.WriteLine($"Total Carrots: {totalCarrots}");
            Console.WriteLine($"Total Oranges: {totalOranges}");
            Console.WriteLine($"Total Mangoes: {totalMangoes}");
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
