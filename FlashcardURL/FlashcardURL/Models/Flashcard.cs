using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FlashcardURL.Models
{
    public class Flashcard
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Tags { get; set; }
    }
}
