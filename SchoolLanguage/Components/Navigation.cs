using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolLanguage.Components
{
    static class Navigation
    {
        private static List<PageComponent> components = new List<PageComponent>();//храним историю
        public static MainWindow mainWindow;//получаем доступ ко всем элементам

        private static void Update(PageComponent pageComponent)//принимает компонент к-й мы хотим открыть
        {
            mainWindow.TitleTb.Text = pageComponent.Title;//записывает заголок
            mainWindow.BackBtn.Visibility = components.Count() > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;//скрывает кнопку назад 
            mainWindow.ExitBtn.Visibility = App.isAdmin ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;//скрывает кнопку выход
            mainWindow.MainFrame.Navigate(pageComponent.Page);//открываем страницу
        }
        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);//добавление нового окна
            Update(pageComponent);
        }

        public static void BackPage()
        {
            if(components.Count() > 1)
            {
                components.RemoveAt(components.Count - 1);//удаляем последний элемент коллекции 
                Update(components[components.Count - 1]);
            }
        }


    }
    class PageComponent  //хранит заголовок и страницу
    {
        public string Title { get; set; }  
        public Page Page { get; set; }
        public PageComponent(string title, Page page)
        {
            Page = page;
            Title = title;
        }
    }
}
