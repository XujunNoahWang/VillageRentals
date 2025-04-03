namespace VillageRentals.CSFiles;

public static class AuthState
{
    public static bool IsLoggedIn { get; private set; }
    public static string Role { get; private set; } = string.Empty;
    public static string CustomerFirstName { get; private set; } = string.Empty;

    public static void Login(string role, string customerFirstName = "")
    {
        IsLoggedIn = true;
        Role = role;
        CustomerFirstName = role == "Customer" ? customerFirstName : string.Empty;
    }

    public static void Logout()
    {
        IsLoggedIn = false;
        Role = string.Empty;
        CustomerFirstName = string.Empty;
    }
}