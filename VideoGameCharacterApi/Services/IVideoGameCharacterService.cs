using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Dtos;


namespace VideoGameCharacterApi.Services;

    public  interface IVideoGameCharacterService
    {
        Task<List<CharacterResponse>> GetAllCharactersAsync();
        Task<CharacterResponse?> GetCharacterByIdAsync(int id);
        Task<CharacterResponse> AddCharacterAsync(Character character);
        Task<bool> UpdateCharacterAsync(int id, Character character);
        Task<bool> DeleteCharacterAsync(int id);

    }

