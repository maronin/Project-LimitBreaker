using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;

//User name rules fo the regex on the aspx file: Usernames must be at least 3 characters long, starting with a letter, be alphanumeric and may contain . _ or -
public partial class User_createUser : System.Web.UI.Page
{
    UserManager manager = new UserManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name == "")
        {
            DropDownList birthday = ((DropDownList)LoginView1.FindControl("birthdayYear"));
            ListItem year;
            int endYear = DateTime.Now.Year - 4;
            for (int i = endYear; i > endYear - 100; i--)
            {
                String tempYear = Convert.ToString(i);
                year = new ListItem(tempYear, tempYear);
                birthday.Items.Add(year);
            }
        }
    }
    protected void Create_Click(object sender, EventArgs e)
    {

        if (((CheckBox)LoginView1.FindControl("termOfService")).Checked)
        {
            String userName = ((TextBox)LoginView1.FindControl("userName")).Text;
            String password = ((TextBox)LoginView1.FindControl("password")).Text;
            String email = ((TextBox)LoginView1.FindControl("email")).Text;
            String gender = ((RadioButtonList)LoginView1.FindControl("genderList")).SelectedValue;
            Double weight = Convert.ToDouble(((TextBox)LoginView1.FindControl("weight")).Text);

            Double height = Convert.ToDouble(((TextBox)LoginView1.FindControl("height")).Text);

            String birthdayDay = ((DropDownList)LoginView1.FindControl("birthdayDay")).SelectedValue;
            String birthdayMonth = ((DropDownList)LoginView1.FindControl("birthdayMonth")).SelectedValue;
            String birthdayYear = ((DropDownList)LoginView1.FindControl("birthdayYear")).SelectedValue;

            DateTime birthday = new DateTime(Convert.ToInt32(birthdayYear), Convert.ToInt32(birthdayMonth), Convert.ToInt32(birthdayDay));

            int success = manager.createNewLimitBreaker(userName, email, gender, birthday, Convert.ToDouble(weight), height);
            Label creationStatus = ((Label)LoginView1.FindControl("creationStatus"));

            switch (success)
            {
                case 0:
                    manager.updateRMR(userName);
                    manager.updateBMI(userName);
                    System.Web.Security.MembershipCreateStatus status;
                    System.Web.Security.Membership.CreateUser(userName, password, email, "none", "none", false, out status);
                    System.Web.Security.Roles.AddUserToRole(userName, "user");
                    System.Web.Security.Membership.ValidateUser(userName, password);
                    sendVerification(userName, email);
                    Response.Redirect("success.aspx");
                    break;
                case 1:

                    creationStatus.Visible = true;
                    creationStatus.Text = "It brokerz";
                    break;
                case 2:

                    creationStatus.Visible = true;
                    creationStatus.Text = "Username or email already exists";
                    break;

            }
        }
        else
        {
            ((Label)LoginView1.FindControl("tosValidator")).Visible = true;
        }

    }
    protected void sendVerification(String username, String email)
    {
        MembershipUser userInfo = Membership.GetUser(username);
        String verifyURL = Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~User/verify.aspx?ID=" + userInfo.ProviderUserKey.ToString());
        MailMessage mm = new MailMessage();
        mm.To.Add(new MailAddress(email, "LimitBreaker verification"));
        mm.From = new MailAddress("lynart@limitbreaker.com");
        mm.Body = "<a href="+verifyURL+">Click here to verify</a> your account";
        mm.IsBodyHtml = true;
        mm.Subject = "Verification";
        SmtpClient smcl = new SmtpClient();
        smcl.Host = "smtp.gmail.com";
        smcl.Port = 587;
        smcl.Credentials = new System.Net.NetworkCredential("vince.lee.lien@gmail.com", "wh@t3verv");
        smcl.EnableSsl = true;
        smcl.Send(mm);
    }
}