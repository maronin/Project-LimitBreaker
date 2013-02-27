using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Security;

public partial class verify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString["ID"]) || !Regex.IsMatch(Request.QueryString["ID"], "[0-9a-f]{8}\\-([0-9a-f]{4}\\-){3}[0-9a-f]{12}"))
        {
            Label1.Text = "Invalid! Go lift some more.";
        }
        else
        {
            Guid userID = new Guid(Request.QueryString["ID"]);
            MembershipUser userInfo = Membership.GetUser(userID);
            if (userInfo == null)
            {
                Label1.Text = "Stop screwing with my site";
            }
            else
            {
                userInfo.IsApproved = true;
                Membership.UpdateUser(userInfo);
                Label1.Text = "You have now been verified. Please login =)";
            }
        }
    }
}
/*
 'Make sure that a valid querystring value was passed through
If String.IsNullOrEmpty(Request.QueryString("ID")) OrElse Not Regex.IsMatch(Request.QueryString("ID"), "[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}") Then
   InformationLabel.Text = "An invalid ID value was passed in through the querystring."
Else
   'ID exists and is kosher, see if this user is already approved
   'Get the ID sent in the querystring
   Dim userId As Guid = New Guid(Request.QueryString("ID"))

   'Get information about the user
   Dim userInfo As MembershipUser = Membership.GetUser(userId)
   If userInfo Is Nothing Then
      'Could not find user!
      InformationLabel.Text = "The user account could not be found in the membership database."
   Else
      'User is valid, approve them
      userInfo.IsApproved = True
      Membership.UpdateUser(userInfo)

      'Display a message
      InformationLabel.Text = "Your account has been verified and you can now log into the site."
   End If
*/