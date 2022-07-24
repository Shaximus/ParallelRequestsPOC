using System.Net;

namespace ParallelRequestsPOC.App.Tests;

public class DummyApiParallelTests
{
    [Fact]
    public async void Run_AllSuccesses()
    {
        // Arrange
        var runner = new DummyApiParallel();
        
        // Act
        var result = await runner.Run();
        
        // Assert
        foreach (var res in result)
        {
            Assert.True(res.IsSuccessStatusCode);
        }
    }
}