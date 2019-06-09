using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Operations.Models
{
    class Book
    {
        public string Title { get; set; }
        public string Category { get; set; }

        public DateTime ReleaseDate { get; set; }


        public Book(string title,string category,DateTime releaseDate)
        {
            Title = title;
            Category = category;
            ReleaseDate = releaseDate;
        }
    }
}
