namespace VideoGameCharacterApi.Models
{
    public class Character
    {
        // Primary key. EF Core will treat this as the identity column by convention.
        public int Id { get; set; }

        // Character name.
        public string Name { get; set; } = string.Empty;

        // Game that the character belongs to.
        public string Game { get; set; } = string.Empty;

        // Role or short description of the character.
        public string Role { get; set; } = string.Empty;
    }
}
