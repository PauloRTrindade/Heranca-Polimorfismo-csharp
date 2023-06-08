using HerançaPolimorfismo.Entities;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {

        List<Product> list = new List<Product>();

        Console.Write("Enter the number of products: ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine($"Product #{i} data:");
            Console.Write("Common, used or imported (c/u/i)? ");
            char Type = char.Parse(Console.ReadLine());

            while (Type != 'c' && Type != 'i' && Type != 'u')
            {
                Console.Write("Product does not exist, type again (c/u/i): ");
                Type = char.Parse(Console.ReadLine());
            }

            if (Type == 'c')
            {
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Price: ");
                double Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                list.Add(new(Name, Price));
            }
            else if (Type == 'i')
            {

                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Price: ");
                double Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Customs fee: ");
                double CustomsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                list.Add(new ImportedProduct(Name, Price, CustomsFee));
            }
            else
            {

                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Price: ");
                double Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Manufacture date (DD/MM/YYYY): ");
                DateTime ManufactureDate = DateTime.Parse(Console.ReadLine());

                list.Add(new UsedProduct(Name, Price, ManufactureDate));
            }
        }
        Console.WriteLine();
        Console.WriteLine("PRICE TAG(S):");
        foreach (Product product in list)
        {
            Console.WriteLine(product.PriceTag());
        }
    }
}