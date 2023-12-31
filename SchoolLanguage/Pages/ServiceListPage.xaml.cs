﻿
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
                EntriesBtn.Visibility = Visibility.Hidden;
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
            if (DiscountFilterCb.SelectedIndex != 0)
            {
                if(DiscountFilterCb.SelectedIndex == 1)
                    serviceSortList = serviceSortList.Where(x=>x.Discount>=0 && x.Discount<5);
                if (DiscountFilterCb.SelectedIndex == 2)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 5 && x.Discount <15);
                if (DiscountFilterCb.SelectedIndex == 3)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 15 && x.Discount <30);
                if (DiscountFilterCb.SelectedIndex == 4)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 30 && x.Discount <70);
                if (DiscountFilterCb.SelectedIndex == 5)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 70 && x.Discount <100);
            }
            if(SearchTb.Text != null)
            {
                serviceSortList = serviceSortList.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()) || x.Description.ToLower().Contains(SearchTb.Text.ToLower()));
            }
            ServicesWp.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServicesWp.Children.Add(new ServiceUserControl(service));
            }
            CountDataTb.Text = serviceSortList.Count() + " из " + App.db.Service.Count();
        }
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent ("Добавление услуги", new AddEditServicePage(new Service())));
        }

        private void EntriesBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent ("Ближайшие записи", new ServiceEntriesPage()));
        }
    }
}
