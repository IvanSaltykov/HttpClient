using HTTPClient.Dialogs;
using HTTPClient.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        private string _idPartWorld;
        private string _idCountry;
        private string _idCity;
        private string _idHotel;
        public TicketPage(string idPartWorld, string idCountry, string idCity, string idHotel)
        {
            InitializeComponent();
            _idPartWorld = idPartWorld;
            _idCountry = idCountry;
            _idCity = idCity;
            _idHotel = idHotel;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            gridGetRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Collapsed;
            gridCheckRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Collapsed;
        }

        private void buttonGetCheckRequestTicket_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridGetRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
            getTickets();
        }

        private void buttonPostCheckRequestTicket_Click(object sender, RoutedEventArgs e)
        {
            gridCheckRequest.Visibility = Visibility.Collapsed;
            gridPostRequest.Visibility = Visibility.Visible;
            buttonBack.Visibility = Visibility.Visible;
        }

        private void buttonPostRequestTicket_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPricePostRequestTicket.Text != "" &&
                textBoxUserPostRequestTicket.Text != "" &&
                textBoxWeekPostRequestTicket.Text != "")
            {
                postTicket(int.Parse(textBoxWeekPostRequestTicket.Text), int.Parse(textBoxUserPostRequestTicket.Text), int.Parse(textBoxPricePostRequestTicket.Text));
                textBoxPricePostRequestTicket.Text = "";
                textBoxUserPostRequestTicket.Text = "";
                textBoxWeekPostRequestTicket.Text = "";
            }
        }
        private void buttonInformationItem_Click(object sender, RoutedEventArgs e)
        {
            var ticket = (sender as Button).DataContext as Ticket;
            getTicket(ticket.Id);
        }

        private void buttonEditItem_Click(object sender, RoutedEventArgs e)
        {
            var ticket = (sender as Button).DataContext as Ticket;
            var editDialog = new EditTicketDialog(ticket.Week.ToString(), ticket.User.ToString(), ticket.Price.ToString());
            editDialog.ShowDialog();
            if (editDialog.DialogResult == true)
            {
                putTicket(ticket.Id, int.Parse(editDialog.Week), int.Parse(editDialog.User), int.Parse(editDialog.Price));
            }
        }

        private void buttonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var ticket = (sender as Button).DataContext as Ticket;
            deleteTicket(ticket.Id);
        }
        private async Task getTickets()
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<List<Ticket>>($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels/{_idHotel}/tickets");
            listViewResponse.ItemsSource = response;
        }
        private async Task postTicket(int week, int user, int price)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var ticketNew = new TicketCreate { Week = week, User = user, Price = price };
            var response = await Manager.client.PostAsJsonAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels/{_idHotel}/tickets", ticketNew);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
            else
                MessageBox.Show("Элемент создан");
        }
        private async Task getTicket(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.GetFromJsonAsync<Ticket>($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels/{_idHotel}/tickets/{id}");
            MessageBox.Show($"id: {response.Id}\n week: {response.Week}\n user: {response.User}\n price: {response.Price}");
        }
        private async Task deleteTicket(string id)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var response = await Manager.client.DeleteAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels/{_idHotel}/tickets/{id}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
                getTickets();
            else
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
        }
        private async Task putTicket(string id, int week, int user, int price)
        {
            Manager.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.token);
            var ticketUpdate = new TicketUpdate { Week = week, User = user, Price = price };
            var response =  await Manager.client.PutAsJsonAsync($"api/partworlds/{_idPartWorld}/countries/{_idCountry}/cities/{_idCity}/hotels/{_idHotel}/tickets/{id}", ticketUpdate);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
                getTickets();
            else
                MessageBox.Show(response.IsSuccessStatusCode.ToString());
        }
    }
}
