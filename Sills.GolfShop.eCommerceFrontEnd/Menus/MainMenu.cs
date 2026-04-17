using Spectre.Console;

namespace Sills.GolfShop.eCommerceFrontEnd.Menus;

internal static class MainMenu
{
    public static void MainDisplay()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Sills Golf Shop")
                    .LeftJustified()
                    .Color(Color.Green));

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What would you like to do?")
                    .AddChoices(new[] {
                    "View All Products",
                    "Choose a category",
                    "Cart",
                    "Checkout",
                    "View Order History",
                    "Exit"
                    }));


            switch (choice)
            {
                case "View All Products":
                    //ProductMenu.DisplayProducts();
                    break;
                case "Choose a category":
                    //CategoryMenu.DisplayCategories();
                    break;
                case "Cart":
                    //CartMenu.DisplayCart();
                    break;
                case "Checkout":
                    break;
                case "View Order History":
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}