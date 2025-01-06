using System.Net;
using System.Net.Mail;
using Finance.Application.IUseCases.Email;
using Microsoft.Extensions.Configuration;

namespace Finance.Application.UseCases.Email;

using Domain.Entities;

public class SendWelcomeEmailUseCase : ISendWelcomeEmailUseCase {

    private readonly IConfiguration _configuration;

    public SendWelcomeEmailUseCase(IConfiguration configuration){
        _configuration = configuration;
    }

    public async Task Execute(AccountHolder accountHolder){
        string smtpServer = "smtp-relay.brevo.com"; 
        int smtpPort = 587; 
        string smtpUsername = "7d6f68001@smtp-brevo.com"; 
        string smtpPassword = "5CUrY4SEqZ1wyAcn";
        
        string toAddress = accountHolder.Email; 
        string fromAddress = "leonardo.anschau@icloud.com"; 
        string senderName = "Finance Tracker"; 
        string subject = $"Seja Bem-Vindo {accountHolder.FullName.Split()[0]}"; 
        string content = "<!DOCTYPE html>\n" +
                         "<html lang=\"pt-BR\" xmlns:th=\"http://www.w3.org/1999/xhtml\">\n" +
                         "<head>\n" +
                         "    <meta charset=\"UTF-8\">\n" +
                         "    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n" +
                         "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n" +
                         "    <title>Obrigado por verificar sua conta!</title>\n" +
                         "    <style>\n" +
                         "        body {\n" +
                         "            font-family: Arial, sans-serif;\n" +
                         "            background-color: #f4f4f4;\n" +
                         "            margin: 0;\n" +
                         "            padding: 0;\n" +
                         "        }\n" +
                         "        .container {\n" +
                         "            background-color: #ffffff;\n" +
                         "            max-width: 600px;\n" +
                         "            margin: 50px auto;\n" +
                         "            padding: 20px;\n" +
                         "            border-radius: 8px;\n" +
                         "            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);\n" +
                         "        }\n" +
                         "        .header {\n" +
                         "            background-color: #17DA17;\n" +
                         "            color: white;\n" +
                         "            text-align: center;\n" +
                         "            padding: 20px;\n" +
                         "            border-top-left-radius: 8px;\n" +
                         "            border-top-right-radius: 8px;\n" +
                         "        }\n" +
                         "        .header h1 {\n" +
                         "            margin: 0;\n" +
                         "            font-size: 24px;\n" +
                         "        }\n" +
                         "        .content {\n" +
                         "            padding: 20px;\n" +
                         "            text-align: center;\n" +
                         "        }\n" +
                         "        .content h2 {\n" +
                         "            color: #0033a0;\n" +
                         "        }\n" +
                         "        .content p {\n" +
                         "            font-size: 16px;\n" +
                         "            color: #333333;\n" +
                         "        }\n" +
                         "        .footer {\n" +
                         "            text-align: center;\n" +
                         "            padding: 20px;\n" +
                         "            background-color: #f4f4f4;\n" +
                         "            color: #555555;\n" +
                         "            font-size: 14px;\n" +
                         "        }\n" +
                         "    </style>\n" +
                         "</head>\n" +
                         "<body>\n" +
                         "<div class=\"container\">\n" +
                         "    <div class=\"header\">\n" +
                         "        <h1>Equipe Finance Tracker</h1>\n" +
                         "    </div>\n" +
                         "    <div class=\"content\">\n" +
                         "        <h2>Obrigado por confirmar seu e-mail, <span th:text=\"${firstName}\"></span>!</h2>\n" +
                         "        <p>\n" +
                         "            Estamos muito felizes em ter você conosco! A sua conta foi verificada com sucesso, e agora você pode aproveitar todos os recursos do nosso aplicativo.\n" +
                         "        </p>\n" +
                         "        <p>\n" +
                         "            Fique atento, pois em breve teremos novidades! Estamos constantemente trabalhando para adicionar novas funcionalidades e melhorar a sua experiência.\n" +
                         "        </p>\n" +
                         "        <p>\n" +
                         "            Caso tenha alguma dúvida ou sugestão, não hesite em nos contatar. Estamos aqui para ajudar!\n" +
                         "        </p>\n" +
                         "    </div>\n" +
                         "    <div class=\"footer\">\n" +
                         "        <p>Obrigado por fazer parte da nossa comunidade!</p>\n" +
                         "    </div>\n" +
                         "</div>\n" +
                         "</body>\n" +
                         "</html>\n";
        try{
            using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword); 

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromAddress, senderName),
                    Subject = subject,
                    Body = content,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toAddress); 

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
        catch (System.Exception e){
            throw new FormatException("Error while send email");
        }
    }
}