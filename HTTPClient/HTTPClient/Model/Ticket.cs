using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.Model
{
    public class Ticket
    {
        public string Id { get; set; }
        public string World { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public int Week { get; set; }
        public int User { get; set; }
        public int Price { get; set; }
    }
}
