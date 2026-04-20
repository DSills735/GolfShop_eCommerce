using Spectre.Console;

namespace Sills.GolfShop.eCommerceFrontEnd.Controllers;

internal class ProductsController
{
    internal void AddProduct()
    {
        Console.Clear();

        string ProductName = AnsiConsole.Ask<string>("Enter the name of the product:");
        string ProductDescription = AnsiConsole.Ask<string>("Enter the description of the product:");
        decimal ProductPrice = AnsiConsole.Ask<decimal>("Enter the price of the product:");
        int ProductQuantity = AnsiConsole.Ask<int>("Enter the quantity in stock for the product:");
        //Add category list to assign category to the product?? 


 


    }
}
