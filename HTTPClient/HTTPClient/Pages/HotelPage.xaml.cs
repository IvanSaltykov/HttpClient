using HTTPClient.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

namespace HTTPClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Page
    {
        private string _idPartWorld;
        private string _idCountry;
        private string _idCity;
        public HotelPage(string idPartWorld, string idCountry, string idCity)
        {
            InitializeComponent();
            _idPartWorld = idPartWorld;
            _idCountry = idCountry;
            _idCity = idCity;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            gridGetRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Collapsed;
            gridCheckRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Collapsed;
        }

        private void buttonGetCheckRequestHotel_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridGetRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
            getHotels();
        }

        private void buttonPostCheckRequestHotel_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
        }

        private void buttonInformationItem_Click(object sender, RoutedEventArgs e)
        {
            var hotel = (sender as Button).DataContext as Hotel;
            getHotel(hotel.id);
        }

        private void buttonEditItem_Click(object sender, RoutedEventArgs e)
        {
            var hotel = (sender as Button).DataContext as Hotel;
            string input = Interaction.InputBox($"id: {hotel.id}\n name: {hotel.Name}", "Изменить?", "", 10, 10);
            if (input != "")
                putHotel(hotel.id, input);
        }

        private void buttonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var hotel = (sender as Button).DataContext as Hotel;
            deleteHotel(hotel.id);
        }

        private void buttonPostRequestHotel_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPostRequestHotel.Text != "")
            {
                postHotel(textBoxPostRequestHotel.Text);
                textBoxPostRequestHotel.Text = "";
            }
        }
        private void listViewResponse_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hotel = (sender as ListView).SelectedItem as Hotel;
            if (hotel != null)
                Manager.frameWindow.Navigate(new Pages.TicketPage(_idPartWorld, _idCountry, _idCity, hotel.id));
        }
        private async Task getHotels()
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<List<Hotel>>($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels");
            listViewResponse.ItemsSource = response;
        }
        private async Task postHotel(string name)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var hotelNew = new HotelCreate { Name = name };
            var response = await Manager.client.PostAsJsonAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels", hotelNew);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
            else
                MessageBox.Show("Элемент создан");
        }
        private async Task getHotel(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<Hotel>($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels/{id}");
            MessageBox.Show($"id: {response.id}\n name: {response.Name}");
        }
        private async Task deleteHotel(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.DeleteAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels/{id}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
                getHotels();
            else
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
        }
        private async Task putHotel(string id, string nameNew)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var hotelUpdate = new HotelUpdate { Name = nameNew };
            await Manager.client.PutAsJsonAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels/{id}", hotelUpdate);
            getHotels();
        }
    }
}
