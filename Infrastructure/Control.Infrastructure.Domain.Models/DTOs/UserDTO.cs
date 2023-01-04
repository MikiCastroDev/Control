namespace Control.Infrastructure.Domain.Models.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Role { get; set; }
    }
}
