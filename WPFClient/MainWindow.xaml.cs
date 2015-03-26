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

        public MainWindow()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateBookList();
        }
    }

    public class Book 
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }
}
