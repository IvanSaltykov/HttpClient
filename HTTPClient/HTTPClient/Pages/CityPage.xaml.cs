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
    /// Логика взаимодействия для CityPage.xaml
    /// </summary>
    public partial class CityPage : Page
    {
        private string _idPartWorld;
        private string _idCountry;
        public CityPage(string idPartWorld, string idCountry)
        {
            InitializeComponent();
            _idPartWorld = idPartWorld;
            _idCountry = idCountry;
        }

        private void buttonGetCheckRequestCity_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridGetRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
            getCities();
        }

        private void buttonPostCheckRequestCity_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
        }

        private void buttonInformationItem_Click(object sender, RoutedEventArgs e)
        {
            var city = (sender as Button).DataContext as City;
            getCity(city.id);
        }

        private void buttonEditItem_Click(object sender, RoutedEventArgs e)
        {
            var city = (sender as Button).DataContext as City;
            string input = Interaction.InputBox($"id: {city.id}\n name: {city.Name}", "Изменить?", "", 10, 10);
            if (input != "")
                putCity(city.id, input);
        }

        private void buttonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var city = (sender as Button).DataContext as City;
            deleteCity(city.id);
        }

        private void buttonPostRequestCity_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPostRequestCity.Text != "")
            {
                postCity(textBoxPostRequestCity.Text);
                textBoxPostRequestCity.Text = "";
            }
        }
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            gridGetRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Collapsed;
            gridCheckRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Collapsed;
        }
        private void listViewResponse_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var city = (sender as ListView).SelectedItem as City;
            if (city != null)
                Manager.frameWindow.Navigate(new Pages.HotelPage(_idPartWorld, _idCountry, city.id));
        }
        private async Task getCities()
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<List<City>>($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities");
            listViewResponse.ItemsSource = response;
        }
        private async Task postCity(string name)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var cityNew = new CityCreate { Name = name };
            var response = await Manager.client.PostAsJsonAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities", cityNew);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
            else
                MessageBox.Show("Элемент создан");
        }
        private async Task getCity(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<City>($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{id}");
            MessageBox.Show($"id: {response.id}\n name: {response.Name}");
        }
        private async Task deleteCity(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.DeleteAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{id}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
                getCities();
            else
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
        }
        private async Task putCity(string id, string nameNew)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var cityUpdate = new CityUpdate { Name = nameNew };
            await Manager.client.PutAsJsonAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{id}", cityUpdate);
            getCities();
        }
    }
}
