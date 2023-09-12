namespace MailApi.Options;
public class SMTPOptions
{
    public const string SetionKey = "SMTP";
    public string Host { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string From { get; set; }
}
