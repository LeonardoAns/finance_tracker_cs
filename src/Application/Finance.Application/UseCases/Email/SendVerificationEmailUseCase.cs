using System.Net;
using System.Net.Mail;
using Finance.Application.IUseCases.Email;
using Microsoft.Extensions.Configuration;

namespace Finance.Application.UseCases.Email;
    public class SendVerificationEmailUseCase : ISendVerificationEmailUseCase
    {
        private readonly IConfiguration _configuration;

        public SendVerificationEmailUseCase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Execute(Domain.Entities.AccountHolder accountHolder)
        {
            string smtpServer = "smtp-relay.brevo.com"; 
            int smtpPort = 587; 
            string smtpUsername = "7d6f68001@smtp-brevo.com"; 
            string smtpPassword = "5CUrY4SEqZ1wyAcn";

            string toAddress = accountHolder.Email; 
            string fromAddress = "leonardo.anschau@icloud.com"; 
            string senderName = "Finance Tracker"; 
            string subject = "Verifique seu registro"; 
            string content = "<!DOCTYPE html>\n<html lang=\"pt-BR\">\n<head>\n    " +
                             "<meta charset=\"UTF-8\">\n  " +
                             " <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    " +
                             "<title>Verificação de E-mail</title>\n   " +
                             " <style>\n body {\n " +
                             "font-family: Arial, sans-serif;\n" +
                             "background-color: #f4f9f4; /* Verde claro */\nmargin: 0;\npadding: 0;\n" +
                             "}\n\n.email-container {\nmax-width: 600px;\nmargin: 50px auto;\nbackground-color: #ffffff;\n" +
                             "border-radius: 8px;\nbox-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);\noverflow: hidden;\nborder: " +
                             "1px solid #dcdcdc;\n}\n\n.header {\nbackground-color: #007f00; \ncolor: #ffffff;\n" +
                             "padding: 20px;\ntext-align: center;\n}\n\n.header h1 {\nmargin: 0;\n" +
                             " font-size: 24px;\n}\n\n.content {\npadding: 20px;\ntext-align: center;\n}\n\n" +
                             " .content h2 {\ncolor: #007f00; /* Verde escuro */\nmargin-bottom: 10px;\n}\n\n.content p {\n  " +
                             "color: #555555;\nmargin-bottom: 20px;\nline-height: 1.6;\n}\n\n.verification-code {\n " +
                             "display: inline-block;\nfont-size: 18px;\nfont-weight: bold;\ncolor: #ffffff;\n" +
                             " background-color: #00a000; /* Verde médio */\npadding: 10px 20px;\nborder-radius: 5px;\ntext-decoration: none;\n" +
                             " margin-top: 20px;\n}\n\n.footer {\nbackground-color: #f4f9f4; /* Verde claro */\ncolor: #888888;\n" +
                             "text-align: center;\npadding: 10px;\nfont-size: 14px;\n}\n</style>\n</head>\n<body>\n<div class=\"email-container\">\n<div class=\"header\">\n" +
                             "<h1>Muito obrigado por se registrar</h1>\n<p>Verifique o seu e-mail</p>\n</div>\n<div class=\"content\">\n<h2>Olá, "+accountHolder.FullName.Split()[0]+"!</h2>\n" +
                             "<p>Você iniciou a criação da sua conta, mas falta um último passo! Utilize o código abaixo para concluir seu registro:</p>\n<div class=\"verification-code\">"+accountHolder.VerificationCode+"</div>\n         " +
                             "<p>Se você não solicitou este e-mail, por favor, ignore esta mensagem.</p>\n</div>\n<div class=\"footer\">\n<p>Obrigado!</p>\n</div>\n</div>\n</body>\n</html>\n"; 

            try
            {
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

