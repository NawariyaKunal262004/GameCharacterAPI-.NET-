using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Models;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Dtos;


namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {


        public Task<CharacterResponse> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync( int id )
            => await context.Characters.Select(c => new CharacterResponse
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                }).FirstOrDefaultAsync();
            return result;
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
