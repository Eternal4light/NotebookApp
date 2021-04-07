using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotebookApp;

namespace NotebookAppTest
{
    [TestClass]
    public class PageTests
    {


        [TestMethod]
        public void SortContent_123_res321()
        {
            //Arrange
            Page _page = new Page();

            List<Note> _notes = new List<Note>();
            List<string> noteContent = new List<string>();
            Note note1 = new Note("1", 1);
            Note note2 = new Note("2", 2);
            Note note3 = new Note("3", 3);
            _notes.Add(note1);
            _notes.Add(note2);
            _notes.Add(note3);

            List<string> expected = new List<string>();
            expected.Add("3");
            expected.Add("2");
            expected.Add("1");

            //Act
            List<string> res = _page.SortContent(_notes, noteContent);
            
            //Assert
            Assert.AreEqual(res[0], expected[0]);
            Assert.AreEqual(res[1], expected[1]);
            Assert.AreEqual(res[2], expected[2]);
        }
        
    }
}
