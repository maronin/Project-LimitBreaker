<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="createUser.aspx.cs" Inherits="User_createUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 312px;
        }

        .auto-style1
        {
            width: 455px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <table>
                <tr>
                    <td>Create New User</td>
                </tr>
                <tr>
                    <td>Username:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="userName" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="userName" ForeColor="Red">Username required</asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="userName" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z0-9._\-]{3,32}$">Invalid username</asp:RegularExpressionValidator>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="password" runat="server" EnableViewState="True" TextMode="Password"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password" ForeColor="Red">Password required</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="email" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="email">Email required</asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid email</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Weight(lbs):</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="weight" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="weight" ForeColor="Red">Weight required</asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="weight" ForeColor="Red" ValidationExpression="^\d{2,3}$">Invalid weight</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Height:</td>
                    <td class="auto-style1">Ft.<asp:DropDownList ID="heightFoot" runat="server">
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        </asp:DropDownList>
                    In<asp:DropDownList ID="heightInch" runat="server">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                        </asp:DropDownList>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td class="auto-style1">
                        <asp:RadioButtonList ID="genderList" runat="server">
                            <asp:ListItem Selected="True">Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td>Birthday:</td>
                    <td class="auto-style1">Month
                        <asp:DropDownList ID="birthdayMonth" runat="server">
                            <asp:ListItem Value="1">1. January</asp:ListItem>
                            <asp:ListItem Value="2">2. February</asp:ListItem>
                            <asp:ListItem Value="3">3. March</asp:ListItem>
                            <asp:ListItem Value="4">4. April</asp:ListItem>
                            <asp:ListItem Value="5">5. May</asp:ListItem>
                            <asp:ListItem Value="6">6. June</asp:ListItem>
                            <asp:ListItem Value="7">7. July</asp:ListItem>
                            <asp:ListItem Value="8">8. August</asp:ListItem>
                            <asp:ListItem Value="9">9. September</asp:ListItem>
                            <asp:ListItem Value="10">10. October</asp:ListItem>
                            <asp:ListItem Value="11">11. November</asp:ListItem>
                            <asp:ListItem Value="12">12. December</asp:ListItem>
                        </asp:DropDownList>
                        Day
                        <asp:DropDownList ID="birthdayDay" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem Value="4"></asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                        </asp:DropDownList>
                        Year
                        <asp:TextBox ID="birthdayYear" runat="server" ControlToValidate="birthdayYear" TextMode="SingleLine"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Birthday required" ControlToValidate="birthdayYear" ForeColor="Red"></asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="birthdayYear" ErrorMessage="Invalid birthday year" ForeColor="Red" ValidationExpression="^(19|20)\d{2}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style1">I accept the terms of service (put link here later)
                    <asp:CheckBox ID="termOfService" runat="server" /><br />
                        <asp:Label ID="tosValidator" runat="server" Text="You must accept the terms of agreement to create an account" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Button ID="Create" runat="server" Text="Create New User"
                OnClick="Create_Click" />
            <asp:Label ID="creationStatus" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </AnonymousTemplate>
        <LoggedInTemplate>
            You are currently logged in as: 
            <asp:LoginName ID="LoginName1" runat="server" />
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

