using RestSharp;
using SimpleBooksApi.API.Poco;

namespace SimpleBooksApi.API;

public class SimpleBookApi
{
    private readonly RestClient _client = new("https://simple-books-api.glitch.me");

    public RestResponse GetApiStatus()
    {
        var request = new RestRequest(Endpoint.GetApiStatis);
        return _client.Get(request);
    }

    public RestResponse GetAllBooks()
    {
        var request = new RestRequest(Endpoint.GetCurrentBooks);
        return _client.Get(request);
    }

    public RestResponse GetBookType(string type)
    {
        var request = new RestRequest(Endpoint.GetCurrentBooks);
        request.AddQueryParameter("type", type);
        return _client.Get(request);
    }

    public RestResponse GetBook(int bookId)
    {
        var request = new RestRequest(Endpoint.GetCurrentBooks + $"/{bookId}");
        request.AddUrlSegment("bookId",bookId);
        return _client.Get(request);
    }

    public RestResponse OrderBook(Order order)
    {
        var request = new RestRequest(Endpoint.Orders);
        request.AddBody(order);
        return _client.Post(request);
    }
}