using System;
using System.Collections.Generic;
using System.Text;

namespace GPSNotebook.Models
{
    class Pin
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Address { get; set; }
        public string Icons { get; set; }
        public Xamarin.Forms.Maps.Position Position { get; set; }
    }
}
