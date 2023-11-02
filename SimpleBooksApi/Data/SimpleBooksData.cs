using SimpleBooksApi.API.Poco;

namespace SimpleBooksApi.Data;

public class SimpleBooksData
{

    public List<Book> GetListOfBooks()
    {
        return new List<Book>
        {
            new Book { id = 1, name = "The Russian", type = "fiction", available = true },
            new Book { id = 2, name = "Just as I Am", type = "non-fiction", available = false },
            new Book { id = 3, name = "The Vanishing Half", type = "fiction", available = true },
            new Book { id = 4, name = "The Midnight Library", type = "fiction", available = true },
            new Book { id = 5, name = "Untamed", type = "fiction", available = true },
            new Book { id = 6, name = "Viscount Who Loved Me", type = "fiction", available = true }
        };
    }

    public int GetBookId()
    {
        return 1;
    }

    public Order GetNewOrder()
    {
        return new Order()
        {
            bookId = 1,
            customerName = "Steven James"
        };
    }

    public Client GetNewClient()
    {
        return new Client()
        {
            clientEmail = "spich78111@gmail.com",
            clientName = "Jason williams"
        };
    }
}