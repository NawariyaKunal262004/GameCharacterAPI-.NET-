namespace VideoGameCharacterApi.Dtos
{
    public class UpdateCharacterRequest
    {
        // Id of the character to update. The controller routes include the id,
        // but including it here helps clients provide a complete payload.
        public int Id { get; set; } 

        // Updated name of the character.
        public string Name { get; set; } = string.Empty;    

        // Updated game name.
        public string Game { get; set; } = string.Empty;    

        // Updated role or description.
        public string Role { get; set; } = string.Empty;
    }
}
