using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;

public partial class contactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(eAddressTextbox.Text);
            mm.CC.Add(new MailAddress(eAddressTextbox.Text));
            mm.To.Add(new MailAddress("projectlimitbreaker@gmail.com"));
            mm.Subject = subjectTxtBox.Text;
            mm.Body = eMessageTextBox.Text;

            SmtpClient smcl = new SmtpClient();
            smcl.Host = "smtp.gmail.com";
            smcl.Port = 587;
            smcl.Credentials = new System.Net.NetworkCredential("projectlimitbreaker@gmail.com", "furaijin");
            smcl.EnableSsl = true;
            smcl.Send(mm);

            confirmLabel.Text = "Email Sent! A copy has been sent to your inbox as well";
        }

        catch (Exception ex)
        {
            confirmLabel.Text = "Something went wrong with sending the email: " + ex.Message;
        }
    }
}