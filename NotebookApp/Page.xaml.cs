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
    public static class PageVariables
    {
        public static int id;
        public static int index;
        public static int _maxImportance = 5;
    }
    /// <summary>
    /// Логика взаимодействия для Page.xaml
    /// </summary>
    
    public partial class Page : Window
    {
        ApplicationContext db;
       

        public Page()
        {
            InitializeComponent();
            SetContent();
        }
       
        public void SetContent()
        {
            notebox.ItemsSource = prepareContent();
        }
        public List<string> prepareContent()
        {
            db = new ApplicationContext();
            List<Note> notes = db.Notes.ToList();
            List<string> noteContent = new List<string>();
            return SortContent(notes, noteContent);
        }

        public List<string> SortContent(List<Note> notes, List<string> noteContent)
        {
            IEnumerable<Note> sortedNotes = notes.OrderBy(el => el.important);
            sortedNotes = sortedNotes.Reverse();
            foreach (Note note in sortedNotes)
            {
                noteContent.Add(note.text);
            }
            return noteContent;   
        }
        private void PageRefreshClick(object sender, RoutedEventArgs e)
        {
            
            SetContent();
        }

        private void PageAddNoteClick(object sender, RoutedEventArgs e)
        {
            MainWindow addWindow = new MainWindow();
            addWindow.Show();
        }

        private void PageDeleteNoteClick(object sender, RoutedEventArgs e)
        {
            if (notebox.SelectedIndex == -1) return;

            List<Note> notes = db.Notes.ToList();
            List<string> noteContent = new List<string>();
            
            int trueIndex = -1;                     //объявляю переменную для хранения значения индекса объекта из базы

            IEnumerable<Note> sortedNotes = notes.OrderBy(el => el.important);   //сортирую объекты для корректного отображения
            sortedNotes = sortedNotes.Reverse();
            List<int> SortedNotesId = new List<int>();

            foreach(var el in sortedNotes)
            { SortedNotesId.Add(el.id); }

            for (int i= 0; i<notes.Count; i++)
            {
                if (notes[i].id == SortedNotesId[notebox.SelectedIndex])  //сравниваю объекты по id, чтобы установить фактический индекс объекта
                {
                    trueIndex = i;
                }
            }
            db.Notes.Remove(notes[trueIndex]);
            db.SaveChanges();

            SetContent();
        }

        private void PageChangeNoteClick(object sender, RoutedEventArgs e)
        {
            if (notebox.SelectedIndex == -1) return;

            List<Note> notes = db.Notes.ToList();
            List<string> noteContent = new List<string>();


            int trueIndex = -1;


            IEnumerable<Note> sortedNotes = notes.OrderBy(el => el.important);
            sortedNotes = sortedNotes.Reverse();
            List<int> SortedNotesId = new List<int>();

            foreach (var el in sortedNotes)
            { SortedNotesId.Add(el.id); }
            int noteId=0;

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].id == SortedNotesId[notebox.SelectedIndex])
                {
                    trueIndex = i;
                    noteId = notes[i].id;
                }
                
            }
            PageVariables.id = noteId;
            PageVariables.index = trueIndex;
            ChangeWindow addWindow = new ChangeWindow();

            addWindow.NoteImportanceTextBox.Text = notes[trueIndex].important.ToString();
            addWindow.NoteContentTextBox.Text = notes[trueIndex].text;
            addWindow.Show();
        }
    }
}
