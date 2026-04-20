using Sills.GolfShop.eCommerceFrontEnd.Models;
using Sills.GolfShop.eCommerceFrontEnd.Services;
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


        Product product = new Product
        {
            Name = ProductName,
            Description = ProductDescription,
            Price = ProductPrice,
            QuantityInStock = ProductQuantity
        };

        //TODO call product service to finalize addition

        await ProductService.AddProduct(product);


    }
}
