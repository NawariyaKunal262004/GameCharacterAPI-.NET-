using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers;

// Controller exposes HTTP endpoints under /api/GameCharacter
// It receives HTTP requests and delegates work to the service layer.
[Route("api/[controller]")]
[ApiController]
public class GameCharacterController(IVideoGameCharacterService service) : ControllerBase
{
    // GET /api/GameCharacter
    // Returns a list of characters. Uses the service to fetch data from the database.
    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetCharacters()
            => Ok(await service.GetAllCharactersAsync());

    // GET /api/GameCharacter/{id}
    // Returns a single character by id or 404 if not found.
    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacter(int id)
    {
        var character = await service.GetCharacterByIdAsync(id);
        return character is null ? NotFound("Character with the given Id was not found.") : Ok(character);

    }

    // POST /api/GameCharacter
    // Creates a new character. The request body should match CreateCharacterRequest DTO.
    [HttpPost]
    public async Task<ActionResult<Character>> AddCharacter(CreateCharacterRequest character)
    {
        var createdCharacter = await service.AddCharacterAsync(character);
        // Returns 201 Created with a location header pointing to the new resource.
        return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
    }

    // PUT /api/GameCharacter/{id}
    // Updates an existing character. Returns 204 No Content on success or 404 if not found.
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
    {
        var updated = await service.UpdateCharacterAsync(id, character);
        return updated ? NoContent() : NotFound("Character with the given Id was not found.");
    }

    // DELETE /api/GameCharacter/{id}
    // Deletes a character by id. Returns 204 on success or 404 if not found.
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCharacter(int id)
    {
        var deleted = await service.DeleteCharacterAsync(id);
        return deleted ? NoContent() : NotFound("Character with the given Id was not found.");
    }


}

