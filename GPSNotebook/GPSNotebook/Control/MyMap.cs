using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace GPSNotebook.Control
{
    class MyMap : Map
    {
        public static readonly BindableProperty MapSpanProperty =
        BindableProperty.Create(
            propertyName: nameof(MapSpan),
            returnType: typeof(MapSpan),
            declaringType: typeof(MapSpan),
            propertyChanged: MapSpanPropertyChanged);

        private static void MapSpanPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
              
            }
        }
        public MapSpan MapSpan
        {
            get => (MapSpan)GetValue(MapSpanProperty);
            set => SetValue(MapSpanProperty, value);
        }
    }
}
