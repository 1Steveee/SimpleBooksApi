using System.Net;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json;
using RestSharp;
using SimpleBooksApi.API;
using SimpleBooksApi.API.Poco;
using SimpleBooksApi.Data;
using SimpleBooksApi.Utils;

namespace SimpleBooksApi;

public class Tests
{
    private readonly SimpleBookApi _simpleBookApi = new();
    private readonly Deserializer<Book> _deserializer = new ();
    private readonly SimpleBooksData _simpleBooksData = new();
    private AccessToken _accessToken = new();

    [Test]
    public void TestGetApiStatus()
    {
        RestResponse response = _simpleBookApi.GetApiStatus();

        ApiStatus apiStatus = JsonConvert.DeserializeObject<ApiStatus>(response.Content);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(apiStatus.status, Is.EqualTo("OK"));
    }
    

    [Test]
    public void TestGetAllBooks()
    {
        List<Book> expectedListOfBooks = _simpleBooksData.GetListOfBooks();
        
        RestResponse response = _simpleBookApi.GetAllBooks();

        List<Book> actualListOfBooks = _deserializer.DeserializeList(response.Content);
        
        //List<Book> actualListOfBooks = new List<Book>(JsonConvert.DeserializeObject<List<Book>>(response.Content));
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(actualListOfBooks.Count, Is.EqualTo(6));
        Assert.That(actualListOfBooks[0].id, Is.EqualTo(expectedListOfBooks[0].id));
        Assert.That(actualListOfBooks[0].name, Is.EqualTo(expectedListOfBooks[0].name));
        Assert.That(actualListOfBooks[0].type, Is.EqualTo(expectedListOfBooks[0].type));
        Assert.That(actualListOfBooks[0].available, Is.EqualTo(expectedListOfBooks[0].available));
    }

    [Test]
    public void TestGetTypeFiction()
    {
        RestResponse response = _simpleBookApi.GetBookType(BookType.Fiction);

        List<Book> actualListofFictionBooks = _deserializer.DeserializeList(response.Content);
        
        //List<Book> actualListOfFictionBooks = new List<Book>(JsonConvert.DeserializeObject<List<Book>>(response.Content));
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(actualListofFictionBooks.Count, Is.EqualTo(4));
        Assert.True(actualListofFictionBooks.TrueForAll(book => book.type == BookType.Fiction));
    }

    [Test]
    public void TestGetBook()
    {
        int bookId = _simpleBooksData.GetBookId();
        
        RestResponse response = _simpleBookApi.GetBook(bookId);

        Book actualBook = JsonConvert.DeserializeObject<Book>(response.Content);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(actualBook.id, Is.EqualTo(bookId));
        Assert.That(actualBook.name, Is.EqualTo("The Russian"));
        Assert.That(actualBook.type, Is.EqualTo(BookType.Fiction));
        Assert.That(actualBook.available, Is.EqualTo(true));
    }

    [Test]
    [Explicit]
    public void TestOrderBook()
    {
        Order order = _simpleBooksData.GetNewOrder();
        RestResponse response = _simpleBookApi.OrderBook(order);

    }

    [Test]
    [Explicit]
    public void TestGenerateAuthToken()
    {
        Client client = _simpleBooksData.GetNewClient();
        RestResponse response = _simpleBookApi.GenerateAuthToken(client);

        _accessToken = JsonConvert.DeserializeObject<AccessToken>(response.Content);
        
        //Add logic for access token 
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(_accessToken.accessToken, Is.Not.Null);
    }
}