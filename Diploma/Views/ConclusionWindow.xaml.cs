using Diploma.Model;
using Diploma.Repositories;
using System.Linq;
using System.Windows.Media;
using Window = System.Windows.Window;

namespace Diploma.Views
{
    /// <summary>
    /// Interaction logic for ConclusionWindow.xaml
    /// </summary>
    public partial class ConclusionWindow : Window
    {
        private readonly ClientsRepository _clientsRepository;
        private readonly Client _client;
        private readonly ClientCharacteristics _clientCharacteristics;
        private readonly Loan _loan;
        private readonly Prerequisite _prerequisite;
        private readonly ClientForShowRepository _clientForShowRepository;
        private float finalGrade = 0;

        public ConclusionWindow(Client client, ClientForShowRepository clientForShowRepository)
        {
            InitializeComponent();
            _clientForShowRepository = clientForShowRepository;
            _clientsRepository = new(new());
            _client = client;
            _clientCharacteristics = _client.ClientCharacteristics!.First();
            _loan = _client.Loan!.First();
            _prerequisite = _client.Prerequisites!.First();

            OnInit();
        }

        private void OnInit()
        {
            finalGrade = (float)((_clientCharacteristics.OverallCharacteristicsScore! + _loan.OverallScore + _prerequisite.OverallCriteriaScore) / 3.0);

            _clientForShowRepository.UpdateFinalGrade(_client.IIN, (decimal)finalGrade);

            OverallCharacteristicsScoreRectangle.Width = (double)(430 * (_clientCharacteristics.OverallCharacteristicsScore! / 100));
            OverallCharacteristicsScoreRectangle.Fill = GetColorFromPercent((double)_clientCharacteristics.OverallCharacteristicsScore!);

            OverallCriteriaScoreRectangle.Width = 430 * (_prerequisite.OverallCriteriaScore / 100);
            OverallCriteriaScoreRectangle.Fill = GetColorFromPercent(_prerequisite.OverallCriteriaScore);

            OverallScoreRectangle.Width = 430 * (_loan.OverallScore / 100);
            OverallScoreRectangle.Fill = GetColorFromPercent(_loan.OverallScore);

            OverallCriteriaScore.Text = _prerequisite.OverallCriteriaScore.ToString();
            OverallScore.Text = _loan.OverallScore.ToString();
            OverallCharacteristicsScore.Text = _clientCharacteristics.OverallCharacteristicsScore.ToString();

            FinalGrade.Text = finalGrade.ToString();

            if (finalGrade >= 80)
            {
                QualityCategory.Text = "Кредитная заявка рекомендуется к рассмотрению";
                ConclusionColor.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x22, 0x8B, 0x22));
                ConclusionColor.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x6F, 0xCB, 0x6F));
            }
            else if (finalGrade >= 40 && finalGrade < 80)
            {
                QualityCategory.Text = "Кредитная заявка мало возможна к рассмотрению";
                ConclusionColor.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x80, 0x80, 0x80));
                ConclusionColor.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDF, 0xE2, 0x9D));
            }
            else
            {
                QualityCategory.Text = "Кредитование не рекомендовано";
                ConclusionColor.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
                ConclusionColor.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xF3, 0xBA, 0xBA));
            }

            _clientsRepository.Update(_client);
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
        }

        private static Brush GetColorFromPercent(double percent)
        {
            // Используем зеленый цвет как максимальный и красный как минимальный
            var minColor = Colors.Red;
            var maxColor = Colors.Green;

            // Проверяем граничные значения
            if (percent >= 100)
                return new SolidColorBrush(maxColor);
            else if (percent <= 0)
                return new SolidColorBrush(minColor);

            // Вычисляем цвет на основе процента
            var color = Color.FromRgb(
                (byte)((maxColor.R - minColor.R) * percent / 100 + minColor.R),
                (byte)((maxColor.G - minColor.G) * percent / 100 + minColor.G),
                (byte)((maxColor.B - minColor.B) * percent / 100 + minColor.B));

            return new SolidColorBrush(color);
        }




    }
}
