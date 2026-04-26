using System;
using System.Collections.Generic;
using System.Linq;

namespace lab30vN;

public class ShoppingCart
{
    private readonly List<CartItem> _items = new();

    public void AddItem(string name, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty");

        if (price < 0)
            throw new ArgumentException("Price cannot be negative");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be > 0");

        _items.Add(new CartItem(name, price, quantity));
    }

    public bool RemoveItem(string name)
    {
        var item = _items.FirstOrDefault(i => i.Name == name);

        if (item == null)
            return false;

        _items.Remove(item);
        return true;
    }

    public decimal CalculateTotal()
    {
        return _items.Sum(i => i.Price * i.Quantity);
    }
}

public class CartItem
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public CartItem(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}