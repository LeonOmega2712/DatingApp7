namespace API.Entities; // Add the .Entities to add the logical direction to use the class.
// This helps to avoid problems if there is multiple classes using the same name, but we
// can differentiate them by the namespace.

public class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public string Gender { get; set; }
    public string Introduction { get; set; }
    public string LookingFor { get; set; }
    public string Interests { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public List<Photo> Photos { get; set; } = new();

    // ! IMPORTANT: GetAge uses the naming convention to allow AutoMapper to get the Age in the MemberDto mapping
    // public int GetAge()
    // {
    //     return DateOfBirth.CalculateAge();
    // }
}