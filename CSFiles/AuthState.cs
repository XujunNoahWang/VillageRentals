namespace VillageRentals.CSFiles;

public static class AuthState
{
    public static bool IsLoggedIn { get; private set; }
    public static string Role { get; private set; }
    public static string CustomerFirstName { get; private set; } 

    public static void Login(string role, string firstName = null)
    {
        IsLoggedIn = true;
        Role = role;
        CustomerFirstName = firstName; 
    }

    public static void Logout()
    {
        IsLoggedIn = false;
        Role = null;
        CustomerFirstName = null; 
    }
}