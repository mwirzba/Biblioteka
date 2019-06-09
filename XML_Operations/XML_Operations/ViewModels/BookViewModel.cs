using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML_Operations.Models;

namespace XML_Operations
{
    class BookViewModel
    {
        //private List<Book> booksViewListData = new List<Book>();

        private string State;

        public List<Book> booksViewListData { get; set; } = new List<Book>();

        public BookViewModel()
        {
            GetBooks();
        }


        public void GetBooks()
        {
            XmlDocument document = new XmlDocument();
            document.Load("library.xml");

            XmlNode library = document.FirstChild;

            XmlNodeList books = document.GetElementsByTagName("Book");



            foreach (var item in books)
            {
                XmlElement currNode = (XmlElement)item;
                var date = XmlConvert.ToDateTime(currNode.LastChild.InnerText);

                booksViewListData.Add(new Book(currNode.FirstChild.InnerText, currNode.FirstChild.NextSibling.InnerText, date));


            }

        }




    }
}
