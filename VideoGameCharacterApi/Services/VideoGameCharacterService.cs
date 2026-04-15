using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Models;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Dtos;


namespace VideoGameCharacterApi.Services
{
    // Service class implements business logic for managing characters.
    // It talks to the AppDbContext (database) and returns/accepts DTOs defined in Dtos folder.
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {

        // Create a new character in the database.
        // Accepts CreateCharacterRequest (a simple DTO with Name, Game, Role) and
        // returns CharacterResponse which includes the generated Id.
        public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
        {
            // Map DTO to domain model entity.
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };

            // Add the new entity to the context and save changes to persist it.
            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            // Map back to response DTO and return the created entity info.
            return new CharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };

        }

        // Delete a character by id. Returns true if deletion succeeded, false if not found.
        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var existingCharacter = await context.Characters.FindAsync(id);
            if (existingCharacter is null)
                return false; // Nothing to delete

            context.Characters.Remove(existingCharacter);
            await context.SaveChangesAsync();
            return true;
        }

        // Get all characters. Returns a list of CharacterResponse DTOs to avoid exposing domain entities.
        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
            => await context.Characters.Select(c => new CharacterResponse
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();

        // Get a single character by id. Returns null if not found.
        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                }).FirstOrDefaultAsync();
            return result;
        }

        // Update an existing character. Uses the UpdateCharacterRequest DTO and returns
        // true when update succeeds or false when the character was not found.
        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var existingCharacter = await context.Characters.FindAsync(id);
            if (existingCharacter is null)
                return false;

            // Update values on the tracked entity and save changes.
            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;

            await context.SaveChangesAsync();

            return true;
        }

    }
}
