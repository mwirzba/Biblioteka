using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using XML_Operations.Models;

namespace XML_Operations
{
    /// <summary>
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class BooksUserControll : UserControl
    {
        List<Book> booksViewListData = new List<Book>();
        public BooksUserControll()
        {

            InitializeComponent();

            BookViewModel bookViewModel = new BookViewModel();

            this.DataContext = bookViewModel;

//            booksList.ItemsSource = bookViewModel.GetBooks();



        
        }
    }
}
