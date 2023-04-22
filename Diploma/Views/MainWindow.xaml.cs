using Diploma.Repositories;
using System.Windows;

namespace Diploma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly DataBaseContext _dbContext;

        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void ButtonEnter(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("asds");

            //if (IINField.Text == "020503500655")
            //{
            //    MessageBox.Show("Succesfully entered");
            //} 
            //else
            //{
                //Loading loading = new Loading();
                //loading.Show();
            //}
        }
    }
}
