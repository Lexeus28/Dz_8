using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_DmitriyNikolaevichTumakov_7
{
    public class Song
    {

        private string Name { get; set; }
        private string Author { get; set; }
        private Song Prev { get; set; }

        public Song(string Name, string Author)
        {
            this.Name = Name;
            this.Author = Author;
            Prev = null;
        }
        public Song(string Name, string Author, Song Prev)
        {
            this.Name = Name;
            this.Author = Author;
            this.Prev = Prev;
        }
        public Song()
        {
            Name = "Undefined";
            Author = "Nobody";
            Prev = null;
        }
        public string GetName(string n)
        {
            this.Name = n;
            return this.Name;
        }
        public string GetAuthor(string a)
        {
            this.Author = a;
            return this.Author;
        }
        public Song GetPrev(Song p)
        {
            this.Prev = p;
            return this.Prev;
        }
        public string Title()
        {
            return $"{Name} - {Author}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Song other = (Song)obj;
            return Title == other.Title;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Author);
        }
    }
}
