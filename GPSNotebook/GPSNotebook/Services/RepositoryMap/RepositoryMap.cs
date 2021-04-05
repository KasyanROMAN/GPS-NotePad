using GPSNotebook.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GPSNotebook.Services.RepositoryMap
{
    class RepositoryMap : IRepositoryMap
    {
        public void AddPlace(Pin place)
        {
            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();

            _realm.Add(place.ToRealmPlace());

            _transaction.Commit();
            _transaction.Dispose();
        }

        public void EditPlace(Pin place)
        {
            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();

            _realm.Add(place.ToRealmPlace(), true);

            _transaction.Commit();
            _transaction.Dispose();
        }

        public ObservableCollection<Pin> GetPlaces()
        {
            Realm _realm = Realm.GetInstance();

            return new ObservableCollection<RealPinPlace>(_realm.All<RealPinPlace>()).ToBasePlace();
        }

        public void RemovePlace(string id)
        {
            Realm realm = Realm.GetInstance();
            var Item = realm.All<RealPinPlace>().First(u => u.PlaceId == id);

            using (var trans = realm.BeginWrite())
            {
                realm.Remove(Item);
                trans.Commit();
            }
        }
    }
}
