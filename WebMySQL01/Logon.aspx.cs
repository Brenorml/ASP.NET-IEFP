using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebMySQL01
{
    public partial class Logon : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserPass.Attributes.Add("value", txtUserPass.Text);
        }

        protected void btnLogon_Click(object sender, EventArgs e)
        {
            if(ligacao.ValidateUser(txtUserName.Text, txtUserPass.Text))
            {
                Session["username"] = txtUserName.Text;
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
                Response.Redirect("index.aspx");
            }
            else
            {
                lblMsg.Text = "Nome ou Palavra Passe inválidos!";
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        { 
            if (CheckBox1.Checked)
            {
                
                txtUserPass.TextMode = TextBoxMode.SingleLine;
            }
            else
            {                
                txtUserPass.TextMode = TextBoxMode.Password;                
            }            
        }
    }
}