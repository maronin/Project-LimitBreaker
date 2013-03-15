using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Default : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        MembershipUser userInfo = Membership.GetUser(username.Text.Trim());
        if (userInfo != null)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(userInfo.Email, "LimitBreaker password reset"));
            mm.From = new MailAddress("lynart@limitbreaker.com");
            mm.Body = "Your password has been reset to <b>" + userInfo.ResetPassword() + "</b>\nPlease login and change your password";
            Membership.UpdateUser(userInfo);
            mm.IsBodyHtml = true;
            mm.Subject = "LimitBreaker password reset";
            SmtpClient smcl = new SmtpClient();
            smcl.Host = "smtp.gmail.com";
            smcl.Port = 587;
            smcl.Credentials = new System.Net.NetworkCredential("projectlimitbreaker@gmail.com", "furaijin");
            smcl.EnableSsl = true;
            smcl.Send(mm);
            status.ForeColor = System.Drawing.Color.Green;
            status.Text = "Check the email associated with the account!";
        }
        else
        {
            status.ForeColor = System.Drawing.Color.Red;
            status.Text = "User not found";
        }
    }
}