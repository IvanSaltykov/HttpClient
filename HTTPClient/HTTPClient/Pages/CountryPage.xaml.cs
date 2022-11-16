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
    /// Логика взаимодействия для CountryPage.xaml
    /// </summary>
    public partial class CountryPage : Page
    {
        private string _idPartWorld;
        public CountryPage(string idPartWorld)
        {
            InitializeComponent();
            _idPartWorld = idPartWorld;
        }

        private void buttonGetCheckRequestCountry_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridGetRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
            getCountries();
        }

        private void buttonPostCheckRequestCountry_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
        }
        private void buttonPostRequestCountry_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPostRequestCountry.Text != "")
            {
                postCountry(textBoxPostRequestCountry.Text);
                textBoxPostRequestCountry.Text = "";
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            gridGetRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Collapsed;
            gridCheckRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Collapsed;
        }
        private void buttonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var country = (sender as Button).DataContext as Country;
            deleteCountry(country.id);
        }

        private void buttonInformationItem_Click(object sender, RoutedEventArgs e)
        {
            var country = (sender as Button).DataContext as Country;
            getCountry(country.id);
        }
        private void buttonEditItem_Click(object sender, RoutedEventArgs e)
        {
            var country = (sender as Button).DataContext as Country;
            string input = Interaction.InputBox($"id: {country.id}\n name: {country.Name}", "Изменить?", "", 10, 10);
            if (input != "")
                putCountry(country.id, input);
        }
        private void listViewResponse_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var country = (sender as ListView).SelectedItem as Country;
            if (country != null)
                Manager.frameWindow.Navigate(new Pages.CityPage(_idPartWorld, country.id));
        }
        private async Task getCountries()
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<List<Country>>($"api/partworlds/{_idPartWorld}/countries");
            listViewResponse.ItemsSource = response;
        }
        private async Task postCountry(string name)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var countryNew = new CountryCreate { Name = name };
            var response = await Manager.client.PostAsJsonAsync($"api/partworlds/{_idPartWorld}/countries", countryNew);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
            else
                MessageBox.Show("Элемент создан");
        }
        private async Task getCountry(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<Country>($"api/partworlds/{_idPartWorld}/countries/{id}");
            MessageBox.Show($"id: {response.id}\n name: {response.Name}");
        }
        private async Task deleteCountry(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.DeleteAsync($"api/partworlds/{_idPartWorld}/countries/{id}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
                getCountries();
            else
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
        }
        private async Task putCountry(string id, string nameNew)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var countryUpdate = new CountryUpdate { Name = nameNew };
            await Manager.client.PutAsJsonAsync($"api/partworlds/{_idPartWorld}/countries/{id}", countryUpdate);
            getCountries();
        }
    }
}
