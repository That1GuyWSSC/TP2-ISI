using ClienteBasico;
using ClienteBasico.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;


class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var categoryApiClient = new CategoryApiClient(httpClient);
        var productApiClient = new ProductApiClient(httpClient);
        var currencyApiClient = new CurrencyApiClient(httpClient);

        ClienteBasico.UserService.ServiceClient ws = new ClienteBasico.UserService.ServiceClient();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Category Management");
            Console.WriteLine("2. Product Management");
            Console.WriteLine("3. Currency Management");
            Console.WriteLine("4. User Management");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            var mainChoice = Console.ReadLine();

            switch (mainChoice)
            {
                case "1":
                    await CategoryMenu(categoryApiClient);
                    break;
                case "2":
                    await ProductMenu(productApiClient);
                    break;
                case "3":
                    await GetAllCurrencies(currencyApiClient);
                    break;
                case "4":
                    UserManagement(ws);
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }

    private static async Task CategoryMenu(CategoryApiClient apiClient)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Category Management Menu ===");
            Console.WriteLine("1. View All Categories");
            Console.WriteLine("2. View Category by ID");
            Console.WriteLine("3. Create a New Category");
            Console.WriteLine("4. Update an Existing Category");
            Console.WriteLine("5. Delete a Category");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ViewAllCategories(apiClient);
                    break;
                case "2":
                    await ViewCategoryById(apiClient);
                    break;
                case "3":
                    await CreateCategory(apiClient);
                    break;
                case "4":
                    await UpdateCategory(apiClient);
                    break;
                case "5":
                    await DeleteCategory(apiClient);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the Category Management menu...");
            Console.ReadKey();
        }
    }

    private static async Task ProductMenu(ProductApiClient apiClient)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Product Management Menu ===");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. View Product by ID");
            Console.WriteLine("3. Create a New Product");
            Console.WriteLine("4. Update an Existing Product");
            Console.WriteLine("5. Delete a Product");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ViewAllProducts(apiClient);
                    break;
                case "2":
                    await ViewProductById(apiClient);
                    break;
                case "3":
                    await CreateProduct(apiClient);
                    break;
                case "4":
                    await UpdateProduct(apiClient);
                    break;
                case "5":
                    await DeleteProduct(apiClient);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the Product Management menu...");
            Console.ReadKey();
        }
    }

    private static async Task GetAllCurrencies(CurrencyApiClient apiClient)
    {
        Console.WriteLine("\n=== View All Currencies ===");
        var currencies = await apiClient.GetCurrenciesAsync();
        foreach (var currency in currencies)
        {
            Console.WriteLine($"AUD: {currency.Data.AUD}, BGN: {currency.Data.BGN}, BRL: {currency.Data.BRL}, CAD: {currency.Data.CAD}, " +
                $"CHF: {currency.Data.CHF}, CNY: {currency.Data.CNY}, CZK: {currency.Data.CZK}, DKK: {currency.Data.DKK}, EUR: {currency.Data.EUR}, " +
                $"GBP: {currency.Data.GBP}, HKD: {currency.Data.HKD}, HRK: {currency.Data.HRK}, HUF: {currency.Data.HUF}, IDR: {currency.Data.IDR}, " +
                $"ILS: {currency.Data.ILS}, INR: {currency.Data.INR}, ISK: {currency.Data.ISK}, JPY: {currency.Data.JPY}, KRW: {currency.Data.KRW}, " +
                $"MXN: {currency.Data.MXN}, MYR: {currency.Data.MYR}, NOK: {currency.Data.NOK}, NZD: {currency.Data.NZD}, PHP: {currency.Data.PHP}, " +
                $"PLN: {currency.Data.PLN}, RON: {currency.Data.RON}, RUB: {currency.Data.RUB}, SEK: {currency.Data.SEK}, SGD: {currency.Data.SGD}, " +
                $"THB: {currency.Data.THB}, TRY: {currency.Data.TRY}, USD: {currency.Data.USD}, ZAR: {currency.Data.ZAR}");
        }
    }

    private static void UserManagement(ClienteBasico.UserService.ServiceClient ws)
    {
        Console.WriteLine("\n=== User Management ===");
        var users = ws.getUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.id}, Name: {user.username}, Role: {user.role}");
        }
    }

    // Category management helper methods
    private static async Task ViewAllCategories(CategoryApiClient apiClient)
    {
        Console.WriteLine("\n=== View All Categories ===");
        var categories = await apiClient.GetCategoriesAsync();
        foreach (var category in categories)
        {
            Console.WriteLine($"ID: {category.Id}, Name: {category.Name}, Description: {category.Description}");
        }
    }

    private static async Task ViewCategoryById(CategoryApiClient apiClient)
    {
        Console.Write("\nEnter the Category ID: ");
        if (long.TryParse(Console.ReadLine(), out var id))
        {
            var category = await apiClient.GetCategoryByIdAsync(id);
            if (category != null)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}, Description: {category.Description}");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    private static async Task CreateCategory(CategoryApiClient apiClient)
    {
        Console.Write("\nEnter the Category Name: ");
        var name = Console.ReadLine();
        Console.Write("Enter the Category Description (optional): ");
        var description = Console.ReadLine();

        var newCategory = new Category
        {
            Name = name,
            Description = string.IsNullOrWhiteSpace(description) ? null : description
        };

        var createdCategory = await apiClient.CreateCategoryAsync(newCategory);
        Console.WriteLine($"Created Category: ID = {createdCategory.Id}, Name = {createdCategory.Name}");
    }

    private static async Task UpdateCategory(CategoryApiClient apiClient)
    {
        Console.Write("\nEnter the Category ID to Update: ");
        if (long.TryParse(Console.ReadLine(), out var id))
        {
            var category = await apiClient.GetCategoryByIdAsync(id);
            if (category != null)
            {
                Console.Write($"Current Name ({category.Name}): ");
                var name = Console.ReadLine();
                Console.Write($"Current Description ({category.Description}): ");
                var description = Console.ReadLine();

                category.Name = string.IsNullOrWhiteSpace(name) ? category.Name : name;
                category.Description = string.IsNullOrWhiteSpace(description) ? category.Description : description;

                var success = await apiClient.UpdateCategoryAsync(id, category);
                Console.WriteLine(success ? "Category updated successfully." : "Failed to update the category.");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    private static async Task DeleteCategory(CategoryApiClient apiClient)
    {
        Console.Write("\nEnter the Category ID to Delete: ");
        if (long.TryParse(Console.ReadLine(), out var id))
        {
            var success = await apiClient.DeleteCategoryAsync(id);
            Console.WriteLine(success ? "Category deleted successfully." : "Failed to delete the category.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    // Product management helper methods
    private static async Task ViewAllProducts(ProductApiClient apiClient)
    {
        Console.WriteLine("\n=== View All Products ===");
        var products = await apiClient.GetProductsAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category ID: {product.Category_Id}");
        }
    }

    private static async Task ViewProductById(ProductApiClient apiClient)
    {
        Console.Write("\nEnter the Product ID: ");
        if (long.TryParse(Console.ReadLine(), out var id))
        {
            var product = await apiClient.GetProductByIdAsync(id);
            if (product != null)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    private static async Task CreateProduct(ProductApiClient apiClient)
    {
        Console.Write("\nEnter the Product Name: ");
        var name = Console.ReadLine();
        Console.Write("Enter the Product Description: ");
        var description = Console.ReadLine();
        Console.Write("Enter the Product Price: ");
        if (!double.TryParse(Console.ReadLine(), out var price))
        {
            Console.WriteLine("Invalid price format.");
            return;
        }
        Console.Write("Enter the Category ID: ");
        if (!long.TryParse(Console.ReadLine(), out var categoryId))
        {
            Console.WriteLine("Invalid category ID format.");
            return;
        }

        var newProduct = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Category_Id = categoryId
        };

        var createdProduct = await apiClient.CreateProductAsync(newProduct);
        Console.WriteLine($"Created Product: ID = {createdProduct.Id}, Name = {createdProduct.Name}");
    }

    private static async Task UpdateProduct(ProductApiClient apiClient)
    {
        Console.Write("\nEnter the Product ID to Update: ");
        if (long.TryParse(Console.ReadLine(), out var id))
        {
            var product = await apiClient.GetProductByIdAsync(id);
            if (product != null)
            {
                Console.Write($"Current Name ({product.Name}): ");
                var name = Console.ReadLine();
                Console.Write($"Current Description ({product.Description}): ");
                var description = Console.ReadLine();
                Console.Write($"Current Price ({product.Price}): ");
                if (!double.TryParse(Console.ReadLine(), out var price))
                {
                    Console.WriteLine("Invalid price format.");
                    return;
                }

                Console.Write($"Current Category ID ({product.Category_Id}): ");
                if (!long.TryParse(Console.ReadLine(), out var categoryId))
                {
                    Console.WriteLine("Invalid category ID format.");
                    return;
                }

                product.Name = string.IsNullOrWhiteSpace(name) ? product.Name : name;
                product.Description = string.IsNullOrWhiteSpace(description) ? product.Description : description;
                product.Price = price == 0 ? product.Price : price;
                product.Category_Id = categoryId == 0 ? product.Category_Id : categoryId;

                var success = await apiClient.UpdateProductAsync(id, product);
                Console.WriteLine(success ? "Product updated successfully." : "Failed to update the product.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    private static async Task DeleteProduct(ProductApiClient apiClient)
    {
        Console.Write("\nEnter the Product ID to Delete: ");
        if (long.TryParse(Console.ReadLine(), out var id))
        {
            var success = await apiClient.DeleteProductAsync(id);
            Console.WriteLine(success ? "Product deleted successfully." : "Failed to delete the product.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}
