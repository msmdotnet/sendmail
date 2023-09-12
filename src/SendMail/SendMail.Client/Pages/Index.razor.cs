namespace SendMail.Client.Pages;

public partial class Index
{
    [Inject]
    MailService Service { get; set; }

    string To;
    string Subject;
    string Body;

    async Task SendMail()
    {
        await Service.SendAsync(To, Subject, Body);
    }
}
