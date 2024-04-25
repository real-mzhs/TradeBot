using Microsoft.Extensions.Configuration;
using RestSharp;
using UserService.Domain.Dtos.CommonDtos;
using UserService.Domain.Interfaces;

namespace UserService.Domain.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    public async Task SendEmailAsync(CreateEmailDto emailDto)
    {
        var client = new RestClient(configuration["ResendConfig:Base"]!);
        var request = new RestRequest("/emails", Method.Post);
        
        request.AddHeader("Authorization", $"Bearer {configuration["ResendConfig:Key"]}");
        request.AddHeader("Content-Type", "application/json");

        request.AddJsonBody(new
        {
            from = configuration["SmtpConfig:Sender"],
            to = emailDto.Email,
            subject = emailDto.Subject,
            html  = emailDto.Message
        });
        
        await client.ExecuteAsync(request);
    }
}
