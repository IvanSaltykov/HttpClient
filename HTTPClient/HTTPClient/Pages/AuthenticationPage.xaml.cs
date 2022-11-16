using HTTPClient.Model;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Net.Http;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace HTTPClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationPage.xaml
    /// </summary>
    public partial class AuthenticationPage : Page
    { 
        public AuthenticationPage()
        {
            InitializeComponent();
        }

        private void buttonAuthentication_Click(object sender, RoutedEventArgs e)
        {
            RunAsync(textBoxLogin.Text, textBoxPassword.Text);
        }

        static async Task RunAsync(string userName, string password)
        {
            Manager.client.BaseAddress = new Uri("http://localhost:5000/");
            Manager.client.DefaultRequestHeaders.Accept.Clear();
            Manager.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var userLogin = new UserLogin { UserName = userName, Password = password };
                await LoginUserAsync(userLogin);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                throw;
            }
        }
        static async Task LoginUserAsync(UserLogin userLogin)
        {
            var response = await Manager.client.PostAsJsonAsync("api/authentication/login", userLogin);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                Token.token = response.Content.ReadAsAsync<TokenModel>().Result.token;
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(Token.token);
                Token.userId = securityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                Manager.frameWindow.Navigate(new PartWorldPage());
            }
        }
    }
}
