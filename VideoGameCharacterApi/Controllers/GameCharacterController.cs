using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers;

        [Route("api/[controller]")]
[ApiController]
public class GameCharacterController(IVideoGameCharacterService service) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetCharacters()
            => Ok(await service.GetAllCharctersAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacter(int id)
    {
        var character = await service.GetCharacterByIdAsync(id);
        return character is null ? NotFound("Character with the given Id was not found.") : Ok(character);
 
    }
}

