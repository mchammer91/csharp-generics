﻿namespace WiredBrainCoffee.StorageApp.Repositories;

public class GenericRepository<T, TKey>
{
    public TKey? Key { get; set; }
    protected readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Save()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item);
        }
    }
}