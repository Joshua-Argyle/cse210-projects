namespace Week08Demo_Products;

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = CreateProducts();

        Console.Clear();
        bool running = true;
        while (running)
        {

            Console.WriteLine("\n=== Product Search System ===");
            Console.WriteLine("1. Search by Product ID");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Search by Description");
            Console.WriteLine("4. Display All Products");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SearchById(products);
                    PauseAndClear();
                    break;
                case "2":
                    SearchByName(products);
                    PauseAndClear();
                    break;
                case "3":
                    SearchByDescription(products);
                    PauseAndClear();
                    break;
                case "4":
                    DisplayAllProducts(products);
                    PauseAndClear();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }
    }

    static List<Product> CreateProducts()
    {
        List<Product> products = new List<Product>();

        // Create 5 Books
        products.Add(new Book(1, "The Pragmatic Programmer", 39.99m, 12,
            "A classic guide to software craftsmanship.",
            "Andrew Hunt & David Thomas", "Addison-Wesley", "1999-10-30", 352));

        products.Add(new Book(2, "Clean Code", 42.50m, 8,
            "A handbook of agile software craftsmanship.",
            "Robert C. Martin", "Prentice Hall", "2008-08-01", 464));

        products.Add(new Book(3, "Design Patterns", 54.99m, 5,
            "Elements of reusable object-oriented software.",
            "Gang of Four", "Addison-Wesley", "1994-10-21", 395));

        products.Add(new Book(4, "Introduction to Algorithms", 89.99m, 15,
            "Comprehensive textbook on computer algorithms.",
            "Thomas H. Cormen", "MIT Press", "2009-07-31", 1312));

        products.Add(new Book(5, "Code Complete", 49.99m, 10,
            "A practical handbook of software construction.",
            "Steve McConnell", "Microsoft Press", "2004-06-19", 960));

        // Create 5 Electronics
        products.Add(new Electronics(6, "Laptop XPS 13", 899.99m, 5,
            "Lightweight laptop with 16GB RAM and 512GB SSD.",
            "Dell", "XPS 13", "24 months"));

        products.Add(new Electronics(7, "Wireless Mouse", 29.99m, 50,
            "Ergonomic wireless mouse with USB receiver.",
            "Logitech", "MX Master 3", "12 months"));

        products.Add(new Electronics(8, "Mechanical Keyboard", 149.99m, 20,
            "RGB mechanical gaming keyboard with blue switches.",
            "Corsair", "K95 RGB", "24 months"));

        products.Add(new Electronics(9, "USB-C Hub", 49.99m, 30,
            "Multi-port USB-C hub with HDMI and SD card reader.",
            "Anker", "PowerExpand 8-in-1", "18 months"));

        products.Add(new Electronics(10, "Noise Cancelling Headphones", 299.99m, 12,
            "Premium wireless headphones with active noise cancellation.",
            "Sony", "WH-1000XM5", "12 months"));

        products.Add(new Food(10, "Pringles", 1.99m, 98, "Crisp potatoe chips.", "10/2026", 310));

        products.Add(new Food(11, "Big Mac", 4.99m, 29, "Fattening burger made with love and grease.", "03/2026", 520));
        
        return products;
    }

    static void SearchById(List<Product> products)
    {
        Console.Write("\nEnter Product ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            List<Product> results = new List<Product>();
            foreach (Product product in products)
            {
                if (product.GetInfo().Contains($"Product ID: {id}"))
                {
                    results.Add(product);
                }
            }

            DisplayResults(results);
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    static void SearchByName(List<Product> products)
    {
        Console.Write("\nEnter name to search: ");
        string searchTerm = Console.ReadLine().ToLower();

        List<Product> results = new List<Product>();
        foreach (Product product in products)
        {
            if (product.GetInfo().ToLower().Contains($"name: {searchTerm}") ||
                product.GetInfo().ToLower().Contains(searchTerm))
            {
                results.Add(product);
            }
        }

        DisplayResults(results);
    }

    static void SearchByDescription(List<Product> products)
    {
        Console.Write("\nEnter description keyword to search: ");
        string searchTerm = Console.ReadLine().ToLower();

        List<Product> results = new List<Product>();
        foreach (Product product in products)
        {
            string info = product.GetInfo().ToLower();
            if (info.Contains($"description: {searchTerm}") ||
                (info.Contains("description:") && info.Contains(searchTerm)))
            {
                results.Add(product);
            }
        }

        DisplayResults(results);
    }

    static void DisplayAllProducts(List<Product> products)
    {
        Console.WriteLine("\n=== All Products ===");
        foreach (Product product in products)
        {
            Console.WriteLine($"[{product.GetType().Name}]");
            Console.WriteLine(product.GetInfo());
            Console.WriteLine(new string('-', 50));
        }
        Console.WriteLine($"Total products: {products.Count}");
    }

    static void DisplayResults(List<Product> results)
    {
        if (results.Count == 0)
        {
            Console.WriteLine("\nNo products found.");
        }
        else
        {
            Console.WriteLine($"\n=== Found {results.Count} Product(s) ===");
            foreach (Product product in results)
            {
                Console.WriteLine($"[{product.GetType().Name}]");
                Console.WriteLine(product.GetInfo());
                Console.WriteLine(new string('-', 50));
            }
        }
    }

    static void PauseAndClear()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}
