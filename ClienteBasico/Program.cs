using ClienteBasico;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using testebasic.Models;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var apiClient = new CategoryApiClient(httpClient);
        var CurrencyClient = new CurrencyApiClient(httpClient);


        ClienteBasico.UserService.ServiceClient ws = new ClienteBasico.UserService.ServiceClient();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Category Management Menu ===");
            Console.WriteLine("1. View All Categories");
            Console.WriteLine("2. View Category by ID");
            Console.WriteLine("3. Create a New Category");
            Console.WriteLine("4. Update an Existing Category");
            Console.WriteLine("5. Delete a Category");
            Console.WriteLine("6. View All Curriencies");
            Console.WriteLine("7. Get All Users");
            Console.WriteLine("8. Exit");
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
                    await GetAllCurrencies(CurrencyClient);
                    break;
                case "7":
                    var users = ws.getUsers();
                    foreach (var user in users)
                    {
                       Console.WriteLine($"ID: {user.id}, Name: {user.username}, Role: {user.role}");
                    }
                    break;
                case "8":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }

    private static async Task GetAllCurrencies(CurrencyApiClient apiClient)
    {
        Console.WriteLine("\n=== View All Currencies ===");
        var currencies = await apiClient.GetCurrenciesAsync();
        foreach (var currency in currencies)
        {
            Console.WriteLine($"AUD: {currency.Data.AUD}, BGN: {currency.Data.BGN}, BRL: {currency.Data.BRL}, CAD: {currency.Data.CAD}, CHF: {currency.Data.CHF}, CNY: {currency.Data.CNY}, CZK: {currency.Data.CZK}, DKK: {currency.Data.DKK}, EUR: {currency.Data.EUR}, GBP: {currency.Data.GBP}, HKD: {currency.Data.HKD}, HRK: {currency.Data.HRK}, HUF: {currency.Data.HUF}, IDR: {currency.Data.IDR}, ILS: {currency.Data.ILS}, INR: {currency.Data.INR}, ISK: {currency.Data.ISK}, JPY: {currency.Data.JPY}, KRW: {currency.Data.KRW}, MXN: {currency.Data.MXN}, MYR: {currency.Data.MYR}, NOK: {currency.Data.NOK}, NZD: {currency.Data.NZD}, PHP: {currency.Data.PHP}, PLN: {currency.Data.PLN}, RON: {currency.Data.RON}, RUB: {currency.Data.RUB}, SEK: {currency.Data.SEK}, SGD: {currency.Data.SGD}, THB: {currency.Data.THB}, TRY: {currency.Data.TRY}, USD: {currency.Data.USD}, ZAR: {currency.Data.ZAR}");
        }
    }


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
        Console.WriteLine($"Created Category: ID = {createdCategory.Id}, Name = {createdCategory.Name}, Description = {createdCategory.Description}");
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
            Console.WriteLine(success ? "Category deleted successfully." : "Failed to delete the category or category not found.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}
