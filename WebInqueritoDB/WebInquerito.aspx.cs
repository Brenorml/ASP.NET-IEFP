using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebInquerito
{
    public partial class WebInquerito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = string.Empty;
            txtNome.MaxLength = 60;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string display = "", comida = "", clube = "";

            if (CheckBox1.Checked == true)
            {
                comida = CheckBox1.Text;
            }
            if (CheckBox2.Checked == true)
            {
                if (comida.Length > 0)
                {
                    comida += ", ";
                }
                comida = comida + CheckBox2.Text;
            }
            if (CheckBox3.Checked == true)
            {
                if (comida.Length > 0)
                {
                    comida += " e ";
                }
                comida = comida + CheckBox3.Text;
            }
            if (RadioButton1.Checked == true)
            {
                clube = RadioButton1.Text;
            }
            if (RadioButton2.Checked == true)
            {
                clube = RadioButton2.Text;
            }
            if (RadioButton3.Checked == true)
            {
                clube = RadioButton3.Text;
            }
            display = txtNome.Text + " vive em " + lstCidades.Text + ", gosta de comer " + comida +
                " e o seu clube de coração é o " + clube;

            Label1.Text = display;

            ClientScript.RegisterStartupScript(this.GetType(), "Mensagem",
                "alert('" + display + "');", true);

            DBConnect ligacao = new DBConnect();
            //DBConnectMySQL ligacao = new DBConnectMySQL();
            if (ligacao.Insert(txtNome.Text, lstCidades.Text, comida, clube))
            {
                Label1.Text = "Inseriru com sucesso!";
            }
            else
            {
                Label1.Text = "Erro na inserção!";
            }

        }
    }
}