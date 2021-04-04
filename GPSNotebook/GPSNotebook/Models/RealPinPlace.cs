using Realms;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GPSNotebook.Models
{
    class RealPinPlace : RealmObject, IEnumerable
    {
       
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Address { get; set; }
        public string Icons { get; set; }
        public Position Position { get; set; }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Position : RealmObject
    {
        public Position() { }
        public Position(double Latitude, double Longitude)
        {
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    static class RealmPlaceExtentions
    {
        public static Pin ToBasePlace(this RealPinPlace Place)
        {
            Pin basePlace = new Pin
            {
                Address = Place.Address,
                Icons = Place.Icons,
                Id = Place.Id,
                Position = new Xamarin.Forms.Maps.Position
                (
                    Place.Position.Latitude,
                    Place.Position.Longitude
                ),
                Name = Place.Name
            };

            return basePlace;
        }
        public static RealPinPlace ToRealmPlace(this Pin basePlace)
        {
            RealPinPlace realmPlace = new RealPinPlace
            {
                Address = basePlace.Address,
                Icons = basePlace.Icons,
                Id = basePlace.Id,
                Name = basePlace.Name,
                Position = new Position
                (
                    basePlace.Position.Latitude,
                    basePlace.Position.Longitude
                ),
            };
            return realmPlace;
        }

        public static ObservableCollection<Pin> ToBasePlace(this ObservableCollection<RealPinPlace> realmPlace)
        {
            var BasePlace = new ObservableCollection<Pin>();

            foreach (RealPinPlace item in realmPlace)
            {
                BasePlace.Add(item.ToBasePlace());
            }

            return BasePlace;
        }
        public static ObservableCollection<RealPinPlace> ToRealmPlace(this ObservableCollection<Pin> BasePlace)
        {
            var RealmPlace = new ObservableCollection<RealPinPlace>();

            foreach (Pin item in BasePlace)
            {
                RealmPlace.Add(item.ToRealmPlace());
            }

            return RealmPlace;
        }

    }
}
