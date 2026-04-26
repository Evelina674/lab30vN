using lab30vN;

namespace lab30vN.Tests;

public class ShoppingCartTests
{
    [Fact]
    public void AddItem_ShouldAddCorrectly()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Milk", 3m, 2);

        Assert.Equal(6m, cart.CalculateTotal());
    }

    [Fact]
    public void EmptyCart_TotalIsZero()
    {
        var cart = new ShoppingCart();

        Assert.Equal(0m, cart.CalculateTotal());
    }

    [Fact]
    public void AddItem_InvalidName_Throws()
    {
        var cart = new ShoppingCart();

        Assert.Throws<ArgumentException>(() => cart.AddItem("", 5, 1));
    }

    [Fact]
    public void AddItem_NegativePrice_Throws()
    {
        var cart = new ShoppingCart();

        Assert.Throws<ArgumentException>(() => cart.AddItem("Test", -1, 1));
    }

    [Fact]
    public void AddItem_ZeroQuantity_Throws()
    {
        var cart = new ShoppingCart();

        Assert.Throws<ArgumentException>(() => cart.AddItem("Test", 5, 0));
    }

    [Theory]
    [InlineData(2, 5, 10)]
    [InlineData(3, 3, 9)]
    [InlineData(10, 1, 10)]
    public void CalculateTotal_WithDifferentValues(int qty, decimal price, decimal expected)
    {
        var cart = new ShoppingCart();

        cart.AddItem("Item", price, qty);

        Assert.Equal(expected, cart.CalculateTotal());
    }

    [Fact]
    public void RemoveItem_ShouldRemove()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Milk", 5, 1);

        var result = cart.RemoveItem("Milk");

        Assert.True(result);
        Assert.Equal(0, cart.CalculateTotal());
    }

    [Fact]
    public void RemoveItem_NotExists_ReturnFalse()
    {
        var cart = new ShoppingCart();

        Assert.False(cart.RemoveItem("Nope"));
    }

    [Fact]
    public void MultipleItems_TotalCorrect()
    {
        var cart = new ShoppingCart();

        cart.AddItem("A", 2, 3);
        cart.AddItem("B", 4, 2);

        Assert.Equal(14, cart.CalculateTotal());
    }

    [Fact]
    public void RemoveOneItem_OthersStay()
    {
        var cart = new ShoppingCart();

        cart.AddItem("A", 2, 3);
        cart.AddItem("B", 4, 2);

        cart.RemoveItem("A");

        Assert.Equal(8, cart.CalculateTotal());
    }
}