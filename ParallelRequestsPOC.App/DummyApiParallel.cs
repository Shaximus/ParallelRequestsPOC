namespace ParallelRequestsPOC.App;

public class DummyApiParallel
{
    public async Task<HttpResponseMessage[]> Run()
    {
        var client = new HttpClient();
        var responses = new List<Task<HttpResponseMessage>>();

        for (var i = 0; i < 10; i++)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.publicapis.org/entries");
            responses.Add(client.SendAsync(request));
        }
        var result = await Task.WhenAll(responses);
        
        return result;
    }
}