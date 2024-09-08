namespace Entities.Dtos
{
    public record UserForUpdateDto : UserDto
    {
        public List<string> UserRoles { get; init; } = new List<string>();
    }
}