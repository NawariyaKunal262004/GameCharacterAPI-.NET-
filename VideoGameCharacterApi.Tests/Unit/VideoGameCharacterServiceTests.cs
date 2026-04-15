using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using VideoGameCharacterApi.Services;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace VideoGameCharacterApi.Tests.Unit;

public class VideoGameCharacterServiceTests
{
    [Fact]
    public async Task AddCharacterAsync_AddsCharacter_ReturnsResponse()
    {
        // Arrange: use in-memory db
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "AddCharacterTestDb")
            .Options;

        await using var context = new AppDbContext(options);
        var service = new VideoGameCharacterService(context);

        var request = new CreateCharacterRequest { Name = "Test", Game = "TestGame", Role = "NPC" };

        // Act
        var result = await service.AddCharacterAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.Name);
        Assert.Equal("TestGame", result.Game);
        Assert.Equal("NPC", result.Role);
    }
}
