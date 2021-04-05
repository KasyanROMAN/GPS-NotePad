using GPSNotebook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GPSNotebook.Services.RepositoryMap
{
    interface IRepositoryMap
    {
        ObservableCollection<Pin> GetPlaces();
        void AddPlace(Pin place);
        void RemovePlace(string id);
        void EditPlace(Pin place);
    }
}
