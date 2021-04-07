using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
   public class Note
    {
       public int id { get; set; }
       public string text { get; set; }
       public int important { get; set; }

        public Note() { }

        public Note(string text, int important)
        { 
            this.text = text;
            this.important = important;
        }
    }
}
