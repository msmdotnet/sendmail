namespace SendMail.Client.Services;

public class MailService
{
    readonly HttpClient Client;
    public MailService(HttpClient client)
    {
        Client = client;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        await Client.PostAsJsonAsync("sendmail", new SendMailDto
        { 
            To = to, 
            Subject = subject, 
            Body = body 
        });
    }
}
