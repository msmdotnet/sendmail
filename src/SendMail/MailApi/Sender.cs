namespace MailApi;

public class Sender
{
    readonly SMTPOptions Options;
    readonly ILogger<Sender> Logger;
    public Sender(IOptions<SMTPOptions> options,
        ILogger<Sender> logger)
    {
        Options = options.Value;
        Logger = logger;
    }

    public async Task SendAsync(string to,
        string subject, string body)
    {
        try
        {
            MailMessage Message = new MailMessage(Options.From, to);
            Message.Subject = subject;
            Message.Body = body;
            SmtpClient SmtpClient = new SmtpClient(
                Options.Host, Options.Port)
            {
                Credentials = new NetworkCredential(
                    Options.UserName, Options.Password),
                EnableSsl = true
            };
            await SmtpClient.SendMailAsync(Message);
        }
        catch (Exception ex)
        {
            Logger.LogError("ERROR: {0}", ex.Message);
        }
    }
}
