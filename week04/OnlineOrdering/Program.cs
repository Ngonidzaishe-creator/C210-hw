using System;
using System.Collections.Generic;

public class Product
{
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"{_name} (ID: {_id})";
    }

    public override string ToString()
    {
        return $"{_name} (ID: {_id}) - ${_price} x {_quantity} = ${GetTotalCost()}";
    }
}

public class Customer
{
    private string _name;
    private string _address;
    private string _city;
    private string _state;
    private string _country;

    public Customer(string name, string address, string city, string state, string country)
    {
        _name = name;
        _address = address;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool LivesInUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states";
    }

    public string GetAddressLabel()
    {
        return $"{_name}\n{_address}\n{_city}, {_state}\n{_country}";
    }
}

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double productTotal = 0;
        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.0 : 35.0;
        return productTotal + shippingCost;
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("PACKING LABEL:");
        foreach (Product product in _products)
        {
            Console.WriteLine($" - {product.GetPackingLabel()}");
        }

        Console.WriteLine("\nSHIPPING LABEL:");
        Console.WriteLine(_customer.GetAddressLabel());

        Console.WriteLine($"\nTotal Price: ${GetTotalCost():0.00}");
        Console.WriteLine("--------------------------------------------------\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Online Ordering System ===\n");

        // First order (Customer in USA)
        Customer customer1 = new Customer("Ngoni Chareka", "123 Main Street", "Harare", "CA", "USA");
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 999.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P002", 25.50, 2));
        order1.AddProduct(new Product("USB-C Cable", "P003", 9.99, 3));

        // Second order (Customer outside USA)
        Customer customer2 = new Customer("Tariro Moyo", "45 First Avenue", "Bulawayo", "Mat", "Zimbabwe");
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P004", 500.00, 1));
        order2.AddProduct(new Product("Charger", "P005", 20.00, 2));

        // Third order (Extra for creativity)
        Customer customer3 = new Customer("Alice Banda", "7 Sunshine Road", "Lusaka", "Central", "Zambia");
        Order order3 = new Order(customer3);
        order3.AddProduct(new Product("Tablet", "P006", 350.00, 1));
        order3.AddProduct(new Product("Screen Protector", "P007", 15.00, 2));
        order3.AddProduct(new Product("Stylus Pen", "P008", 18.50, 1));

        // Display all orders
        order1.DisplayOrderDetails();
        order2.DisplayOrderDetails();
        order3.DisplayOrderDetails();

        Console.WriteLine("Program completed successfully.\n");
    }
}
