namespace SimpleBooksApi.API.Poco;

public class Book
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public bool available { get; set; }
}