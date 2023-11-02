using RestSharp;
using SimpleBooksApi.API.Poco;

namespace SimpleBooksApi.API;

public class SimpleBookApi
{
    private readonly RestClient _client = new("https://simple-books-api.glitch.me");

    public RestResponse GetApiStatus()
    {
        var request = new RestRequest(Endpoint.ApiStatus);
        return _client.Get(request);
    }

    public RestResponse GetAllBooks()
    {
        var request = new RestRequest(Endpoint.CurrentBooks);
        return _client.Get(request);
    }

    public RestResponse GetBookType(string type)
    {
        var request = new RestRequest(Endpoint.CurrentBooks);
        request.AddQueryParameter("type", type);
        return _client.Get(request);
    }

    public RestResponse GetBook(int bookId)
    {
        var request = new RestRequest(Endpoint.CurrentBooks + $"/{bookId}");
        request.AddUrlSegment("bookId",bookId);
        return _client.Get(request);
    }

    public RestResponse OrderBook(Order order)
    {
        var request = new RestRequest(Endpoint.Orders);
        request.AddBody(order);
        return _client.Post(request);
    }

    public RestResponse GenerateAuthToken(Client client)
    {
        var request = new RestRequest(Endpoint.AuthToken);
        request.AddBody(client);
        return _client.Post(request);
    }


    public RestResponse PostRequest<T>(string endPoint, T data)
    {
        var request = new RestRequest(endPoint);
        request.AddBody(data);
        return _client.Post(request);
        
        //Should I use this method instead of the two above?? 
    }
}