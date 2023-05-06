using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PZ_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cancellationTokenSource;
        public string Status { get; set; }
        public int Progress { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private async void StartCalculations_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;
            try
            {
                await Task.Run(() => DoLongCalculations(cancellationToken), cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Status = "Calculations cancelled";
            }
            finally
            {
                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Dispose();
                    _cancellationTokenSource = null;
                }

            }
        }
        private void DoLongCalculations(CancellationToken cancellationToken)
        {
            const int iterationsCount = 10;
            const int delayMilliseconds = 500;
            for (var i = 0; i < iterationsCount; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }
                Thread.Sleep(delayMilliseconds);
                var progress = (i + 1) * 100 / iterationsCount;
                Dispatcher.Invoke(() => PR1.Value = progress);
            }
            Dispatcher.Invoke(() => Status = "Готово");
            MessageBox.Show("Асинхронный подход позволяет улучшить пользовательский опыт и повысить отзывчивость приложения.\r\nПользователь может продолжать работу с формой во время выполнения длительных вычислений,\r\nи он видит прогресс выполнения вычислений в реальном времени. Кроме того, асинхронный подход\r\nпозволяет более эффективно использовать ресурсы компьютера, так как приложение не блокирует\r\nосновной поток выполнения. Однако при использовании асинхронного подхода необходимо учитывать\r\nпотенциальные проблемы, такие как гонки данных и блокировка ресурсов.");
        }
        private void CancelCalculations_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}
