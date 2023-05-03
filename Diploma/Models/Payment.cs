using System.ComponentModel;

namespace Diploma.Models
{
    public class Payment : INotifyPropertyChanged
    {
        public int Period { get; set; }
        public double Amount { get; set; }
        public double Interest { get; set; }
        public double Principal { get; set; }
        private double balance;
        public double Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
