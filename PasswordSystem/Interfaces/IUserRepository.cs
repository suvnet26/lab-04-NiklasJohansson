namespace PasswordSystem;

public interface IUserRepository
{
    public void AddUser(string email, string password);
    public bool IsEmailRegistered(string email);
}
