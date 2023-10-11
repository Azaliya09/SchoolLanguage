
using SchoolLanguage.Base;
using SchoolLanguage.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            if(App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<Service>serviceSortList = App.db.Service;
            if (SortCb.SelectedIndex > 0)
            {
                if(SortCb.SelectedIndex ==1)
                {
                    serviceSortList = serviceSortList.OrderBy(x => x.CostDiscount);
                }
                else 
                {
                    serviceSortList = serviceSortList.OrderByDescending(x => x.CostDiscount);
                }
                    
            }
            ServicesWp.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServicesWp.Children.Add(new ServiceUserControl(service));
            }
        }
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
