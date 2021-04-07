using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using NotebookApp;

namespace NotebookApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
           
            SetImportance(PageVariables._maxImportance);
        }

        private void SetImportance(int imp)
        {
            List<string> arr = new List<string>();
            int maxImportance = imp;
            for (int i = -1; i <= maxImportance; i++)
            {
                arr.Add(i.ToString());
            }

            NoteImportanceTextBox.ItemsSource = arr;
        }

        private void AddNoteClick(object sender, RoutedEventArgs e)
        {
            string text = NoteContentTextBox.Text;
            string importance = NoteImportanceTextBox.Text;
            int importenceValue;
            if (int.TryParse(importance, out importenceValue) == false)
            {
                NoteImportanceTextBox.ToolTip = "Please, pick a number";
                
            }
            else
            {
                NoteImportanceTextBox.ToolTip = "Please, pick a number";
               
            } 
            if (text.Length < 4)
            {
                NoteContentTextBox.ToolTip = "Input at least four chars";
                NoteContentTextBox.Background = Brushes.DarkRed;
            }
            else
            {
                NoteImportanceTextBox.ToolTip = "";
                NoteImportanceTextBox.Background = Brushes.Transparent;

                NoteContentTextBox.ToolTip = "";
                NoteContentTextBox.Background = Brushes.Transparent;

                Note note1 = new Note(text, importenceValue);

                db.Notes.Add(note1);
                db.SaveChanges();
                
                Close();
                
            }
           


        }
        
    }
}
