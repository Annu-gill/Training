using System;

// Custom Exception (Optional Challenge)
public class InvalidBookDataException : Exception
{
    public InvalidBookDataException(string message) : base(message) { }
}

// Book Class
public class Book
{
    public string Id { get; set; }
    public string Title { get; set; }

    private int price;
    public int Price
    {
        get { return price; }
        set
        {
            if (value < 0)
                throw new InvalidBookDataException("Price cannot be negative");
            price = value;
        }
    }

    private int stock;
    public int Stock
    {
        get { return stock; }
        set
        {
            if (value < 0)
                throw new InvalidBookDataException("Stock cannot be negative");
            stock = value;
        }
    }
}

// BookUtility Class
public class BookUtility
{
    private Book book;

    public BookUtility(Book book)
    {
        this.book = book;
    }

    // Display book details
    public void GetBookDetails()
    {
        Console.WriteLine($"Details: {book.Id} {book.Title} {book.Price} {book.Stock}");
    }

    // Update price
    public void UpdateBookPrice(int newPrice)
    {
        book.Price = newPrice;
        Console.WriteLine($"Updated Price: {newPrice}");
    }

    // Update stock
    public void UpdateBookStock(int newStock)
    {
        book.Stock = newStock;
        Console.WriteLine($"Updated Stock: {newStock}");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        try
        {
            // Initial input
            string[] input = Console.ReadLine().Split(' ');

            Book book = new Book
            {
                Id = input[0],
                Title = input[1],
                Price = int.Parse(input[2]),
                Stock = int.Parse(input[3])
            };

            BookUtility utility = new BookUtility(book);

            while (true)
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        int newPrice = int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(newPrice);
                        break;

                    case 3:
                        int newStock = int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(newStock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        catch (InvalidBookDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

