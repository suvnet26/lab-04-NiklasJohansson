namespace PasswordSystem.Tests;

public class FakeUserRepository : IUserRepository
{
    public List<string> emails = new();
    public void AddUser(string email, string password)
    {
        var exists = emails.FirstOrDefault(stringToCheck => stringToCheck.Contains(email));
        if(exists == null)
        {
            if(email != null)
            {
                emails.Add(email);
            }
        }

    }
    public bool IsEmailRegistered(string email)
    {
        var isRegistered = emails.FirstOrDefault(stringToCheck => stringToCheck.Contains(email));
        if(isRegistered != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}