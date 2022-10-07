using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataAnalysisApplication.MVVM.ViewModels;

namespace DataAnalysisApplication
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        DataAnalysisWindow dataAnalysis;
        public void ApplicationStart(object sender, StartupEventArgs e)
        {
            dataAnalysis = new DataAnalysisWindow();
            dataAnalysis.Show();
        }

    }
}
