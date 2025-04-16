using FarmersMarketTest.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FarmersMarketTest.ViewModels
{
    public class FarmerStallVM : INotifyPropertyChanged
    {
        public FarmerStallVM()
        {
            ConfirmCommand = new RelayCommand(Confirm);
        }
        public ICommand ConfirmCommand { get; }

        private int appleAmount;
        public int AppleAmount
        {
            get => Produce?.FirstOrDefault()?.AppleAmount ?? 0;
            set
            {
                if (Produce != null && Produce.Any())
                {
                    Produce[0].AppleAmount = value;
                    OnPropertyChanged();
                }
            }
        }

        private void Confirm()
        {
            int i = 0;
            for (i = 0; i < Produce.Count; i++)
            {

                var ProduceFromStallNum = Produce[i];

                int appleAmount = ProduceFromStallNum.AppleAmount;
                int bananaAmount = ProduceFromStallNum.BananaAmount;
                int carrotAmount = ProduceFromStallNum.CarrotAmount;
                int orangeAmount = ProduceFromStallNum.OrangeAmount;
                int mangoAmount = ProduceFromStallNum.MangoAmount;
            }

            
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
