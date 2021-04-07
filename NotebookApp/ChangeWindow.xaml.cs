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
using System.Windows.Shapes;

namespace NotebookApp
{
    /// <summary>
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        ApplicationContext db;

        public ChangeWindow()
        {
            db = new ApplicationContext();
            InitializeComponent();
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

        private void ChangeClick(object sender, RoutedEventArgs e)
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

                List<Note> notes = db.Notes.ToList();

                 var _note = db.Notes
                    .Where(n => n.id == PageVariables.id)
                    .FirstOrDefault();
                _note.text = text;
                _note.important = importenceValue;

                db.SaveChanges();

                Close();
            }
        }
    }
}
