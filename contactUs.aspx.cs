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
        MailMessage mm = new MailMessage();
        mm.To.Add(new MailAddress("projectlimitbreaker@gmail.com"));
        mm.From = new MailAddress(eAddressTextbox.Text);
        mm.Subject = "LimitBreaker";
        SmtpClient smcl = new SmtpClient();
        smcl.Host = "smtp.gmail.com";
        smcl.Port = 587;
        smcl.Credentials = new System.Net.NetworkCredential("projectlimitbreaker@gmail.com", "furaijin");
        smcl.EnableSsl = true;
        smcl.Send(mm);
    }
}