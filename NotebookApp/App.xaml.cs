using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NotebookApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }
      
        [STAThread]
      public static void Main()
      {
            App app = new App();
            Page windowPage = new Page();
            app.Run(windowPage);
      }
    }
}
