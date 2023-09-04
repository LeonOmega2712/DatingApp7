namespace API.Entities; // Add the .Entities to add the logical direction to use the class.
// This helps to avoid problems if there is multiple classes using the same name, but we
// can differentiate them by the namespace.

public class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set;}
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}
