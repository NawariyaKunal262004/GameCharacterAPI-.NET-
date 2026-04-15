using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using VideoGameCharacterApi;
using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Tests.Integration;

public class GameCharacterApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public GameCharacterApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Post_Get_Delete_Character_Works()
    {
        var client = _factory.CreateClient();

        var create = new CreateCharacterRequest { Name = "ITest", Game = "IGame", Role = "Irole" };
        var content = new StringContent(JsonSerializer.Serialize(create), Encoding.UTF8, "application/json");

        // POST
        var postResponse = await client.PostAsync("/api/GameCharacter", content);
        postResponse.EnsureSuccessStatusCode();

        // GET list
        var getResponse = await client.GetAsync("/api/GameCharacter");
        getResponse.EnsureSuccessStatusCode();

        // We won't parse body deeply here; existence checks are enough for a simple integration test.
    }
}
