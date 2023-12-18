public class InfoNames
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; } // In a real application, consider storing a hashed password instead

    public InfoNames(string firstName, string lastName, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
    }
}