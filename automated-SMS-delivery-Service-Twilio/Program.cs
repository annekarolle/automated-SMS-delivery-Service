using automated_SMS_delivery_Service_Twilio.Services;
using Microsoft.OpenApi.Models;
using Twilio.Clients;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TWILIO - Automated SMS Delivery Service ",
        Version = "v1"
    });    
}); 


builder.Services.AddHttpClient();
builder.Services.AddHostedService<TwilioAutomatedSMSSendService>();
builder.Services.AddScoped<ITwilioRestClient, TwilioClientService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TWILIO - Automated SMS Delivery Service v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
