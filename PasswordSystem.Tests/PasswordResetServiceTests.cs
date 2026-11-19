namespace PasswordSystem.Tests;

public class PasswordResetServiceTests
{
    [Fact]
    public void SendResetEmail_SendsTokenToCorrectEmail()
    {
        // Arrange
        var fakeUserRepository = new FakeUserRepository();
        var fakeEmailProvider = new FakeEmailProvider();
        var fakeTokenGenerator = new FakeTokenGenerator();
        var sut = new PasswordResetService(fakeEmailProvider, fakeTokenGenerator, fakeUserRepository);
        var testEmail = "test@test.com";
        fakeUserRepository.AddUser(testEmail, "123");

        // Act
        fakeUserRepository.IsEmailRegistered(testEmail);
        sut.SendResetEmail(testEmail);

        // Assert
        var sentEmail = Assert.Single(fakeEmailProvider.SentEmails);
        Assert.Equal(testEmail, sentEmail.To);
        Assert.Contains(fakeTokenGenerator.Token, sentEmail.Body);
    }
}
