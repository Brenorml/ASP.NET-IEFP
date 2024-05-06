using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;

namespace WebCalendario
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";

            if(!IsPostBack)
            {
                int i;
                for(i = 1; i <= 31; i++)
                {
                    DropDownListDia.Items.Add(i.ToString());
                }
                for(i = 1; i <= 12; i++)
                {
                    DropDownListMes.Items.Add(i.ToString());
                }
                for(i = DateTime.Today.Year; i >= 1900; i--)
                {
                    DropDownListAno.Items.Add(i.ToString());
                }
                DropDownListAno.Items.FindByText("2000").Selected = true;


            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label2.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Label2.Text == "")
            {
                Label1.Text = "Tem que indicar uma data!!!";
            }
            else
            {
                DateTime dataNascimento = Calendar1.SelectedDate, today = DateTime.Today;
                int idade = today.Year - dataNascimento.Year;

                if(dataNascimento > today.AddYears(-idade))
                {
                    //Ainda não completou anos
                    Label3.Text = "Ainda falta(m) " + (dataNascimento.AddYears(idade) - today).TotalDays.ToString() + " dia(s) para o aniversário!!!";
                    idade--;
                }
                else
                {
                    //Completou anos
                    Label3.Text = "Ainda falta(m) " + (dataNascimento.AddYears(idade + 1) - today).TotalDays.ToString() + " dia(s) para o aniversário!!!";
                }
                Label1.Text = idade.ToString() + " anos";
                TimeSpan tempoDeVida = DateTime.Now.Subtract(dataNascimento);
                int diasDeVida = tempoDeVida.Days;
                if(diasDeVida == 0)
                {
                    Label4.Text = "Nasceu hoje!!!";
                    //Label5.Text = horoscopo(dataNascimento);
                    Label5.Text = horoscopo2(dataNascimento.Day, dataNascimento.Month, ref Image1);
                }
                else if(diasDeVida > 0)
                {
                    Label4.Text = "Já viveu " + diasDeVida + " dia(s)!";
                    //Label5.Text = horoscopo(dataNascimento);
                    Label5.Text = horoscopo2(dataNascimento.Day, dataNascimento.Month, ref Image1);
                }
                else
                {
                    Label4.Text = "Ainda não nasceu!!!";
                    Label5.Text = "";
                }
                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(TextBox1.Text);
                Calendar1.TodaysDate = dateTime;
                Calendar1.SelectedDate = Calendar1.TodaysDate;
                Label2.Text = Calendar1.SelectedDate.ToShortDateString();
                Label3.Text = "";
            }
            catch
            {

            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + TextBox1.Text + "');", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string data = DropDownListDia.SelectedValue + "/" + DropDownListMes.SelectedValue + "/" + DropDownListAno.SelectedValue;
            try
            {
                DateTime dateTime = Convert.ToDateTime(data);
                Calendar1.TodaysDate = dateTime;
                Calendar1.SelectedDate = Calendar1.TodaysDate;
                Label2.Text = Calendar1.SelectedDate.ToShortDateString();
                TextBox1.Text = data;
                Label3.Text = "";
            }
            catch
            {
                TextBox1.Text = "Data incorreta!!!";
            }
        }
        string horoscopo(DateTime data)
        {
            string signo = "";
            int mes, dia;
            mes = data.Month;
            dia = data.Day;

            if ((mes == 1 && dia >= 21) || (mes == 2 && dia <= 18))
            {
                signo = "Aquário";
                Image1.ImageUrl = "~/img/aquario.jpg";
                return signo;
            }
            if ((mes == 2 && dia >= 19) || (mes == 3 && dia <= 20))
            {
                signo = "Peixes";
                Image1.ImageUrl = "~/img/peixes.jpg";
                return signo;
            }
            if ((mes == 3 && dia >= 21) || (mes == 4 && dia <= 19))
            {
                signo = "Áries";
                Image1.ImageUrl = "~/img/carneiro.jpg";
                return signo;
            }
            if ((mes == 4 && dia >= 20) || (mes == 5 && dia <= 20))
            {
                signo = "Touro";
                Image1.ImageUrl = "~/img/touro.jpg";
                return signo;
            }
            if ((mes == 5 && dia >= 21) || (mes == 6 && dia <= 21))
            {
                signo = "Gêmeos";
                Image1.ImageUrl = "~/img/gemeos.jpg";
                return signo;
            }
            if ((mes == 6 && dia >= 22) || (mes == 7 && dia <= 22))
            {
                signo = "Câncer";
                Image1.ImageUrl = "~/img/caranguejo.jpg";
                return signo;
            }
            if ((mes == 7 && dia >= 23) || (mes == 8 && dia <= 22))
            {
                signo = "Leão";
                Image1.ImageUrl = "~/img/leao.jpg";
                return signo;
            }
            if ((mes == 8 && dia >= 23) || (mes == 9 && dia <= 22))
            {
                signo = "Virgem";
                Image1.ImageUrl = "~/img/virgem.jpg";
                return signo;
            }
            if ((mes == 9 && dia >= 23) || (mes == 10 && dia <= 22))
            {
                signo = "Balança";
                Image1.ImageUrl = "~/img/balanca.jpg";
                return signo;
            }
            if ((mes == 10 && dia >= 23) || (mes == 11 && dia <= 21))
            {
                signo = "Escorpião";
                Image1.ImageUrl = "~/img/escorpiao.jpg";
                return signo;
            }
            if ((mes == 11 && dia >= 22) || (mes == 12 && dia <= 21))
            {
                signo = "Sagitário";
                Image1.ImageUrl = "~/img/sagitario.jpg";
                return signo;
            }
            if ((mes == 12 && dia >= 22) || (mes == 1 && dia <= 20))
            {
                signo = "Capricórnio";
                Image1.ImageUrl = "~/img/capricornio.jpg";
                return signo;
            }            
            return "";
        }

        string horoscopo2(int dia, int mes, ref Image Image1)
        {
            string signo = "";
            
            if(dia <= DateTime.Now.Day)
            {
                if ((mes == 1 && dia >= 21) || (mes == 2 && dia <= 18))
                {
                    signo = "Aquário";
                    Image1.ImageUrl = "~/img/aquario.jpg";
                    return signo;
                }
                if ((mes == 2 && dia >= 19) || (mes == 3 && dia <= 20))
                {
                    signo = "Peixes";
                    Image1.ImageUrl = "~/img/peixes.jpg";
                    return signo;
                }
                if ((mes == 3 && dia >= 21) || (mes == 4 && dia <= 19))
                {
                    signo = "Áries";
                    Image1.ImageUrl = "~/img/carneiro.jpg";
                    return signo;
                }
                if ((mes == 4 && dia >= 20) || (mes == 5 && dia <= 20))
                {
                    signo = "Touro";
                    Image1.ImageUrl = "~/img/touro.jpg";
                    return signo;
                }
                if ((mes == 5 && dia >= 21) || (mes == 6 && dia <= 21))
                {
                    signo = "Gêmeos";
                    Image1.ImageUrl = "~/img/gemeos.jpg";
                    return signo;
                }
                if ((mes == 6 && dia >= 22) || (mes == 7 && dia <= 22))
                {
                    signo = "Câncer";
                    Image1.ImageUrl = "~/img/caranguejo.jpg";
                    return signo;
                }
                if ((mes == 7 && dia >= 23) || (mes == 8 && dia <= 22))
                {
                    signo = "Leão";
                    Image1.ImageUrl = "~/img/leao.jpg";
                    return signo;
                }
                if ((mes == 8 && dia >= 23) || (mes == 9 && dia <= 22))
                {
                    signo = "Virgem";
                    Image1.ImageUrl = "~/img/virgem.jpg";
                    return signo;
                }
                if ((mes == 9 && dia >= 23) || (mes == 10 && dia <= 22))
                {
                    signo = "Balança";
                    Image1.ImageUrl = "~/img/balanca.jpg";
                    return signo;
                }
                if ((mes == 10 && dia >= 23) || (mes == 11 && dia <= 21))
                {
                    signo = "Escorpião";
                    Image1.ImageUrl = "~/img/escorpiao.jpg";
                    return signo;
                }
                if ((mes == 11 && dia >= 22) || (mes == 12 && dia <= 21))
                {
                    signo = "Sagitário";
                    Image1.ImageUrl = "~/img/sagitario.jpg";
                    return signo;
                }
                if ((mes == 12 && dia >= 22) || (mes == 1 && dia <= 20))
                {
                    signo = "Capricórnio";
                    Image1.ImageUrl = "~/img/capricornio.jpg";
                    return signo;
                }
            }
            else
            {
                Image1.ImageUrl = "~/img/inicio.jpg";
                return signo;
            }
            
            return "";
        }
    }
}