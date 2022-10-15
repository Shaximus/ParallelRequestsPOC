namespace ParallelRequestsPOC.App;

public class FormioApiParallel
{
    // get forms from formio
    public async Task<HttpResponseMessage[]> Run()
    {
        var client = new HttpClient();
        var responses = new List<Task<HttpResponseMessage>>();

        for (var i = 0; i < 10; i++)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.form.io/project/5f9f1b9b9b9b9b9b9b9b9b9b/form");
            responses.Add(client.SendAsync(request));
        }
        var result = await Task.WhenAll(responses);
        
        return result;
    }
}