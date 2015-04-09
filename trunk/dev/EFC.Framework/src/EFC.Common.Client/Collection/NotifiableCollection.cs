﻿// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="NotifiableCollection.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="NotifiableCollection.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EFC.Client.Common.Collection
{
    /// <summary>
    /// NotifiableCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotifiableCollection<T> : ObservableCollection<T> where T : class, INotifyPropertyChanged
    {
        public event EventHandler<NotifyCollectionChangeEventArgs> ItemChanged;

        protected override void ClearItems()
        {
            foreach (var item in this.Items)
            {
                item.PropertyChanged -= ItemPropertyChanged;
            }
            base.ClearItems();
        }

        protected override void SetItem(int index, T item)
        {
            this.Items[index].PropertyChanged -= ItemPropertyChanged;
            base.SetItem(index, item);
            this.Items[index].PropertyChanged += ItemPropertyChanged;
        }

        protected override void RemoveItem(int index)
        {
            this.Items[index].PropertyChanged -= ItemPropertyChanged;
            base.RemoveItem(index);
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += ItemPropertyChanged;
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            T changedItem = sender as T;
            OnItemChanged(this.IndexOf(changedItem), e.PropertyName);
        }

        private void OnItemChanged(int index, string propertyName)
        {
            if (ItemChanged != null)
            {
                this.ItemChanged(this, new NotifyCollectionChangeEventArgs(index, propertyName));

            }
        }
    }

    /// <summary>
    /// NotifyCollectionChangeEventArgs.
    /// </summary>
    public class NotifyCollectionChangeEventArgs : PropertyChangedEventArgs
    {
        public int Index { get; set; }

        public NotifyCollectionChangeEventArgs(int index, string propertyName)
            : base(propertyName)
        {
            Index = index;
        }
    }
}
