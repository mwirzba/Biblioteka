using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Xml;

namespace XML_Operations
{
    /// <summary>
    /// Interaction logic for NewBook.xaml
    /// </summary>
    public partial class NewBook : UserControl
    {
        public NewBook()
        {
            InitializeComponent();
        }

        private void AddNewBook(object sender, RoutedEventArgs e)
        {
            DateTime rDate;
            if (string.IsNullOrEmpty(titleBox.Text) || string.IsNullOrEmpty(dateBox.Text) || string.IsNullOrEmpty(titleBox.Text) || !DateTime.TryParseExact(dateBox.Text,
                       "yyyy-MM-dd",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out rDate))
            {
                userMessage.Content = "Wrong input data!";
            }
            else
            {
                XmlDocument document = new XmlDocument();
                document.Load("library.xml");

                XmlNodeList libraryList = document.GetElementsByTagName("Library");

                XmlNode library = libraryList.Item(0);

                XmlNode books = library.FirstChild.NextSibling;
                

                XmlElement book = document.CreateElement("Book");
                XmlElement title = document.CreateElement("Title");
                title.InnerText = titleBox.Text;
                XmlElement date = document.CreateElement("ReleaseDate");
                date.InnerText = dateBox.Text;
                XmlElement category = document.CreateElement("Category");
                category.InnerText = dateBox.Text;
                book.AppendChild(title);
                book.AppendChild(category);
                book.AppendChild(date);

                books.AppendChild(book);

                userMessage.Content = "Book has been added.";

                document.Save("library.xml");
            }
        }
    }
}
