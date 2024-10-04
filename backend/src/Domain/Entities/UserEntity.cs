namespace Domain.Entities;

public class UserEntity : BaseEntity
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string IdentityId { get; set; }
}
