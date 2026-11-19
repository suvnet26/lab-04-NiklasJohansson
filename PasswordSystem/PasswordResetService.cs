namespace PasswordSystem;

public class PasswordResetService(IEmailProvider emailProvider, ITokenGenerator tokenGenerator, IUserRepository userRepository)
{
    private readonly IEmailProvider _emailProvider = emailProvider;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    List<string> emails = new(); 

    public void SendResetEmail(string email)
    {
        bool isRegistered = IsEmailRegistered(email);
        if (isRegistered)
        {
            string subject = "Password Reset Requested";
            string token = _tokenGenerator.Generate();
            string body = CreateEmailBody(token);
            _emailProvider.SendEmail(email, subject, body);
        }
        else
        {
            Console.WriteLine("Email is not registered");
        }
    }

    private string CreateEmailBody(string token)
    {
        string link = $"https://example.com/reset?token={token}";
        return $"Click the following link to reset your password: {link}";
    }
    private bool IsEmailRegistered(string email)
    {
        var isRegistered = _userRepository.IsEmailRegistered(email);  
        return isRegistered;
    }
    
}