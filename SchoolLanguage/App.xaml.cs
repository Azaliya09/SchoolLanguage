﻿using SchoolLanguage.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolLanguage
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SchoolLanguageAzaliya09Entities db = new SchoolLanguageAzaliya09Entities();
        public static bool isAdmin=false;     
    }
}
