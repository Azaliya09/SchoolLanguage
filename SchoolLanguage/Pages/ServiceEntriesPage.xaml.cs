using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace SchoolLanguage.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceEntriesPage.xaml
    /// </summary>
    public partial class ServiceEntriesPage : Page
    {
        public ServiceEntriesPage()
        {
            InitializeComponent();
            var endDate = DateTime.Now.AddDays(2);
            //var startDate = Convert.ToDateTime.Today - new DateTime(0000, 00, 01);
            //EntriesPage.ItemsSource = App.db.ClientService.Where(x=> x.StartTime.ToString("dd.MM.YYYY") == DateTime.Now.ToString("dd.MM.YYYY") || x.StartTime.ToString("dd.MM.YYYY") == nextDate.ToString("dd.MM.YYYY")).ToList();
            EntriesPage.ItemsSource = App.db.ClientService.Where(x => x.StartTime >= DateTime.Now && x.StartTime < endDate).OrderBy(x => x.StartTime).ToList();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();
        }

        private void EnteriesList_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var endDate = DateTime.Now.AddDays(2);
            EntriesPage.ItemsSource = App.db.ClientService.Where(x => x.StartTime >= DateTime.Now && x.StartTime < endDate).OrderBy(x => x.StartTime).ToList();
        }
    }
}
