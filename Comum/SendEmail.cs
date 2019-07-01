namespace Fantasy_server.Comum
{
    public class SendEmail
    {
         public static void Mail () {
            // MimeMessage mensage = new MimeMessage ();

            // mensage.From.Add (new MailboxAddress ("Jorge", "jorgemirandaneto@gmail.com"));
            // mensage.To.Add (new MailboxAddress ("Jorge", "jorgin.miranda@gmail.com"));
            // mensage.Subject = "Teste de envio de email";

            // var bodyBuilder = new BodyBuilder ();
            // bodyBuilder.HtmlBody = "<a href="+"www.google.com.br"+">Teste de link aqui.</a>";
            // bodyBuilder.TextBody = "Click aqui!!!";

            // mensage.Body = bodyBuilder.ToMessageBody();
            // using (var client = new SmtpClient ()) {
            //     client.Connect ("smtp.gmail.com", 587, false);

            //     client.Authenticate("jorgemirandaneto@gmail.com", "********");

            //     client.Send(mensage);

            //     client.Disconnect(true);
            // }
        }
    }
}