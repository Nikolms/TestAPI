using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> books = new List<Book>();
        BookDetailDTO currentSelection = new BookDetailDTO();

        public MainWindow()
        {
            InitializeComponent();
            textTitle.DataContext = currentSelection.Title;
            textAuthor.DataContext = currentSelection.AuthorName;
            textYear.DataContext = currentSelection.Year.ToString();
            textGenre.DataContext = currentSelection.Genre;
            
        }

        async void UpdateBookList() 
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57656/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Books");

                if (response.IsSuccessStatusCode)
                {
                    books = response.Content.ReadAsAsync<List<Book>>().Result;
                }
            }
            catch 
            {
                MessageBox.Show("Error");
            }

            kirjaLista.ItemsSource = books;
        }

        async void GetDetails(int id) 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57656/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Books/"+ id);

                if (response.IsSuccessStatusCode)
                {
                    currentSelection = response.Content.ReadAsAsync<BookDetailDTO>().Result;
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        void createItem() 
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateBookList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Book b;

            if (kirjaLista.SelectedItem != null)
            {
                b = (Book)kirjaLista.SelectedItem;
                GetDetails(b.ID);
            }
        }
    }

    public class Book 
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }

    public class BookDetailDTO 
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public string AuthorName { get; set; }
    }
}
