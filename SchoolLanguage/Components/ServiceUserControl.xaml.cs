using SchoolLanguage.Base;
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

namespace SchoolLanguage.Components
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl.xaml
    /// </summary>
    public partial class ServiceUserControl : UserControl
    {
        public ServiceUserControl(Service service)
        {
            InitializeComponent();
            TitleTb.Text = service.Title;
            CostTimeTb.Text = service.costTimeStr;
            DiscountTb.Text = service.DiscountStr;
            CostTb.Text = (service.Cost).ToString("N0") + " ";
            CostTb.Visibility = service.CostVisibility;

        }
    }
}
