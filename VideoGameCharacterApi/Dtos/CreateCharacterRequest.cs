namespace VideoGameCharacterApi.Dtos
{
    public class CreateCharacterRequest
    {
        // Name of the character (e.g., "Mario"). Required when creating a character.
        public string Name { get; set; } = string.Empty;

        // The game this character belongs to (e.g., "Super Mario Bros").
        public string Game { get; set; } = string.Empty;

        // The character's role or description (e.g., "Plumber", "Hero").
        public string Role { get; set; } = string.Empty;

        // This DTO only contains the properties needed to create a new record.
    }
}
