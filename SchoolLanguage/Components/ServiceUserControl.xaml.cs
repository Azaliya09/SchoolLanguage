using SchoolLanguage.Base;
using SchoolLanguage.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
        private Service service;
        public ServiceUserControl(Service _service)
        {
            InitializeComponent();
            service= _service;
            if(App.isAdmin==false)
            {
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
                SignUpBtn.Visibility = Visibility.Hidden;
            }
            TitleTb.Text = service.Title;
            CostTimeTb.Text = service.costTimeStr;
            DiscountTb.Text = service.DiscountStr;
            CostTb.Text = (service.Cost).ToString("N0") + " ";
            CostTb.Visibility = service.CostVisibility;
            MainBorder.Background = service.ColorDiscount;
            ImageImg.Source = GetImageSources(service.MainImage);

        }
        private BitmapImage GetImageSources(byte[] byteImage)
        {
            MemoryStream byteStream = new MemoryStream(byteImage);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;                                              
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Редактирование услуги", new AddEditServicePage(service)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(service.ClientService.Count != 0)
            {
                MessageBox.Show("Удаление запрещено");
            }
            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
                Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));

            }
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Запись на услугу", new SigningUpServicePage(service)));
        }
    }   
}
