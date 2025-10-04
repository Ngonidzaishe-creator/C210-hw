using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Online Ordering Program (Single File Version) ===\n");

        // ----------- ORDER 1: USA Customer -----------
        Address address1 = new Address("123 Main Street", "Los Angeles", "CA", "USA");
        Customer customer1 = new Customer("Ngoni Chareka", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.50, 2));

        // ----------- ORDER 2: International Customer -----------
        Address address2 = new Address("45 First Avenue", "Bulawayo", "Matabeleland", "Zimbabwe");
        Customer customer2 = new Customer("Tariro Moyo", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P003", 500.00, 1));
        order2.AddProduct(new Product("Charger", "P004", 20.00, 2));
        order2.AddProduct(new Product("Headphones", "P005", 75.00, 1));

        // ----------- ORDER 3: Another USA Customer -----------
        Address address3 = new Address("789 Elm Street", "New York", "NY", "USA");
        Customer customer3 = new Customer("Alice Smith", address3);
        Order order3 = new Order(customer3);
        order3.AddProduct(new Product("Desk Chair", "P006", 150.00, 1));
        order3.AddProduct(new Product("Monitor", "P007", 200.00, 2));

        // Display all orders
        order1.DisplayOrder();
        order2.DisplayOrder();
        order3.DisplayOrder();

        Console.WriteLine("Program completed successfully.");
    }
}

// -------------------- Address Class --------------------
class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

// -------------------- Product Class --------------------
class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"{_name} (ID: {_productId})";
    }
}

// -------------------- Customer Class --------------------
class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}

// -------------------- Order Class --------------------
class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.0 : 35.0;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $" - {product.GetPackingLabel()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }

    public void DisplayOrder()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(GetShippingLabel());

        Console.WriteLine($"\nTotal Price: ${GetTotalPrice():0.00}");
        Console.WriteLine("--------------------------------------------------\n");
    }
}
