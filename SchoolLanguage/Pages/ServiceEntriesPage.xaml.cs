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
            var nextDate = DateTime.Today.AddDays(1);
            //EntriesPage.ItemsSource = App.db.ClientService.Where(x=> x.StartTime.ToString("dd.MM.YYYY") == DateTime.Now.ToString("dd.MM.YYYY") || x.StartTime.ToString("dd.MM.YYYY") == nextDate.ToString("dd.MM.YYYY")).ToList();
            EntriesPage.ItemsSource = App.db.ClientService.ToList();
        }
    }
}
