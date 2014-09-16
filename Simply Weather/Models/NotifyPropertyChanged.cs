﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimplyWeather.Models
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null) where T : class
        {
            if (item != null && item.Equals(value)) return;
            item = value;
            OnPropertyChanged(propertyName);
        }

        protected void SetPropertyValue<T>(ref T item, T value, [CallerMemberName] string propertyName = null) where T : struct
        {
            if (item.Equals(value)) return;
            item = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}