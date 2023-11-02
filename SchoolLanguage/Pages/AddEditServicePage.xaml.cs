using Microsoft.Win32;
using SchoolLanguage.Base;
using SchoolLanguage.Components;
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

namespace SchoolLanguage.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private Service service;
        public AddEditServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
            PhotoList.ItemsSource = App.db.ServicePhoto.Where(x => x.ServiceID == service.ID).ToList();
            if (service.ID != 0)
                StackPanelPhoto.Visibility = Visibility.Visible;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                App.db.ServicePhoto.Add(new ServicePhoto()
                {
                    ServiceID = service.ID,
                    PhotoPath = File.ReadAllBytes(openFile.FileName)
                });
                App.db.SaveChanges();
                PhotoList.ItemsSource = App.db.ServicePhoto.Where(x => x.ServiceID == service.ID).ToList();
            }
        }

        private void DeleteImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectPhoto = PhotoList.SelectedItem as ServicePhoto;
            if(selectPhoto != null)
            {
                App.db.ServicePhoto.Remove(selectPhoto);
            }
            else
            {
                MessageBox.Show("Ничего не выбрано!");
            }
            App.db.SaveChanges();
            PhotoList.ItemsSource = App.db.ServicePhoto.Where(x => x.ServiceID == service.ID).ToList();
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            openFile.ShowDialog();
            if (openFile.FileName != null)
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                ImageImg.Source = new BitmapImage(new Uri(openFile.FileName));
            }

        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (service.DurationInSeconds > 14400)
                error.AppendLine("Услуга не может превышать 4 часа! ");

            if (service.ID == 0)
            {
                Service newService = App.db.Service.Add(service);
                if (App.db.Service.Any(x => x.Title == service.Title))
                    error.AppendLine("Услуга с таким именем уже существует! ");

            }
            else
            {
                App.db.Service.Add(service);
                StackPanelPhoto.Visibility = Visibility.Visible;
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");
            Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));

        }
    }
}
