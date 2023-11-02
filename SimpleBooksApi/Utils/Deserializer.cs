using Newtonsoft.Json;
using SimpleBooksApi.API.Poco;

namespace SimpleBooksApi.Utils;

public class Deserializer<T>
{

    public List<T> DeserializeList(string? responseContent) 
   {
        return new List<T>
           (JsonConvert.DeserializeObject<List<T>>(responseContent));
    }
}