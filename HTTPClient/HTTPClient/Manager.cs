using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HTTPClient
{
    public class Manager
    {
        public static Frame frameWindow { get; set; }
        public static HttpClient client = new HttpClient();
    }
}
