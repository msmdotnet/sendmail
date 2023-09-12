using MailApi;
using MailApi.Options;
using SendMail.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMailService(config => 
    builder.Configuration.GetSection(SMTPOptions.SetionKey).Bind(config));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapPost("/sendmail",  (Sender sender, SendMailDto data) =>
{
    sender.SendAsync(data.To, data.Subject, data.Body);
    return Results.Ok();
});

app.Run();

