using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
    }
}
using System;
using System.Collections.Generic;

// Product class
public class Product
{
    private string name;
    private int productId;
    private decimal price;
    private int quantity;

    public Product(string name, int productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal CalculateTotalCost()
    {
        return price * quantity;
    }

    public string GetName() => name;
    public int GetProductId() => productId;
}

// Address class
public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA() => country.Equals("USA", StringComparison.OrdinalIgnoreCase);

    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {state}\n{country}";
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA() => address.IsInUSA();

    public string GetName() => name;
    public Address GetAddress() => address;
}

// Order class
public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;
    private const decimal shippingCostUSA = 5.00m;
    private const decimal shippingCostInternational = 35.00m;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.CalculateTotalCost();
        }
        total += customer.IsInUSA() ? shippingCostUSA : shippingCostInternational;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

// Program entry point
public class Program
{
    public static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Widget", 101, 3.00m, 5);
        Product product2 = new Product("Gadget", 102, 10.00m, 2);
        Product product3 = new Product("Thingamajig", 103, 7.50m, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display results for Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: {order1.CalculateTotalPrice():C}\n");

        // Display results for Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: {order2.CalculateTotalPrice():C}");
    }
}
