using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for EmailManager
/// </summary>
public class EmailManager
{
    private static EmailManager instance = null;
    SmtpClient mailClient;

	private EmailManager()
	{
        mailClient = new SmtpClient();
        mailClient.Host = "smtp.gmail.com";
        mailClient.Port = 587;
        mailClient.Credentials = new System.Net.NetworkCredential("projectlimitbreaker@gmail.com", "furaijin");
        mailClient.EnableSsl = true;
	}

    public static EmailManager getInstance()
    {
        if (instance == null)
        {
            instance = new EmailManager();
        }
        return instance;
    }

    public void sendMessage(String subject, String body, String toEmail)
    {
        MailMessage message = new MailMessage();
        message.To.Add(new MailAddress(toEmail));
        message.From = new MailAddress("lynart@limitbreaker.com");
        message.Subject = subject;
        message.Body = body;
        message.IsBodyHtml = true;
        try
        {
            mailClient.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception was caught in EmailManager when sending a message: " + ex.ToString());
        }
    }
}
/*
        MembershipUser userInfo = Membership.GetUser(username);
        String verifyURL = Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/User/verify.aspx?ID=" + userInfo.ProviderUserKey.ToString());
        MailMessage mm = new MailMessage();
        mm.To.Add(new MailAddress(email, "LimitBreaker verification"));
        mm.From = new MailAddress("lynart@limitbreaker.com");
        mm.Body = "<a href="+verifyURL+">Click here to verify</a> your account";
        mm.IsBodyHtml = true;
        mm.Subject = "Verification";
        SmtpClient smcl = new SmtpClient();
        smcl.Host = "smtp.gmail.com";
        smcl.Port = 587;
        smcl.Credentials = new System.Net.NetworkCredential("projectlimitbreaker@gmail.com", "furaijin");
        smcl.EnableSsl = true;
        smcl.Send(mm);
*/