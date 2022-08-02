﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace Exercise15
{
    class Program
    {
        static void Main()
        {
            ObservableCollection<int> numbers = new ObservableCollection<int>();
            numbers.CollectionChanged += OnCollectionchanged;
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(100);
            numbers.RemoveAt(0); 
            Console.ReadKey();
        }


        private static void OnCollectionchanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                if (e.NewItems?[0] is int newnumber)
                    Console.WriteLine($"Element {newnumber} is added in collection");
            if (e.Action == NotifyCollectionChangedAction.Remove)
                if (e.OldItems?[0] is int oldnumber)
                    Console.WriteLine($"Element {oldnumber} is removed from collection");

        }
    }
}