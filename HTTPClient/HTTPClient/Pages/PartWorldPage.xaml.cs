using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Net.Http.Headers;
using System.Net.Http.Json;
using HTTPClient.Model;
using System.Security.Policy;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace HTTPClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для PartWorldPage.xaml
    /// </summary>
    public partial class PartWorldPage : Page
    {
        public PartWorldPage()
        {
            InitializeComponent();
        }
        private void buttonPostCheckRequestPartWorld_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
        }

        private void buttonGetCheckRequestPartWorld_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridGetRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
            getPartWorlds();
        }
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            gridGetRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Collapsed;
            gridCheckRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Collapsed;
        }
        private void buttonPostRequestPartWorld_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPostRequestPartWorld.Text != "")
            {
                postPartWorld(textBoxPostRequestPartWorld.Text);
                textBoxPostRequestPartWorld.Text = "";
            }
        }
        private void listViewResponse_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as PartWorld;
            if (item != null)
            {
                Manager.frameWindow.Navigate(new CountryPage(item.id));
            }
        }
        private void buttonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var partWorld = (sender as Button).DataContext as PartWorld;
            deletePartWorld(partWorld.id);
        }

        private void buttonInformationItem_Click(object sender, RoutedEventArgs e)
        {
            var partWorld = (sender as Button).DataContext as PartWorld;
            getIdPartWorld(partWorld.id);
        }
        private void buttonEditItem_Click(object sender, RoutedEventArgs e)
        {
            var partWorld = (sender as Button).DataContext as PartWorld;
            string input = Interaction.InputBox($"id: {partWorld.id}\n name: {partWorld.Name}", "Изменить?", "", 10, 10);
            if (input != "")
                putPartWorld(partWorld.id, input);
        }
        private async Task getPartWorlds()
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<List<Model.PartWorld>>("api/partworlds");
            listViewResponse.ItemsSource = response;
        }
        private async Task postPartWorld(string name)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var partWorldNew = new PartWorldCreate { Name = name };
            var response = await Manager.client.PostAsJsonAsync("api/partworlds", partWorldNew);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
            else
                MessageBox.Show("Элемент создан");
        }
        private async Task getIdPartWorld(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<PartWorld>($"api/partworlds/{id}");
            MessageBox.Show($"id: {response.id}\n name: {response.Name}");
        }
        private async Task deletePartWorld(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.DeleteAsync($"api/partworlds/{id}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
                getPartWorlds();
            else
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
        }
        private async Task putPartWorld(string id, string nameNew)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var partWorldUpdate = new PartWorldUpdate { Name = nameNew };
            await Manager.client.PutAsJsonAsync($"api/partworlds/{id}", partWorldUpdate);
            getPartWorlds();
        }
    }
}
