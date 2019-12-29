using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FlashcardURL.Models
{
    public class SavedList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { set; get; }
        public string Tags { get; set; }
    }
}
