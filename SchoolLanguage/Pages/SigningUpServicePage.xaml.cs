using SchoolLanguage.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для SigningUpServicePage.xaml
    /// </summary>
    public partial class SigningUpServicePage : Page
    {
        Service service;
        public SigningUpServicePage(Service _service)
        {
            InitializeComponent();
            service= _service;
            this.DataContext = service;                                                                                    
            ClientCb.ItemsSource = App.db.Client.ToList();
            ClientCb.DisplayMemberPath = "FullName";
            DateDp.DisplayDateStart = DateTime.Now;
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DateDp.SelectedDate != null && TimeTb.Text != "" && ClientCb.SelectedItem != null)
            {
                var selDateTime = $"{DateDp.SelectedDate.Value.ToString("yyyy-MM-dd")} {TimeTb.Text}";//MM-только  с заглавных букв
                var timeSplit = TimeTb.Text.Split(':');
                var hour = int.Parse(timeSplit[0]);
                var minute = int.Parse(timeSplit[1]);
                if(DateTime.TryParse(selDateTime, out DateTime result)) //TryParse возвращает  try/false
                {
                    if(DateTime.Now < result)
                    {
                        var selectClient = ClientCb.SelectedItem as Client;
                        App.db.ClientService.Add(new ClientService()
                        {
                            ClientID = selectClient.ID,
                            ServiceID = service.ID,
                            StartTime = result
                        });
                        MessageBox.Show("Запись добавлена!!");
                        App.db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Нельзя записать на прошедшее время!!");
                    }
                
                }
                else
                {
                    MessageBox.Show("Неверный формат времени!!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!!");
            }

        }
    }
}
